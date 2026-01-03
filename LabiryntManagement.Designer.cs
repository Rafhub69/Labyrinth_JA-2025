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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabiryntManagement));
            labelWidth = new Label();
            labelHeight = new Label();
            labelLibrary = new Label();
            labelCellSize = new Label();
            labelTimeSolved = new Label();
            labelCoresNumber = new Label();
            labelTimeCreation = new Label();
            comboBoxWidth = new ComboBox();
            comboBoxHeight = new ComboBox();
            comboBoxCellSize = new ComboBox();
            comboBoxSizeMode = new ComboBox();
            comboBoxCoresNumber = new ComboBox();
            buttonSaveLabyrinth = new Button();
            buttonSolveLabyrinth = new Button();
            buttonResetLabyrinth = new Button();
            buttonCreateLabyrinth = new Button();
            saveFileDialog1 = new SaveFileDialog();
            pictureBoxCentral = new PictureBox();
            pictureBoxBackground = new PictureBox();
            timerCreatingAndSolving = new System.Windows.Forms.Timer(components);
            labelSizeMode = new Label();
            comboBoxLibrary = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCentral).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackground).BeginInit();
            SuspendLayout();
            // 
            // labelWidth
            // 
            labelWidth.BorderStyle = BorderStyle.FixedSingle;
            labelWidth.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelWidth.Location = new Point(15, 40);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(70, 23);
            labelWidth.TabIndex = 1;
            labelWidth.Text = "Szerokość:";
            labelWidth.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelHeight
            // 
            labelHeight.BorderStyle = BorderStyle.FixedSingle;
            labelHeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelHeight.Location = new Point(15, 5);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(70, 23);
            labelHeight.TabIndex = 0;
            labelHeight.Text = "Wysokość:";
            labelHeight.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelLibrary
            // 
            labelLibrary.BorderStyle = BorderStyle.FixedSingle;
            labelLibrary.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLibrary.Location = new Point(560, 40);
            labelLibrary.Name = "labelLibrary";
            labelLibrary.Size = new Size(180, 23);
            labelLibrary.TabIndex = 30;
            labelLibrary.Text = "Wybierz aktualną bibliotekę:";
            labelLibrary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCellSize
            // 
            labelCellSize.BorderStyle = BorderStyle.FixedSingle;
            labelCellSize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCellSize.Location = new Point(150, 5);
            labelCellSize.Name = "labelCellSize";
            labelCellSize.Size = new Size(125, 23);
            labelCellSize.TabIndex = 0;
            labelCellSize.Text = "Wielkość komórek:";
            labelCellSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTimeSolved
            // 
            labelTimeSolved.BorderStyle = BorderStyle.FixedSingle;
            labelTimeSolved.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTimeSolved.Location = new Point(885, 40);
            labelTimeSolved.Name = "labelTimeSolved";
            labelTimeSolved.Size = new Size(210, 23);
            labelTimeSolved.TabIndex = 41;
            labelTimeSolved.Text = "Czas rozwiązania labiryntu: 0 ";
            labelTimeSolved.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCoresNumber
            // 
            labelCoresNumber.BorderStyle = BorderStyle.FixedSingle;
            labelCoresNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCoresNumber.Location = new Point(150, 40);
            labelCoresNumber.Name = "labelCoresNumber";
            labelCoresNumber.Size = new Size(125, 23);
            labelCoresNumber.TabIndex = 22;
            labelCoresNumber.Text = "Ilość użytych rdzeni:";
            labelCoresNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTimeCreation
            // 
            labelTimeCreation.BorderStyle = BorderStyle.FixedSingle;
            labelTimeCreation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTimeCreation.Location = new Point(885, 5);
            labelTimeCreation.Name = "labelTimeCreation";
            labelTimeCreation.Size = new Size(210, 23);
            labelTimeCreation.TabIndex = 40;
            labelTimeCreation.Text = "Czas stworzenia labiryntu: 0";
            labelTimeCreation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxWidth
            // 
            comboBoxWidth.FormattingEnabled = true;
            comboBoxWidth.Location = new Point(90, 40);
            comboBoxWidth.Name = "comboBoxWidth";
            comboBoxWidth.Size = new Size(50, 23);
            comboBoxWidth.TabIndex = 3;
            comboBoxWidth.SelectedIndexChanged += comboBoxWidth_SelectedIndexChanged;
            // 
            // comboBoxHeight
            // 
            comboBoxHeight.FormattingEnabled = true;
            comboBoxHeight.Location = new Point(90, 5);
            comboBoxHeight.Name = "comboBoxHeight";
            comboBoxHeight.Size = new Size(50, 23);
            comboBoxHeight.TabIndex = 2;
            comboBoxHeight.SelectedIndexChanged += comboBoxHeight_SelectedIndexChanged;
            // 
            // comboBoxCellSize
            // 
            comboBoxCellSize.FormattingEnabled = true;
            comboBoxCellSize.Location = new Point(280, 5);
            comboBoxCellSize.Name = "comboBoxCellSize";
            comboBoxCellSize.Size = new Size(50, 23);
            comboBoxCellSize.TabIndex = 23;
            comboBoxCellSize.SelectedIndexChanged += comboBoxCellSize_SelectedIndexChanged;
            // 
            // comboBoxSizeMode
            // 
            comboBoxSizeMode.FormattingEnabled = true;
            comboBoxSizeMode.Location = new Point(745, 5);
            comboBoxSizeMode.Name = "comboBoxSizeMode";
            comboBoxSizeMode.Size = new Size(130, 23);
            comboBoxSizeMode.TabIndex = 39;
            comboBoxSizeMode.SelectedIndexChanged += comboBoxSizeMode_SelectedIndexChanged;
            // 
            // comboBoxCoresNumber
            // 
            comboBoxCoresNumber.FormattingEnabled = true;
            comboBoxCoresNumber.Location = new Point(280, 40);
            comboBoxCoresNumber.Name = "comboBoxCoresNumber";
            comboBoxCoresNumber.Size = new Size(50, 23);
            comboBoxCoresNumber.TabIndex = 24;
            comboBoxCoresNumber.SelectedIndexChanged += comboBoxCoresNumber_SelectedIndexChanged;
            // 
            // buttonSaveLabyrinth
            // 
            buttonSaveLabyrinth.Location = new Point(450, 5);
            buttonSaveLabyrinth.Name = "buttonSaveLabyrinth";
            buttonSaveLabyrinth.Size = new Size(100, 23);
            buttonSaveLabyrinth.TabIndex = 27;
            buttonSaveLabyrinth.Text = "Zapisz labirynt";
            buttonSaveLabyrinth.UseVisualStyleBackColor = true;
            buttonSaveLabyrinth.Click += buttonSaveLabyrinth_Click;
            // 
            // buttonSolveLabyrinth
            // 
            buttonSolveLabyrinth.Location = new Point(340, 40);
            buttonSolveLabyrinth.Name = "buttonSolveLabyrinth";
            buttonSolveLabyrinth.Size = new Size(100, 23);
            buttonSolveLabyrinth.TabIndex = 26;
            buttonSolveLabyrinth.Text = "Rozwiąż labirynt";
            buttonSolveLabyrinth.UseVisualStyleBackColor = true;
            buttonSolveLabyrinth.Click += buttonSolveLabyrinth_Click;
            // 
            // buttonResetLabyrinth
            // 
            buttonResetLabyrinth.Location = new Point(450, 40);
            buttonResetLabyrinth.Name = "buttonResetLabyrinth";
            buttonResetLabyrinth.Size = new Size(100, 23);
            buttonResetLabyrinth.TabIndex = 38;
            buttonResetLabyrinth.Text = "Resetuj labirynt";
            buttonResetLabyrinth.UseVisualStyleBackColor = true;
            buttonResetLabyrinth.Click += buttonResetLabyrinth_Click;
            // 
            // buttonCreateLabyrinth
            // 
            buttonCreateLabyrinth.Location = new Point(340, 5);
            buttonCreateLabyrinth.Name = "buttonCreateLabyrinth";
            buttonCreateLabyrinth.Size = new Size(100, 23);
            buttonCreateLabyrinth.TabIndex = 25;
            buttonCreateLabyrinth.Text = "Stwórz labirynt";
            buttonCreateLabyrinth.UseVisualStyleBackColor = true;
            buttonCreateLabyrinth.Click += buttonCreateLabyrinth_Click;
            // 
            // pictureBoxCentral
            // 
            pictureBoxCentral.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxCentral.BackColor = SystemColors.Control;
            pictureBoxCentral.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCentral.Cursor = Cursors.Cross;
            pictureBoxCentral.Location = new Point(10, 80);
            pictureBoxCentral.Name = "pictureBoxCentral";
            pictureBoxCentral.Size = new Size(1880, 950);
            pictureBoxCentral.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxCentral.TabIndex = 6;
            pictureBoxCentral.TabStop = false;
            pictureBoxCentral.Click += pictureBoxCentral_Click;
            pictureBoxCentral.MouseDown += pictureBoxCentral_MouseDown;
            pictureBoxCentral.MouseMove += pictureBoxCentral_MouseMove;
            pictureBoxCentral.MouseUp += pictureBoxCentral_MouseUp;
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
            // labelSizeMode
            // 
            labelSizeMode.BorderStyle = BorderStyle.FixedSingle;
            labelSizeMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSizeMode.Location = new Point(560, 5);
            labelSizeMode.Name = "labelSizeMode";
            labelSizeMode.Size = new Size(180, 23);
            labelSizeMode.TabIndex = 42;
            labelSizeMode.Text = "Wybierz miejsce wyświetlania:";
            labelSizeMode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxLibrary
            // 
            comboBoxLibrary.FormattingEnabled = true;
            comboBoxLibrary.Location = new Point(745, 40);
            comboBoxLibrary.Name = "comboBoxLibrary";
            comboBoxLibrary.Size = new Size(130, 23);
            comboBoxLibrary.TabIndex = 43;
            comboBoxLibrary.SelectedIndexChanged += comboBoxLibrary_SelectedIndexChanged;
            // 
            // LabiryntManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(comboBoxLibrary);
            Controls.Add(labelSizeMode);
            Controls.Add(labelTimeSolved);
            Controls.Add(labelTimeCreation);
            Controls.Add(comboBoxSizeMode);
            Controls.Add(buttonResetLabyrinth);
            Controls.Add(labelLibrary);
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
        private Label labelLibrary;
        private Label labelSizeMode;
        private Label labelCellSize;
        private Label labelTimeSolved;
        private Label labelCoresNumber;
        private Label labelTimeCreation;

        private ComboBox comboBoxWidth;
        private ComboBox comboBoxHeight;
        private ComboBox comboBoxLibrary;
        private ComboBox comboBoxCellSize;
        private ComboBox comboBoxSizeMode;
        private ComboBox comboBoxCoresNumber;
        
        private PictureBox pictureBoxCentral;
        private PictureBox pictureBoxBackground;

        private Button buttonSaveLabyrinth;
        private Button buttonSolveLabyrinth;
        private Button buttonResetLabyrinth;
        private Button buttonCreateLabyrinth;
        
        private SaveFileDialog saveFileDialog1;

        private System.Windows.Forms.Timer timerCreatingAndSolving;
    }
}
