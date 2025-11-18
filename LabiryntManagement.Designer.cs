using System.Resources;

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
            labelCellSize = new Label();
            labelCoresNumber = new Label();
            comboBoxWidth = new ComboBox();
            comboBoxHeight = new ComboBox();
            comboBoxCellSize = new ComboBox();
            comboBoxCoresNumber = new ComboBox();
            buttonSaveLabyrinth = new Button();
            buttonSolveLabyrinth = new Button();
            buttonCreateLabyrinth = new Button();
            buttonSaveSolvedLabyrinth = new Button();
            saveFileDialog1 = new SaveFileDialog();
            pictureBoxCentral = new PictureBox();
            pictureBoxBackground = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCentral).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackground).BeginInit();
            SuspendLayout();
            // 
            // labelWidth
            // 
            labelWidth.BorderStyle = BorderStyle.FixedSingle;
            labelWidth.Location = new Point(15, 40);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(65, 23);
            labelWidth.TabIndex = 1;
            labelWidth.Text = "Szerokość:";
            labelWidth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelHeight
            // 
            labelHeight.BorderStyle = BorderStyle.FixedSingle;
            labelHeight.Location = new Point(15, 5);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(65, 23);
            labelHeight.TabIndex = 0;
            labelHeight.Text = "Wysokość:";
            labelHeight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCellSize
            // 
            labelCellSize.BorderStyle = BorderStyle.FixedSingle;
            labelCellSize.Location = new Point(215, 5);
            labelCellSize.Name = "labelCellSize";
            labelCellSize.Size = new Size(120, 23);
            labelCellSize.TabIndex = 0;
            labelCellSize.Text = "Wielkość komórek:";
            labelCellSize.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCoresNumber
            // 
            labelCoresNumber.BorderStyle = BorderStyle.FixedSingle;
            labelCoresNumber.Location = new Point(215, 40);
            labelCoresNumber.Name = "labelCoresNumber";
            labelCoresNumber.Size = new Size(120, 23);
            labelCoresNumber.TabIndex = 22;
            labelCoresNumber.Text = "Ilość użytych rdzeni:";
            labelCoresNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxWidth
            // 
            comboBoxWidth.FormattingEnabled = true;
            comboBoxWidth.Location = new Point(85, 40);
            comboBoxWidth.Name = "comboBoxWidth";
            comboBoxWidth.Size = new Size(120, 23);
            comboBoxWidth.TabIndex = 3;
            comboBoxWidth.SelectedIndexChanged += comboBoxWidth_SelectedIndexChanged;
            // 
            // comboBoxHeight
            // 
            comboBoxHeight.DisplayMember = "5";
            comboBoxHeight.FormattingEnabled = true;
            comboBoxHeight.Location = new Point(85, 5);
            comboBoxHeight.Name = "comboBoxHeight";
            comboBoxHeight.Size = new Size(120, 23);
            comboBoxHeight.TabIndex = 2;
            comboBoxHeight.ValueMember = "5";
            comboBoxHeight.SelectedIndexChanged += comboBoxHeight_SelectedIndexChanged;
            // 
            // comboBoxCellSize
            // 
            comboBoxCellSize.FormattingEnabled = true;
            comboBoxCellSize.Location = new Point(340, 5);
            comboBoxCellSize.Name = "comboBoxCellSize";
            comboBoxCellSize.Size = new Size(120, 23);
            comboBoxCellSize.TabIndex = 23;
            comboBoxCellSize.SelectedIndexChanged += comboBoxCellSize_SelectedIndexChanged;
            // 
            // comboBoxCoresNumber
            // 
            comboBoxCoresNumber.FormattingEnabled = true;
            comboBoxCoresNumber.Location = new Point(340, 40);
            comboBoxCoresNumber.Name = "comboBoxCoresNumber";
            comboBoxCoresNumber.Size = new Size(120, 23);
            comboBoxCoresNumber.TabIndex = 24;
            comboBoxCoresNumber.SelectedIndexChanged += comboBoxCoresNumber_SelectedIndexChanged;
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
            // buttonCreateLabyrinth
            // 
            buttonCreateLabyrinth.Location = new Point(470, 5);
            buttonCreateLabyrinth.Name = "buttonCreateLabyrinth";
            buttonCreateLabyrinth.Size = new Size(100, 23);
            buttonCreateLabyrinth.TabIndex = 25;
            buttonCreateLabyrinth.Text = "Stwórz labirynt";
            buttonCreateLabyrinth.UseVisualStyleBackColor = true;
            buttonCreateLabyrinth.Click += buttonCreateLabyrinth_Click;
            // 
            // buttonSolveLabyrinth
            // 
            buttonSolveLabyrinth.Location = new Point(470, 40);
            buttonSolveLabyrinth.Name = "buttonSolveLabyrinth";
            buttonSolveLabyrinth.Size = new Size(100, 23);
            buttonSolveLabyrinth.TabIndex = 26;
            buttonSolveLabyrinth.Text = "Rozwiąż labirynt";
            buttonSolveLabyrinth.UseVisualStyleBackColor = true;
            buttonSolveLabyrinth.Click += buttonSolveLabyrinth_Click;
            // 
            // buttonSaveLabyrinth
            // 
            buttonSaveLabyrinth.Location = new Point(580, 5);
            buttonSaveLabyrinth.Name = "buttonSaveLabyrinth";
            buttonSaveLabyrinth.Size = new Size(160, 23);
            buttonSaveLabyrinth.TabIndex = 27;
            buttonSaveLabyrinth.Text = "Zapisz labirynt";
            buttonSaveLabyrinth.UseVisualStyleBackColor = true;
            buttonSaveLabyrinth.Click += buttonSaveLabyrinth_Click;
            // 
            // buttonSaveSolvedLabyrinth
            // 
            buttonSaveSolvedLabyrinth.Location = new Point(580, 40);
            buttonSaveSolvedLabyrinth.Name = "buttonSaveSolvedLabyrinth";
            buttonSaveSolvedLabyrinth.Size = new Size(160, 23);
            buttonSaveSolvedLabyrinth.TabIndex = 28;
            buttonSaveSolvedLabyrinth.Text = "Zapisz rozwiazany labirynt";
            buttonSaveSolvedLabyrinth.UseVisualStyleBackColor = true;
            buttonSaveSolvedLabyrinth.Click += buttonSaveSolvedLabyrinth_Click;
            // 
            // LabiryntManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(buttonSaveSolvedLabyrinth);
            Controls.Add(buttonSaveLabyrinth);
            Controls.Add(buttonSolveLabyrinth);
            Controls.Add(buttonCreateLabyrinth);
            Controls.Add(comboBoxCoresNumber);
            Controls.Add(comboBoxCellSize);
            Controls.Add(labelCoresNumber);
            Controls.Add(labelCellSize);
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
        }

        #endregion

        private Label labelWidth;
        private Label labelHeight;
        private Label labelCellSize;
        private Label labelCoresNumber;

        private ComboBox comboBoxWidth;
        private ComboBox comboBoxHeight;
        private ComboBox comboBoxCellSize;
        private ComboBox comboBoxCoresNumber;

        private PictureBox pictureBoxCentral;
        private PictureBox pictureBoxBackground;

        private Button buttonSaveLabyrinth;
        private Button buttonSolveLabyrinth;
        private Button buttonCreateLabyrinth;
        private Button buttonSaveSolvedLabyrinth;

        private SaveFileDialog saveFileDialog1;
    }
}
