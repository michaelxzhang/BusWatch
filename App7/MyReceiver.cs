using System.Text;

using Android.App;
using Android.Content;

using Android.Widget;
using Android.Telephony;
using Android.Provider;

namespace BusWatch
{
    //class MyReceiver
    [BroadcastReceiver(Exported = true, Label = "SMS Receiver")]
    [IntentFilter(new string[] { "android.provider.Telephony.SMS_RECEIVED", "com.alr.text" })]
    public class MyReceiver : Android.Content.BroadcastReceiver
    {
        private const string Tag = "SMSBroadcastReceiver";
        private const string IntentAction = "android.provider.Telephony.SMS_RECEIVED";

        public override void OnReceive(Context context, Intent intent)
        {
            // Log.Info(Tag, "Intent received: " + intent.Action);
            // read the SendBroadcast data
            //if (intent.Action == "com.alr.text")
            //{
            //    string text = intent.GetStringExtra("MyData") ?? "Data not available";
            //    Toast.MakeText(context, text, ToastLength.Short).Show();
            //}
            //read incomming sms
            if (intent.Action == IntentAction)
            {
                SmsMessage[] messages = Telephony.Sms.Intents.GetMessagesFromIntent(intent);

                var sb = new StringBuilder();
                string[] splitstr;
                string[] timestr;
                for (var i = 0; i < messages.Length; i++)
                {

                    //sb.Append(string.Format("SMS From: {0}{1}Body: {2}{1}", messages[i].OriginatingAddress,
                    //    System.Environment.NewLine, messages[i].MessageBody));
                    if (messages[i].OriginatingAddress == "74000")
                    {
                        splitstr = messages[i].MessageBody.Split('\n');
                        timestr = splitstr[1].Split(')');
                        if(splitstr[0] == "9189")
                        {
                            App7.MainActivity.lay1.busstop.Text += timestr[1];
                        }
                        else if(splitstr[0] == "4795")
                        {
                            App7.MainActivity.lay2.busstop.Text += timestr[1];
                        }
                        else if(splitstr[0] == "8232")
                        {
                            App7.MainActivity.lay3.busstop.Text += timestr[1];
                        }
                    }
                }
                //Toast.MakeText(context, sb.ToString(), ToastLength.Short).Show();

            }
        }
    }


}