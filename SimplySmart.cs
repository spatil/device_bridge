using Microsoft.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace simplysmart
{
    public partial class SimplySmart : Form
    {
        Hashtable devices = new Hashtable();
       
        Subscriber subscriber;
        public Int32 no_of_doors = 0;
        public Int32 timezoneId = 1;

        public SimplySmart()
        {
            InitializeComponent();
        }

        //4.1  call connect function
        [DllImport("C:\\WINDOWS\\system32\\plcommpro.dll", EntryPoint = "Connect")]
        public static extern IntPtr Connect(string Parameters);
        [DllImport("plcommpro.dll", EntryPoint = "PullLastError")]
        public static extern int PullLastError();

        //4.2 call Disconnect function
        [DllImport("plcommpro.dll", EntryPoint = "Disconnect")]
        public static extern void Disconnect(IntPtr h);

        //4.2 call Disconnect function
        [DllImport("plcommpro.dll", EntryPoint = "SearchDevice")]
        public static extern int SearchDevice(string udp, string address, ref byte buffer);

        //4.6 call SetDeviceData function

        [DllImport("plcommpro.dll", EntryPoint = "SetDeviceData")]
        public static extern int SetDeviceData(IntPtr h, string tablename, string data, string options);


        [DllImport("plcommpro.dll", EntryPoint = "DeleteDeviceData")]
        public static extern int DeleteDeviceData(IntPtr h, string tablename, string data, string options);


        internal void registerGuest(string guest)
        {
            string guest_id = parseGuestData(guest)["guest_id"];
            string template = "";
            bool ret = false;
            Int32 i = 0;
            
       
            axAFXOnlineMain.DefaultWindowClose = 3600;
            axAFXOnlineMain.EnrollCount = 3;

            axAFXOnlineMain.SetLanguageFile("zkonline.en");
            axAFXOnlineMain.SetVerHint = "Register fingerprint";
            axAFXOnlineMain.FPEngineVersion = "10";
            axAFXOnlineMain.DefaultRegFinger = 6;
            axAFXOnlineMain.IsSupportDuress = true;
            
            ret = axAFXOnlineMain.Register();

            if (ret)
            {
                for (i = 0; i < 10; i++)
                {
                    template = axAFXOnlineMain.GetRegFingerTemplate(i);
                    if (template != null)
                    {
                        //registerUserOnDevices(template, guest_id);
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        dict.Add("guest_id", guest_id);
                        dict.Add("status", "200");
                        dict.Add("template", template);
                        subscriber.Publish("registration_callback_channel", dict);
                        Log("Fingerprint accepted for guest "+ guest_id);
                    }
      
                }
                //MessageBox.Show("Register fingerprint  succeed!!");
            }
            else
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("guest_id", guest_id);
                dict.Add("status", "500");
                dict.Add("error", "Fingerprint Registration Failed");
                subscriber.Publish("registration_callback_channel", dict);
                Log("Unable to register fingerprint for guest " + guest_id);
                return;
            }
            axAFXOnlineMain.InitSensor();
            axAFXOnlineMain.EndInit();
            return;
        }

        private Dictionary<string,string> parseGuestData(string guest)
        {
            JArray jarray = JArray.Parse(guest);
            Dictionary<string, string> obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(jarray[0].ToString());
            return obj;
        }

        private void registerUserOnDevices(string template, string guestId)
        {
            string data = "";

            foreach(IntPtr ptr in devices.Values)
            {
                // set user table data
                data = "CardNo=0\tPin="+guestId+"\tPassword=";
                if (saveData(ptr, "user", data) < 0)
                    return;

                data = "Pin="+guestId+"\tFingerID=5\tValid=1\tSize="+template.Length+"\tTemplate="+template+"\t\r\n";
                if (saveData(ptr, "templatev10", data) < 0)
                    return;
                for (int j = 1; j <= no_of_doors; j++)
                {
                    data = "Pin=" + guestId + "\tAuthorizeTimezoneId=" + timezoneId.ToString() + "\tAuthorizeDoorId=" + j.ToString() + "\t\r\n";

                    if (saveData(ptr, "userauthorize", data) < 0)
                        return;
                }
                Log("Checked in Guest ID : " + guestId);
            }
        }

      
        private int saveData(IntPtr ptr, string table, string data)
        {
            Int32 ret = SetDeviceData(ptr, table, data, "");
            if (ret < 0)
                MessageBox.Show("User Data operation failed!");

            return ret;
        }

        private void connectDevices()
        {
            List<string> ip_address = new List<string>();
            byte[] buffer = new byte[64 * 1024];
            string udp = "UDP";
            string adr = "255.255.255.255";
            string str = "";
            string[] tmp;
            Int32 i = 0;
            Int32 j = 0;

            Int32 ret = SearchDevice(udp, adr, ref buffer[0]);

            if (ret >= 0)
            {
                str = Encoding.Default.GetString(buffer);
                str = str.Replace("\r\n", "\t");
                tmp = str.Split('\t');
                while (i < tmp.Length - 1)
                {
                    string[] config = tmp[i].Split(',');
                    while (j < config.Length)
                    {
                        if (config[j].Contains("IP"))
                        {
                            ip_address.Add(config[j].Split('=')[1]);
                            Log("Connected to device " + ip_address.Count);
                            break;
                        }
                        j++;
                    }
                    i++;
                }
            }
            else
                MessageBox.Show("Unable to connect to devices. Please check...");

            IntPtr ptr = IntPtr.Zero;
            string tpl = "protocol=TCP,ipaddress={0},port=4370,timeout=2000,passwd=";
            Int32 count = 0;
            
            foreach (string key in ip_address)
            {
                ptr = IntPtr.Zero;
                ptr = Connect(String.Format(tpl, key));
                if (ptr == IntPtr.Zero)
                {
                    MessageBox.Show("Unable to connect to devices!!!");
                    break;
                }
                else
                {
                    cmbDoorNames.Items.Add(key);
                    devices.Add(key, ptr);
                    lblConnectedDevice.Text = ip_address.Count.ToString();
                    count++;
                }
            }
        }


        internal void checkInGuest(string data)
        {
            JArray jarray = JArray.Parse(data);
            List<Hashtable> lstGuest = JsonConvert.DeserializeObject<List<Hashtable>>(jarray[0].ToString());
            foreach(Hashtable guest in lstGuest)
            {
                registerUserOnDevices(guest["template"].ToString(), guest["guest_id"].ToString());
            }

            Dictionary<string,string> dict = new Dictionary<string, string>();
            dict.Add("status", "ok");
            subscriber.Publish("checkin_callback_channel", dict);
            clearLog();
        }

        internal void CheckoutGuest(string data)
        {
            Int32 ret = 0;
            JArray jarray = JArray.Parse(data);
            List<string> lstGuest = JsonConvert.DeserializeObject<List<string>>(jarray[0].ToString());
            string guest = "";
                 
            

            foreach (IntPtr ptr in devices.Values)
            {
                foreach (string guest_id in lstGuest)
                {
                   
                    guest = String.Format("Pin={0}", guest_id);
                    // delete user table data for given guest_id
                    ret = DeleteDeviceData(ptr, "user", guest, "");
                    if (ret < 0)
                        Log("Unable to delete the User data...");

                    ret = DeleteDeviceData(ptr, "templatev10", guest, "");
                    if (ret < 0)
                        Log("Unable to delete the Tempalte data...");

                    ret = DeleteDeviceData(ptr, "userauthorize", guest, "");
                    if (ret < 0)
                        Log("Unable to delete the Door  data...");
                }

            }
     
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("status", "ok");
            subscriber.Publish("checkout_callback_channel", dict);
            Log("Checked Out Guest Successfully");
        }


        delegate void SetLogCallback(string text);
        private void Log(string str)
        {
            if (this.txtLog.InvokeRequired)
            {
                SetLogCallback d = new SetLogCallback(Log);
                this.Invoke(d, new object[] { str });
            }
            else
            {
                txtLog.AppendText("\r\n" + str);
                txtLog.ScrollToCaret();
            }
        }

        delegate void SetClearLogCallback();
        
        private void clearLog()
        {
            if (this.txtLog.InvokeRequired)
            {
                SetClearLogCallback d = new SetClearLogCallback(clearLog);
                this.Invoke(d, new object[] {});
            }
            else
            {
                txtLog.Clear();
                txtLog.AppendText("\r\n " + this.devices.Keys.Count + " devices connected");
            }
        }

        private void reconnectDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log("Reconnecting devices...");
            connectDevices();
        }

        [DllImport("plcommpro.dll", EntryPoint = "ControlDevice")]
        public static extern int ControlDevice(IntPtr h, int operationid, int param1, int param2, int param3, int param4, string options);


        private void button1_Click(object sender, EventArgs e)
        {
            int ret = 0;
            int operID = 1;
            int outputAddrType = 2;
            int doorAction = 1;

            if (check_if_door_selected())
            {
                IntPtr h = (IntPtr)devices[cmbDoorNames.SelectedItem];
                for (int j = 1; j <= no_of_doors; j++)
                {
                    ret = ControlDevice(h, operID, j, outputAddrType, doorAction, 0, "");     //call ControlDevice funtion from PullSDK

                    if (ret >= 0)
                    {
                        Log("Door " + j + " of " + cmbDoorNames.SelectedItem + " Opened");
                    }
                }
            }
        }

        private void SimplySmart_Load(object sender, EventArgs e)
        {
            connectDevices();
            subscriber = new Subscriber(this);
            no_of_doors = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["no_of_doors"]);
            timezoneId = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timezone_id"]);
            lblDoorID.Text = no_of_doors.ToString();
        }



        internal void OpenDoor(string data)
        {
            int ret = 0;
            int operID = 1;
            int outputAddrType = 2;
            int doorAction = 1;

            string ip_address = parseGuestData(data)["access_control"];
            
            IntPtr h = (IntPtr)devices[ip_address];
            for (int j = 1; j <= no_of_doors; j++)
            {
                ret = ControlDevice(h, operID, j, outputAddrType, doorAction, 0, "");     //call ControlDevice funtion from PullSDK

                if (ret >= 0)
                {
                    Log("Door " + j + " of " + ip_address + " Opened");
                }
            }
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("status", "ok");
            subscriber.Publish("open_door_callback_channel", dict);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            int ret = 0;

            if (check_if_door_selected())
            {
                IntPtr h = (IntPtr)devices[cmbDoorNames.SelectedItem];

                ret = DeleteDeviceData(h, "user", "*", "");
                if (ret < 0)
                    Log("Unable to delete the User data...");

                ret = DeleteDeviceData(h, "templatev10", "*", "");
                if (ret < 0)
                    Log("Unable to delete the Tempalte data...");

                ret = DeleteDeviceData(h, "userauthorize", "*", "");
                if (ret < 0)
                    Log("Unable to delete the Door  data...");

                Log("Device Data is cleared..");
            }
        }

        private bool check_if_door_selected()
        {
            bool result = false;
            if(cmbDoorNames.SelectedItem != null)
            {
                result = true;
            }
            else
            {
                MessageBox.Show("Please select Device");
            }
            return result;
        }
    }
}
