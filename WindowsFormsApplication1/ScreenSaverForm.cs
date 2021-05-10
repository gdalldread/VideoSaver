using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace VideoSaver
{
    public partial class ScreenSaverForm : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        private bool previewMode = false;
        private bool newVideoLoaded = true;
        private Configuration config = Configuration.Load();

        public ScreenSaverForm()
        {
            InitializeComponent();
        }

        Rectangle bounds;

        public ScreenSaverForm(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
            bounds = Bounds;
        }

        public ScreenSaverForm(IntPtr PreviewWndHandle)
        {
            InitializeComponent();

            // Set the preview window as the parent of this window
            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            // GWL_STYLE = -16, WS_CHILD = 0x40000000
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            previewMode = true;
        }

        public ScreenSaverForm(Rectangle rectangle, bool p)
        {
            InitializeComponent();
            this.Bounds = rectangle;
            bounds = Bounds;
            if (!p)
            {
                axWindowsMediaPlayer1.Visible = false;
                axWindowsMediaPlayer1.URL = "";
            }
        }

        private void Form1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //config.Load();

            if (!previewMode)
            {
                Cursor.Hide();
                TopMost = true;
                SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            }

            axWindowsMediaPlayer1.settings.mute = true;
            axWindowsMediaPlayer1.settings.volume = 0;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Width = this.ClientRectangle.Width;
            axWindowsMediaPlayer1.Height = this.ClientRectangle.Height;
            axWindowsMediaPlayer1.Top = 0;
            axWindowsMediaPlayer1.Left = 0;

            nextVideoTimer.Tick += nextVideoTimer_Tick;

            BuildVideoList();
            SelectNextVideo();
        }

        private List<string> videoFileList = new List<string>();
        private int videoFileListItem;

        private void BuildVideoList()
        {
            videoFileList.Clear();

            try
            {
                string[] fileList = Directory.GetFiles(config.VideoFolder, "*.wmv");
                videoFileList.AddRange(fileList);

                fileList = Directory.GetFiles(config.VideoFolder, "*.avi");
                videoFileList.AddRange(fileList);

                fileList = Directory.GetFiles(config.VideoFolder, "*.mp4");
                videoFileList.AddRange(fileList);

                fileList = Directory.GetFiles(config.VideoFolder, "*.mov");
                videoFileList.AddRange(fileList);
            }
            catch
            {

            }
            videoFileListItem = 0;
        }

        Timer nextVideoTimer = new Timer();
        Random rnd = new Random(DateTime.Now.Second);

        private void SelectNextVideo()
        {
            newVideoLoaded = true;
            if (videoFileList.Count > 0)
            {
                if (config.PlayInRandomOrder)
                {
                    // pick a random video
                    videoFileListItem = rnd.Next(0, videoFileList.Count);
                }
            }
            if (videoFileList.Count > 0)
            {
                axWindowsMediaPlayer1.URL = videoFileList[videoFileListItem];
            }
            videoFileListItem++;
            if (videoFileListItem > videoFileList.Count)
            {
                videoFileListItem = 0;
            }

            // set a timer
            if (config.JumpToNextVideoAfterTime)
            {
                nextVideoTimer.Interval = config.TimeToNextVideo * 1000;
                nextVideoTimer.Enabled = true;
                nextVideoTimer.Start();
            }
        }

        void nextVideoTimer_Tick(object sender, EventArgs e)
        {
            nextVideoTimer.Enabled = false;
            nextVideoTimer.Stop();
            SelectNextVideo();
        }

        private string converttodatetime(string st)
        {
            double d = Convert.ToDouble(st);
            int h, m, s;
            string ms;
            h = (int)d / 3600;
            m = (int)(d - h * 3600) / 60;
            s = (int)(d - h * 3600 - m * 60);
            ms = st.Substring(st.LastIndexOf('.') + 1, 3);
            st = h.ToString("D2") + ":" + m.ToString("D2") + ":" + s.ToString("D2") + "," + ms;
            return st;
        }

        private Point mouseLocation;

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                    Math.Abs(mouseLocation.Y - e.Y) > 5)
                {
                    if (!previewMode)
                        Application.Exit();
                }
            }

            // Update current mouse location
            mouseLocation = e.Location;

        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private void ScreenSaverForm_Click(object sender, EventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private Point mouseLocation2;
        private void axWindowsMediaPlayer1_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
            if (!mouseLocation2.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation2.X - e.fX) > 5 ||
                    Math.Abs(mouseLocation2.Y - e.fY) > 5)
                {
                    if (!previewMode)
                        Application.Exit();
                }
            }

            // Update current mouse location
            mouseLocation2.X = e.fX;
            mouseLocation2.Y = e.fY;
        }

        private void axWindowsMediaPlayer1_MouseUpEvent(object sender, AxWMPLib._WMPOCXEvents_MouseUpEvent e)
        {
            if (!previewMode)
                Application.Exit();

        }

        private void axWindowsMediaPlayer1_KeyPressEvent(object sender, AxWMPLib._WMPOCXEvents_KeyPressEvent e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private void axWindowsMediaPlayer1_CurrentMediaItemAvailable(object sender, AxWMPLib._WMPOCXEvents_CurrentMediaItemAvailableEvent e)
        {
        }

        private void axWindowsMediaPlayer1_EndOfStream(object sender, AxWMPLib._WMPOCXEvents_EndOfStreamEvent e)
        {
            newVideoLoaded = true;
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = 0;
        }

        private void axWindowsMediaPlayer1_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            if (newVideoLoaded)
            {
                if (config.StartAtRandomLocation)
                {
                    double lengthOfVideo = axWindowsMediaPlayer1.currentMedia.duration;
                    int retries = 0;
                    while (lengthOfVideo == 0.0)
                    {
                        System.Threading.Thread.Sleep(200);
                        lengthOfVideo = axWindowsMediaPlayer1.currentMedia.duration;
                        retries++;
                        if (retries > 10)
                        {
                            break;
                        }
                    }

                    if (lengthOfVideo > 0.0)
                    {
                        lengthOfVideo *= 0.99;

                        int position = rnd.Next(0, (int)lengthOfVideo);

                        axWindowsMediaPlayer1.Ctlcontrols.currentPosition = position;
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                        newVideoLoaded = false;
                    }
                }
            }

        }

        private void axWindowsMediaPlayer1_NewStream(object sender, EventArgs e)
        {
            double lengthOfVideo = axWindowsMediaPlayer1.currentMedia.duration;

        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                nextVideoTimer.Interval = 100;
                nextVideoTimer.Enabled = true;
                nextVideoTimer.Start();
            }
        }
    }
}
