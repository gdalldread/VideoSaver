using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace VideoSaver
{
    public partial class SettingsForm : Form
    {
        private Configuration config = Configuration.Load();

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void SaveSettings()
        {
            config.VideoFolder = maskedTextBoxVideoFolder.Text;
            config.PlayInRandomOrder = checkBoxPlayInRandomOrder.Checked;
            config.StartAtRandomLocation = checkBoxStartAtRandomLocation.Checked;
            config.TimeToNextVideo = (int)numericUpDownSecondsUntilNextClip.Value;
            config.JumpToNextVideoAfterTime = checkBoxStartNextVideoAfterTime.Checked;
            config.Save();
        }

        private void LoadSettings()
        {
            maskedTextBoxVideoFolder.Text = config.VideoFolder;
            checkBoxPlayInRandomOrder.Checked = config.PlayInRandomOrder;
            checkBoxStartAtRandomLocation.Checked = config.StartAtRandomLocation;
            numericUpDownSecondsUntilNextClip.Value = config.TimeToNextVideo;
            checkBoxStartNextVideoAfterTime.Checked = config.JumpToNextVideoAfterTime;
            labelSeconds.Enabled = checkBoxStartNextVideoAfterTime.Checked;
            numericUpDownSecondsUntilNextClip.Enabled = checkBoxStartNextVideoAfterTime.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = maskedTextBoxVideoFolder.Text;
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.Description = "Select the folder with video files you wish to include in the screen saver.";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                maskedTextBoxVideoFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void checkBoxStartNextVideoAfterTime_CheckedChanged(object sender, EventArgs e)
        {
            labelSeconds.Enabled = checkBoxStartNextVideoAfterTime.Checked;
            numericUpDownSecondsUntilNextClip.Enabled = checkBoxStartNextVideoAfterTime.Checked;
        }


    }
}
