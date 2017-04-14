using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PubNubMessaging.Core;

namespace simplysmart
{
    class Subscriber
    {
        private Pubnub pubnub;
        SimplySmart s_obj;

        internal Subscriber(SimplySmart obj)
        {
            //pubnub = new Pubnub("pub-c-49b2da62-fe8a-434d-a871-9befc6c3bd9f", "sub-c-2034c7fe-dbcb-11e6-806b-02ee2ddab7fe", "sec-c-OWZhZWE0ZjMtNmViNy00N2NhLTlhNTctNGIyNjkzYWViNWVl");
            pubnub = new Pubnub("pub-c-d3407125-5cc6-4fc4-abe2-ec47992a3346", "sub-c-a06f68d2-2033-11e7-962a-02ee2ddab7fe", "sec-c-OWZhZWE0ZjMtNmViNy00N2NhLTlhNTctNGIyNjkzYWViNWVl");

            s_obj = obj;
            pubnub.Subscribe<string>("registration_channel", CallbackMessage, ConnectCallback, ErrorCallback);
            pubnub.Subscribe<string>("checkin_channel", CheckinMessage, ConnectCallback, ErrorCallback);
            pubnub.Subscribe<string>("checkout_channel", CheckoutMessage, ConnectCallback, ErrorCallback);
            pubnub.Subscribe<string>("open_door_channel", OpenDoorMessage, ConnectCallback, ErrorCallback);
        }

        internal void Publish(string channel, Dictionary<string,string> data)
        {
            pubnub.Publish<string>(channel, data, ConnectCallback, ErrorCallback);
        }

        private void OpenDoorMessage(string data)
        {
            s_obj.OpenDoor(data);
        }


        private void CheckoutMessage(string data)
        {
            s_obj.CheckoutGuest(data);
        }

        private void CheckinMessage(string data)
        {
            s_obj.checkInGuest(data);
        }

        public void CallbackMessage(string data)
        {
            s_obj.registerGuest(data);
        }

        public void ConnectCallback(string data)
        {

        }

        public void ErrorCallback(PubnubClientError error)
        {

        }

    }
}
