using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VideoSaver;

namespace WindowsFormsApplication1
{
    static class Program
    {

        static void ShowScreenSaver()
        {
                    int screenIndex = 0;
#if DEBUG
                    screenIndex = 1;
#endif

                    //screenIndex = 1;

                    for (int i = 0; i < Screen.AllScreens.Length; i++)
                    {
                        Screen screen = Screen.AllScreens[i];
                        
                        if (screen.Primary)
                        {
                            ScreenSaverForm screensaver = new ScreenSaverForm(screen.Bounds, true);
                            screensaver.Show();
                        }
                        else
                        {
#if !DEBUG
                            BlankForm screensaver2 = new BlankForm(screen.Bounds);
                            screensaver2.Show();
#endif
                        }
                    }
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;

                // Handle cases where arguments are separated by colon.
                // Examples: /c:1234567 or /P:1234567
                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }
                else if (args.Length > 1)
                    secondArgument = args[1];

                if (firstArgument == "/c")           // Configuration mode
                {
                    Application.Run(new SettingsForm());
                }
                else if (firstArgument == "/p")      // Preview mode
                {
                    if (secondArgument == null)
                    {
                        MessageBox.Show("Sorry, but the expected window handle was not provided.",
                            "ScreenSaver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    //IntPtr previewWndHandle = new IntPtr(long.Parse(secondArgument));
                    //Application.Run(new ScreenSaverForm(previewWndHandle));
                }
                else if (firstArgument == "/s")      // Full-screen mode
                {
                    ShowScreenSaver();
                    Application.Run();
                }
                else    // Undefined argument
                {
                    MessageBox.Show("Sorry, but the command line argument \"" + firstArgument +
                        "\" is not valid.", "ScreenSaver",
                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else    // No arguments - treat like /c
            {
                Application.Run(new SettingsForm());
            }
        }
    }
}
