using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTest.Applications.Task_Scheduler
{
    public class Task_Manager
    {
        public static List<Tuple<string, int, int, bool, string>> Tasks = new List<Tuple<string, int, int, bool, string>>();
        public static int indicator = 0;
        public static bool reversed = false;
        public static int x = 4;
        public static int y = 79;
        public static List<int> data = new List<int>();
        public static int counter = 0;
        public static int foo = 0;
        public static int editor_counter = 0;

        public static Canvas c;

        //[ManifestResourceStream(ResourceName = "SoundTest.SystemFiles.Task_manager.bmp")] public static byte[] Solitaire;
        //public static Bitmap based = new Bitmap(Solitaire);
        public static void Task_manager()
        {
            //In here we have a foreach which goes thru every item in the Tasks list
            //ImprovedVBE.DrawImageAlpha(based, 0, 50);
            foreach (Tuple<string, int, int, bool, string> t in Tasks)
            {
                //Then in every item it check, wether it's a calculator or else
                if (t.Item1 == "calculator")
                {
                    Youtube_tut.Applications.Calculator.Calculator.calculator(t.Item2, t.Item3);//If it's a calculator, it executes the calculator program
                }
                indicator++;
            }
            indicator = 0;
        }
    }
}
