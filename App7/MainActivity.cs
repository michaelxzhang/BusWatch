using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;
using BusWatch;
using Android.Content.Res;
using Android.Telephony;

namespace App7
{
    public class Buslayout
    {
        public LinearLayout separator;
        public LinearLayout buslayout;
        public TextView busnum;
        public TextView busstop;

        //convert points to pixels
        private int dptopixels(float dp)
        {
            int pixels = (int)((dp) * Resources.System.DisplayMetrics.Density + 0.5f);
            return pixels;
        }

        //This view is used to display bus info
        public void createview()
        {
            Context thiscon = Application.Context;

            separator = new LinearLayout(thiscon);
            separator = new LinearLayout(thiscon);
            separator.Orientation = Android.Widget.Orientation.Horizontal;
            separator.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,1);
            separator.SetBackgroundColor(Android.Graphics.Color.Black);
      
            buslayout = new LinearLayout(thiscon);
            buslayout.Orientation = Android.Widget.Orientation.Horizontal;
            buslayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                                                                     ViewGroup.LayoutParams.WrapContent);
            buslayout.LayoutParameters.Height = dptopixels(89f);

            busnum = new TextView(thiscon);
            busnum.Text = "15";
            busnum.SetTextColor(Android.Graphics.Color.White);
            busnum.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent);

            busnum.SetWidth(dptopixels(65f));
            busnum.SetTextSize(Android.Util.ComplexUnitType.Px, 80);

            busstop = new TextView(thiscon);
            busstop.Text = "Shannon and Shawigan";
            busstop.SetTextColor(Android.Graphics.Color.White);

            busstop.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent);

            busstop.SetWidth(dptopixels(319.5f));
            busstop.SetTextSize(Android.Util.ComplexUnitType.Px, 35);

            buslayout.AddView(busnum);
            buslayout.AddView(busstop);
        }
    }

    [Activity(Label = "Bus Watch", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static Buslayout lay1;
        public static Buslayout lay2;
        public static Buslayout lay3;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(BusWatch.Resource.Layout.Main);

            LinearLayout baselayout = FindViewById<LinearLayout>(Resource.Id.linearLayout1);

            lay1 = new Buslayout();
            lay1.createview();
            lay1.busnum.Text = "15";
            lay1.busstop.Text = "Fishcreek LRT, stop id: 9189\r\nNext bus: ";
            baselayout.AddView(lay1.separator);
            baselayout.AddView(lay1.buslayout);

            lay2 = new Buslayout();
            lay2.createview();
            lay2.busnum.Text = "15";
            lay2.busstop.Text = "Shawnessy LRT, stop id: 4795\r\nNext bus: ";
            baselayout.AddView(lay2.separator);
            baselayout.AddView(lay2.buslayout);

            lay3 = new Buslayout();
            lay3.createview();
            lay3.busnum.Text = "15";
            lay3.busstop.Text = "7-11, stop id: 8232\r\nNext bus: ";
            baselayout.AddView(lay3.separator);
            baselayout.AddView(lay3.buslayout);
        }

        [Java.Interop.Export("RefreshInfo")]
        public void RefreshInfo(View view)
        {
            //Toast.MakeText(this, "Hello from " + view.Id, ToastLength.Long).Show();

            SmsManager.Default.SendTextMessage("74000", null, "4795#15", null, null);
            SmsManager.Default.SendTextMessage("74000", null, "9189#15", null, null);
            SmsManager.Default.SendTextMessage("74000", null, "8232#15", null, null);
        }
    }
}

