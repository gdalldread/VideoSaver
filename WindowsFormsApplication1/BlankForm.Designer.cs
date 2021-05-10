namespace VideoSaver
{
    partial class BlankForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BlankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BlankForm";
            this.Text = "BlankForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BlankForm_Load);
            this.Click += new System.EventHandler(this.BlankForm_Click);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BlankForm_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BlankForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}