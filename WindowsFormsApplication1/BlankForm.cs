using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoSaver
{
    public partial class BlankForm : Form
    {
        public BlankForm()
        {
            InitializeComponent();
        }

        Rectangle bounds;

        public BlankForm(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
            bounds = Bounds;
        }

        private void BlankForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
            SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
         }

        private Point mouseLocation;

        private void BlankForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                    Math.Abs(mouseLocation.Y - e.Y) > 5)
                {
                    Application.Exit();
                }
            }

            // Update current mouse location
            mouseLocation = e.Location;

        }

        private void BlankForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();

        }

        private void BlankForm_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

    }
}
