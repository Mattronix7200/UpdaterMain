namespace UpdaterMain
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            downStatus = new Label();
            progressBar1 = new ProgressBar();
            labelPercentage = new Label();
            Cancel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(275, 19);
            label1.TabIndex = 1;
            label1.Text = "Sprawdzanie aktualizacji programu ...";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.updater;
            pictureBox1.Location = new Point(12, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(310, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // downStatus
            // 
            downStatus.AutoSize = true;
            downStatus.Location = new Point(12, 130);
            downStatus.Name = "downStatus";
            downStatus.Size = new Size(72, 15);
            downStatus.TabIndex = 13;
            downStatus.Text = "Pobieranie...";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 168);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(253, 23);
            progressBar1.TabIndex = 14;
            // 
            // labelPercentage
            // 
            labelPercentage.AutoSize = true;
            labelPercentage.Location = new Point(271, 130);
            labelPercentage.Name = "labelPercentage";
            labelPercentage.Size = new Size(0, 15);
            labelPercentage.TabIndex = 15;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(271, 168);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(55, 23);
            Cancel.TabIndex = 16;
            Cancel.Text = "Anuluj";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(334, 211);
            ControlBox = false;
            Controls.Add(Cancel);
            Controls.Add(labelPercentage);
            Controls.Add(progressBar1);
            Controls.Add(downStatus);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(350, 250);
            MinimizeBox = false;
            MinimumSize = new Size(350, 250);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YouTube Downloader- Updater";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private PictureBox pictureBox1;
        private Label downStatus;
        private ProgressBar progressBar1;
        private Label labelPercentage;
        private Button Cancel;
    }
}
