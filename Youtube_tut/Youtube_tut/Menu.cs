using Cosmos.HAL.BlockDevice.Registers;
using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using SoundTest;
using SoundTest.Applications.Task_Scheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_tut
{
    public class Menu
    {
        //It was showing an error, because the class name was identical to it

        //Now I'm going to import the menu picture
        [ManifestResourceStream(ResourceName = "Youtube_tut.Menu.bmp")] public static byte[] menu;
        public static Bitmap Menu_base = new Bitmap(menu);

        public static bool was_clicked = false;
        public static bool menu_opened = false;
        public static void Menu_mgr()
        {
            //Taskbar
            ImprovedVBE.DrawFilledRectangle(7895160, 0, 1030, 1920, 50);//This represents the taskbar
            //Start menu
            ImprovedVBE.DrawFilledRectangle(16777215, 5, 1035, 80, 40);//The 16777215 number means the white color in int

            //Now lets make the basic click for it
            if (MouseManager.MouseState == MouseState.Left)
            {
                was_clicked = true;
            }
            if(MouseManager.MouseState == MouseState.None && was_clicked == true)//This will check if the menu button was actually clicked and if the left button was released after the click.
            {
                //Now the x, y positioning
                if(MouseManager.X > 5 && MouseManager.X < 85 && MouseManager.Y > 1035 && MouseManager.Y < 1075)//So, the way it works is you have the x and y starting point of the button
                    //Then you add the width to the x and get the max which in this case is 85. The same with the y, but in that case you add the height to it, and the result is 1075
                {
                    if (menu_opened == true)
                    {
                        menu_opened = false;
                    }
                    else
                    {
                        menu_opened = true;
                    }
                    //And after that, type this chunk in here
                    //And the result is:
                }
                was_clicked = false;
            }
            if(menu_opened == true)
            {
                ImprovedVBE.DrawImage(Menu_base, 0, 600);
                if(MouseManager.MouseState == MouseState.Left)
                {
                    if(MouseManager.X > 0 && MouseManager.X < 200 && MouseManager.Y > 600 && MouseManager.Y < 630)
                    {
                        Task_Manager.Tasks.Add(new Tuple<string, int, int, bool, string>("calculator", 10, 10, false, ""));//This will add the application to the list of tasks.
                        //In her I forgot to add a closing menu function
                        menu_opened = false;
                        //Whith this, after ou clicked on an app, it will close your menu automaticly
                    }
                }
                //First take out this chunk
            }
            //Now we successfully created our menu with open button, but now we have to close it too
            //It should work the same way if we put it in reverse, because in this case, the menu_opened needs to be in a false state
            //Now we just have to run it from the kernel.cs
            //So my first attempt didn't worked, but if you change the followings, I'm sure it will word for you too!

            //It works, but only halfly
            //To make it fully functional, we have to make a visible button and x,y positioning
            //The only thing left to do is to make and call the calculator program

            //Thanks for watching!
        }
    }
}
