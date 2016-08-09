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
        public static Buslayout[] lay = new Buslayout[10];

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(BusWatch.Resource.Layout.Main);

            LinearLayout baselayout = FindViewById<LinearLayout>(Resource.Id.linearLayout1);

            lay[0] = new Buslayout();
            lay[0].createview();
            baselayout.AddView(lay[0].separator);
            baselayout.AddView(lay[0].buslayout);

            lay[1] = new Buslayout();
            lay[1].createview();
            baselayout.AddView(lay[1].separator);
            baselayout.AddView(lay[1].buslayout);

            lay[2] = new Buslayout();
            lay[2].createview();
            baselayout.AddView(lay[2].separator);
            baselayout.AddView(lay[2].buslayout);

            BusWatch.CfgRW.Writecfg();
            BusWatch.CfgRW.Readcfg();
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

