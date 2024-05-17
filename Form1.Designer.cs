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
            groupBox1 = new GroupBox();
            arr5 = new Label();
            arr4 = new Label();
            arr3 = new Label();
            arr2 = new Label();
            stat2 = new Label();
            stat5 = new Label();
            stat4 = new Label();
            stat3 = new Label();
            stat1 = new Label();
            arr1 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            downStatus = new Label();
            progressBar1 = new ProgressBar();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(arr5);
            groupBox1.Controls.Add(arr4);
            groupBox1.Controls.Add(arr3);
            groupBox1.Controls.Add(arr2);
            groupBox1.Controls.Add(stat2);
            groupBox1.Controls.Add(stat5);
            groupBox1.Controls.Add(stat4);
            groupBox1.Controls.Add(stat3);
            groupBox1.Controls.Add(stat1);
            groupBox1.Controls.Add(arr1);
            groupBox1.Location = new Point(12, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 212);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // arr5
            // 
            arr5.Enabled = false;
            arr5.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            arr5.Location = new Point(16, 160);
            arr5.Name = "arr5";
            arr5.Size = new Size(35, 29);
            arr5.TabIndex = 16;
            arr5.Text = "→";
            arr5.Visible = false;
            // 
            // arr4
            // 
            arr4.Enabled = false;
            arr4.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            arr4.Location = new Point(16, 125);
            arr4.Name = "arr4";
            arr4.Size = new Size(35, 29);
            arr4.TabIndex = 15;
            arr4.Text = "→";
            arr4.Visible = false;
            // 
            // arr3
            // 
            arr3.Enabled = false;
            arr3.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            arr3.Location = new Point(16, 91);
            arr3.Name = "arr3";
            arr3.Size = new Size(35, 29);
            arr3.TabIndex = 14;
            arr3.Text = "→";
            arr3.Visible = false;
            // 
            // arr2
            // 
            arr2.Enabled = false;
            arr2.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            arr2.Location = new Point(16, 56);
            arr2.Name = "arr2";
            arr2.Size = new Size(35, 29);
            arr2.TabIndex = 13;
            arr2.Text = "→";
            arr2.Visible = false;
            // 
            // stat2
            // 
            stat2.AutoSize = true;
            stat2.Enabled = false;
            stat2.Location = new Point(53, 67);
            stat2.Name = "stat2";
            stat2.Size = new Size(187, 15);
            stat2.TabIndex = 12;
            stat2.Text = "Łączenie z serwerem aktualizacji ...";
            // 
            // stat5
            // 
            stat5.AutoSize = true;
            stat5.Enabled = false;
            stat5.Location = new Point(53, 172);
            stat5.Name = "stat5";
            stat5.Size = new Size(146, 15);
            stat5.TabIndex = 11;
            stat5.Text = "Instalowanie aktualizacji ...";
            // 
            // stat4
            // 
            stat4.AutoSize = true;
            stat4.Enabled = false;
            stat4.Location = new Point(53, 137);
            stat4.Name = "stat4";
            stat4.Size = new Size(136, 15);
            stat4.TabIndex = 10;
            stat4.Text = "Pobieranie aktualizacji ...";
            // 
            // stat3
            // 
            stat3.AutoSize = true;
            stat3.Enabled = false;
            stat3.Location = new Point(53, 102);
            stat3.Name = "stat3";
            stat3.Size = new Size(211, 15);
            stat3.TabIndex = 9;
            stat3.Text = "Sprawdzanie dostępnych aktualizacji ...";
            // 
            // stat1
            // 
            stat1.AutoSize = true;
            stat1.Location = new Point(53, 33);
            stat1.Name = "stat1";
            stat1.Size = new Size(224, 15);
            stat1.TabIndex = 8;
            stat1.Text = "Sprawdzanie połączenia internetowego ...";
            // 
            // arr1
            // 
            arr1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            arr1.Location = new Point(16, 21);
            arr1.Name = "arr1";
            arr1.Size = new Size(35, 29);
            arr1.TabIndex = 3;
            arr1.Text = "→";
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
            pictureBox1.Location = new Point(12, 249);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // downStatus
            // 
            downStatus.AutoSize = true;
            downStatus.Location = new Point(12, 341);
            downStatus.Name = "downStatus";
            downStatus.Size = new Size(72, 15);
            downStatus.TabIndex = 13;
            downStatus.Text = "Pobieranie...";
            downStatus.Visible = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 366);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(300, 23);
            progressBar1.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 401);
            ControlBox = false;
            Controls.Add(progressBar1);
            Controls.Add(downStatus);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(340, 440);
            MinimizeBox = false;
            MinimumSize = new Size(340, 440);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proszę czekać ...";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label arr5;
        private Label arr4;
        private Label arr3;
        private Label arr2;
        private Label stat2;
        private Label stat5;
        private Label stat4;
        private Label stat3;
        private Label stat1;
        private Label arr1;
        private Label downStatus;
        private ProgressBar progressBar1;
    }
}
