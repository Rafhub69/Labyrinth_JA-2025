namespace finalProjectJA_2025
{
    partial class LabiryntManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabiryntManagement));
            labelWidth = new Label();
            labelHeight = new Label();
            comboBoxWidth = new ComboBox();
            comboBoxHeight = new ComboBox();
            pictureBoxCentral = new PictureBox();
            pictureBoxBackground = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCentral).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackground).BeginInit();
            SuspendLayout();
            // 
            // labelWidth
            // 
            labelWidth.AutoSize = true;
            labelWidth.BorderStyle = BorderStyle.FixedSingle;
            labelWidth.Location = new Point(12, 40);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(64, 17);
            labelWidth.TabIndex = 1;
            labelWidth.Text = "Szerokość:";
            // 
            // labelHeight
            // 
            labelHeight.AutoSize = true;
            labelHeight.BorderStyle = BorderStyle.FixedSingle;
            labelHeight.Location = new Point(12, 5);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(65, 17);
            labelHeight.TabIndex = 0;
            labelHeight.Text = "Wysokość:";
            // 
            // comboBoxWidth
            // 
            comboBoxWidth.FormattingEnabled = true;
            comboBoxWidth.Location = new Point(80, 40);
            comboBoxWidth.Name = "comboBoxWidth";
            comboBoxWidth.Size = new Size(121, 23);
            comboBoxWidth.TabIndex = 3;
            // 
            // comboBoxHeight
            // 
            comboBoxHeight.DisplayMember = "5";
            comboBoxHeight.FormattingEnabled = true;
            comboBoxHeight.Location = new Point(81, 5);
            comboBoxHeight.Name = "comboBoxHeight";
            comboBoxHeight.Size = new Size(121, 23);
            comboBoxHeight.TabIndex = 2;
            comboBoxHeight.ValueMember = "5";
            // 
            // pictureBoxCentral
            // 
            pictureBoxCentral.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxCentral.BackColor = SystemColors.Control;
            pictureBoxCentral.Cursor = Cursors.Cross;
            pictureBoxCentral.Location = new Point(10, 70);
            pictureBoxCentral.Name = "pictureBoxCentral";
            pictureBoxCentral.Size = new Size(1880, 960);
            pictureBoxCentral.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxCentral.TabIndex = 6;
            pictureBoxCentral.TabStop = false;
            // 
            // pictureBoxBackground
            // 
            pictureBoxBackground.BackColor = SystemColors.ActiveCaption;
            pictureBoxBackground.Location = new Point(10, 0);
            pictureBoxBackground.Name = "pictureBoxBackground";
            pictureBoxBackground.Size = new Size(1880, 70);
            pictureBoxBackground.TabIndex = 21;
            pictureBoxBackground.TabStop = false;
            // 
            // LabiryntManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(comboBoxWidth);
            Controls.Add(comboBoxHeight);
            Controls.Add(labelWidth);
            Controls.Add(labelHeight);
            Controls.Add(pictureBoxBackground);
            Controls.Add(pictureBoxCentral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LabiryntManagement";
            Text = "Labirynt";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCentral).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWidth;
        private Label labelHeight;

        private ComboBox comboBoxWidth;
        private ComboBox comboBoxHeight;

        private PictureBox pictureBoxCentral;
        private PictureBox pictureBoxBackground;
    }
}
