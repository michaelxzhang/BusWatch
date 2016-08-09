using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;

namespace BusWatch
{

    class CfgRW
    {
        private static int Grp = 0;
        private static int PhoneNum = 1;
        private static int Addr = 2;
        private static int BusNum = 3;
        private static int Stopid = 4;
        private static int StopName = 5;

        public static void Readcfg()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "cfg.txt");

            string[] filelines = File.ReadAllLines(filename);
            string[] splitline;
            for(int cnt=0;cnt<filelines.Length;cnt++)
            {
                splitline = filelines[cnt].Split(',');

                App7.MainActivity.lay[cnt].busnum.Text = splitline[BusNum];
                App7.MainActivity.lay[cnt].busstop.Text = splitline[StopName] + ",stop id: " + splitline[Stopid] + "\r\n" + "Next bus: ";
                
            }            
        }

        public static void Writecfg()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "cfg.txt");
            string[] lines = {  "Return,74000,,15,9189,Fishcreek LRT",
                                "Return,74000,,15,4795,Shawnessy LRT",
                                "Return,74000,,15,8232,7-11" };

            File.WriteAllLines(filename,lines);

        }
    }
}