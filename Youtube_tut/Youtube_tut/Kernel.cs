﻿using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Sys = Cosmos.System;
using IL2CPU.API.Attribs;
using Cosmos.System;
using Cosmos.Core;
using Cosmos.Core.Memory;
using SoundTest;
using SoundTest.Applications.Task_Scheduler;

namespace Youtube_tut
{
    public class Kernel : Sys.Kernel
    {
        public static Canvas canvas;// = new Canvas(new Mode(1920, 1080, ColorDepth.ColorDepth32)); //Set the graphic mode: 1920 -> width 1080 -> height
        [ManifestResourceStream(ResourceName = "Youtube_tut.test.bmp")] public static byte[] test_image;
        public static Bitmap bmp = new Bitmap(test_image);//This is the test.bmp image loaded as bitmap
        //set the bitmap you want to be displayed as Build action: Embedded resource
        [ManifestResourceStream(ResourceName = "Youtube_tut.cursor.bmp")] public static byte[] cursor;
        public static Bitmap curs = new Bitmap(cursor);
        //defines the cursor image
        //Important: If you want to draw a bitmap make sure that it is in 32bpp
        protected override void BeforeRun()
        {
            //Setting the max cursor x and y position
            MouseManager.ScreenWidth = 1920;
            MouseManager.ScreenHeight = 1080;
            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
            //Set the cursor to the middle of the screen
            MouseManager.X = 1920 / 2;
            MouseManager.Y = 1080 / 2;
        }

        public static int bmp_x = 50;
        public static int bmp_y = 50;
        public static bool movable = false;

        protected override void Run()
        {
            //ImprovedVBE.DrawFilledRectangle(16777215, 0, 0, 1920, 1080);//In newer COSMOS versions replace new Pen(Color.color) with Color.color
            ImprovedVBE.clear(16777215);
            //Calling the bitmap
            //Now lets make the bitmap moveable
            /*
            ImprovedVBE.DrawImageAlpha(bmp, bmp_x, bmp_y);

            //We can tage out our last "application"
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (MouseManager.X > bmp_x && MouseManager.X < bmp.Width + bmp_x)
                {
                    if(MouseManager.Y > bmp_y && MouseManager.Y < bmp.Height + bmp_y)
                    {
                        movable = true;
                    }
                }
            }
            if (movable == true)
            {
                bmp_x = (int)MouseManager.X;
                bmp_y = (int)MouseManager.Y;
                if (MouseManager.MouseState == MouseState.Right)
                {
                    movable = false;
                }
            }
            */

            //But first, we have to init the Task manager
            Task_Manager.Task_manager();

            //Now lets make a menu
            Menu.Menu_mgr();
            //And that's it. Making a button is the same, but you don't have to do the same thing backwords

            //Drawing the cursor
            ImprovedVBE.DrawImageAlpha(curs, (int)MouseManager.X, (int)MouseManager.Y); //DrawImageAlpha is drwaing transparent bitmaps
            //Calling the memory managger
            Heap.Collect();
            //This will help running your OS much longer

            ImprovedVBE.display(canvas);

            canvas.Display(); //Always call canvas.Display() to draw to the screen
        }

        //Thanks for watching! 
    }
}
