namespace WMPToolBox
{
    partial class MainForm
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
            this.Backup = new System.Windows.Forms.Button();
            this.Restore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Backup
            // 
            this.Backup.Location = new System.Drawing.Point(15, 54);
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(257, 55);
            this.Backup.TabIndex = 0;
            this.Backup.Text = "Backup Library to XML";
            this.Backup.UseVisualStyleBackColor = true;
            this.Backup.Click += new System.EventHandler(this.Backup_Click);
            // 
            // Restore
            // 
            this.Restore.Location = new System.Drawing.Point(15, 150);
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(257, 55);
            this.Restore.TabIndex = 1;
            this.Restore.Text = "Restore Library From XML";
            this.Restore.UseVisualStyleBackColor = true;
            this.Restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Restore);
            this.Controls.Add(this.Backup);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "WMP Library Tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Backup;
        private System.Windows.Forms.Button Restore;
    }
}

