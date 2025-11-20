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
            labelLibrary = new Label();
            labelCellSize = new Label();
            labelCoresNumber = new Label();
            labelLabirynthChoice = new Label();
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
            radioButtonCreatingLabiryth = new RadioButton();
            radioButtonLibraryAssembler = new RadioButton();
            radioButtonSolvingLabiryth = new RadioButton();
            radioButtonLibraryCplus = new RadioButton();
            radioButtonLibraryCHash = new RadioButton();
            groupBoxLabirynthChoice = new GroupBox();
            groupBoxLibrary = new GroupBox();
            buttonResetLabyrinth = new Button();
            comboBoxSizeMode = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCentral).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackground).BeginInit();
            groupBoxLabirynthChoice.SuspendLayout();
            groupBoxLibrary.SuspendLayout();
            SuspendLayout();
            // 
            // labelWidth
            // 
            labelWidth.BorderStyle = BorderStyle.FixedSingle;
            labelWidth.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelWidth.Location = new Point(15, 40);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(75, 23);
            labelWidth.TabIndex = 1;
            labelWidth.Text = "Szerokość:";
            labelWidth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelHeight
            // 
            labelHeight.BorderStyle = BorderStyle.FixedSingle;
            labelHeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelHeight.Location = new Point(15, 5);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(75, 23);
            labelHeight.TabIndex = 0;
            labelHeight.Text = "Wysokość:";
            labelHeight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelLibrary
            // 
            labelLibrary.BorderStyle = BorderStyle.FixedSingle;
            labelLibrary.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLibrary.Location = new Point(760, 40);
            labelLibrary.Name = "labelLibrary";
            labelLibrary.Size = new Size(120, 23);
            labelLibrary.TabIndex = 30;
            labelLibrary.Text = "Wybierz bibliotekę:";
            labelLibrary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCellSize
            // 
            labelCellSize.BorderStyle = BorderStyle.FixedSingle;
            labelCellSize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCellSize.Location = new Point(225, 5);
            labelCellSize.Name = "labelCellSize";
            labelCellSize.Size = new Size(125, 23);
            labelCellSize.TabIndex = 0;
            labelCellSize.Text = "Wielkość komórek:";
            labelCellSize.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCoresNumber
            // 
            labelCoresNumber.BorderStyle = BorderStyle.FixedSingle;
            labelCoresNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCoresNumber.Location = new Point(225, 40);
            labelCoresNumber.Name = "labelCoresNumber";
            labelCoresNumber.Size = new Size(125, 23);
            labelCoresNumber.TabIndex = 22;
            labelCoresNumber.Text = "Ilość użytych rdzeni:";
            labelCoresNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelLabirynthChoice
            // 
            labelLabirynthChoice.BorderStyle = BorderStyle.FixedSingle;
            labelLabirynthChoice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLabirynthChoice.Location = new Point(760, 5);
            labelLabirynthChoice.Name = "labelLabirynthChoice";
            labelLabirynthChoice.Size = new Size(120, 23);
            labelLabirynthChoice.TabIndex = 29;
            labelLabirynthChoice.Text = "Wybierz labirynt:";
            labelLabirynthChoice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxWidth
            // 
            comboBoxWidth.FormattingEnabled = true;
            comboBoxWidth.Location = new Point(95, 40);
            comboBoxWidth.Name = "comboBoxWidth";
            comboBoxWidth.Size = new Size(120, 23);
            comboBoxWidth.TabIndex = 3;
            comboBoxWidth.SelectedIndexChanged += comboBoxWidth_SelectedIndexChanged;
            // 
            // comboBoxHeight
            // 
            comboBoxHeight.FormattingEnabled = true;
            comboBoxHeight.Location = new Point(95, 5);
            comboBoxHeight.Name = "comboBoxHeight";
            comboBoxHeight.Size = new Size(120, 23);
            comboBoxHeight.TabIndex = 2;
            comboBoxHeight.SelectedIndexChanged += comboBoxHeight_SelectedIndexChanged;
            // 
            // comboBoxCellSize
            // 
            comboBoxCellSize.FormattingEnabled = true;
            comboBoxCellSize.Location = new Point(355, 5);
            comboBoxCellSize.Name = "comboBoxCellSize";
            comboBoxCellSize.Size = new Size(120, 23);
            comboBoxCellSize.TabIndex = 23;
            comboBoxCellSize.SelectedIndexChanged += comboBoxCellSize_SelectedIndexChanged;
            // 
            // comboBoxCoresNumber
            // 
            comboBoxCoresNumber.FormattingEnabled = true;
            comboBoxCoresNumber.Location = new Point(355, 40);
            comboBoxCoresNumber.Name = "comboBoxCoresNumber";
            comboBoxCoresNumber.Size = new Size(120, 23);
            comboBoxCoresNumber.TabIndex = 24;
            comboBoxCoresNumber.SelectedIndexChanged += comboBoxCoresNumber_SelectedIndexChanged;
            // 
            // buttonSaveLabyrinth
            // 
            buttonSaveLabyrinth.Location = new Point(590, 5);
            buttonSaveLabyrinth.Name = "buttonSaveLabyrinth";
            buttonSaveLabyrinth.Size = new Size(160, 23);
            buttonSaveLabyrinth.TabIndex = 27;
            buttonSaveLabyrinth.Text = "Zapisz labirynt";
            buttonSaveLabyrinth.UseVisualStyleBackColor = true;
            buttonSaveLabyrinth.Click += buttonSaveLabyrinth_Click;
            // 
            // buttonSolveLabyrinth
            // 
            buttonSolveLabyrinth.Location = new Point(485, 40);
            buttonSolveLabyrinth.Name = "buttonSolveLabyrinth";
            buttonSolveLabyrinth.Size = new Size(100, 23);
            buttonSolveLabyrinth.TabIndex = 26;
            buttonSolveLabyrinth.Text = "Rozwiąż labirynt";
            buttonSolveLabyrinth.UseVisualStyleBackColor = true;
            buttonSolveLabyrinth.Click += buttonSolveLabyrinth_Click;
            // 
            // buttonCreateLabyrinth
            // 
            buttonCreateLabyrinth.Location = new Point(485, 5);
            buttonCreateLabyrinth.Name = "buttonCreateLabyrinth";
            buttonCreateLabyrinth.Size = new Size(100, 23);
            buttonCreateLabyrinth.TabIndex = 25;
            buttonCreateLabyrinth.Text = "Stwórz labirynt";
            buttonCreateLabyrinth.UseVisualStyleBackColor = true;
            buttonCreateLabyrinth.Click += buttonCreateLabyrinth_Click;
            // 
            // buttonSaveSolvedLabyrinth
            // 
            buttonSaveSolvedLabyrinth.Location = new Point(590, 40);
            buttonSaveSolvedLabyrinth.Name = "buttonSaveSolvedLabyrinth";
            buttonSaveSolvedLabyrinth.Size = new Size(160, 23);
            buttonSaveSolvedLabyrinth.TabIndex = 28;
            buttonSaveSolvedLabyrinth.Text = "Zapisz rozwiazany labirynt";
            buttonSaveSolvedLabyrinth.UseVisualStyleBackColor = true;
            buttonSaveSolvedLabyrinth.Click += buttonSaveSolvedLabyrinth_Click;
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
            // radioButtonCreatingLabiryth
            // 
            radioButtonCreatingLabiryth.BackColor = SystemColors.Control;
            radioButtonCreatingLabiryth.Location = new Point(0, 0);
            radioButtonCreatingLabiryth.Name = "radioButtonCreatingLabiryth";
            radioButtonCreatingLabiryth.Size = new Size(79, 23);
            radioButtonCreatingLabiryth.TabIndex = 31;
            radioButtonCreatingLabiryth.TabStop = true;
            radioButtonCreatingLabiryth.Text = "Tworzenie";
            radioButtonCreatingLabiryth.UseVisualStyleBackColor = false;
            radioButtonCreatingLabiryth.CheckedChanged += radioButtonCreatingLabiryth_CheckedChanged;
            // 
            // radioButtonLibraryAssembler
            // 
            radioButtonLibraryAssembler.BackColor = SystemColors.Control;
            radioButtonLibraryAssembler.Location = new Point(0, 0);
            radioButtonLibraryAssembler.Name = "radioButtonLibraryAssembler";
            radioButtonLibraryAssembler.Size = new Size(80, 23);
            radioButtonLibraryAssembler.TabIndex = 32;
            radioButtonLibraryAssembler.TabStop = true;
            radioButtonLibraryAssembler.Text = "Asembler";
            radioButtonLibraryAssembler.UseVisualStyleBackColor = false;
            radioButtonLibraryAssembler.CheckedChanged += radioButtonLibraryAssembler_CheckedChanged;
            // 
            // radioButtonSolvingLabiryth
            // 
            radioButtonSolvingLabiryth.BackColor = SystemColors.Control;
            radioButtonSolvingLabiryth.Location = new Point(105, 0);
            radioButtonSolvingLabiryth.Name = "radioButtonSolvingLabiryth";
            radioButtonSolvingLabiryth.Size = new Size(110, 23);
            radioButtonSolvingLabiryth.TabIndex = 33;
            radioButtonSolvingLabiryth.TabStop = true;
            radioButtonSolvingLabiryth.Text = "Rozwiązywanie";
            radioButtonSolvingLabiryth.UseVisualStyleBackColor = false;
            radioButtonSolvingLabiryth.CheckedChanged += radioButtonSolvingLabiryth_CheckedChanged;
            // 
            // radioButtonLibraryCplus
            // 
            radioButtonLibraryCplus.BackColor = SystemColors.Control;
            radioButtonLibraryCplus.Location = new Point(106, 0);
            radioButtonLibraryCplus.Name = "radioButtonLibraryCplus";
            radioButtonLibraryCplus.Size = new Size(50, 23);
            radioButtonLibraryCplus.TabIndex = 34;
            radioButtonLibraryCplus.TabStop = true;
            radioButtonLibraryCplus.Text = "C++";
            radioButtonLibraryCplus.TextAlign = ContentAlignment.MiddleCenter;
            radioButtonLibraryCplus.UseVisualStyleBackColor = false;
            radioButtonLibraryCplus.CheckedChanged += radioButtonLibraryCplus_CheckedChanged;
            // 
            // radioButtonLibraryCHash
            // 
            radioButtonLibraryCHash.BackColor = SystemColors.Control;
            radioButtonLibraryCHash.Location = new Point(175, 0);
            radioButtonLibraryCHash.Name = "radioButtonLibraryCHash";
            radioButtonLibraryCHash.Size = new Size(40, 23);
            radioButtonLibraryCHash.TabIndex = 35;
            radioButtonLibraryCHash.TabStop = true;
            radioButtonLibraryCHash.Text = "C#";
            radioButtonLibraryCHash.UseVisualStyleBackColor = false;
            radioButtonLibraryCHash.CheckedChanged += radioButtonLibraryCHash_CheckedChanged;
            // 
            // groupBoxLabirynthChoice
            // 
            groupBoxLabirynthChoice.BackColor = SystemColors.ActiveCaption;
            groupBoxLabirynthChoice.Controls.Add(radioButtonCreatingLabiryth);
            groupBoxLabirynthChoice.Controls.Add(radioButtonSolvingLabiryth);
            groupBoxLabirynthChoice.Location = new Point(885, 5);
            groupBoxLabirynthChoice.Name = "groupBoxLabirynthChoice";
            groupBoxLabirynthChoice.Size = new Size(215, 23);
            groupBoxLabirynthChoice.TabIndex = 36;
            groupBoxLabirynthChoice.TabStop = false;
            // 
            // groupBoxLibrary
            // 
            groupBoxLibrary.BackColor = SystemColors.ActiveCaption;
            groupBoxLibrary.Controls.Add(radioButtonLibraryAssembler);
            groupBoxLibrary.Controls.Add(radioButtonLibraryCHash);
            groupBoxLibrary.Controls.Add(radioButtonLibraryCplus);
            groupBoxLibrary.Location = new Point(885, 40);
            groupBoxLibrary.Name = "groupBoxLibrary";
            groupBoxLibrary.RightToLeft = RightToLeft.No;
            groupBoxLibrary.Size = new Size(215, 23);
            groupBoxLibrary.TabIndex = 37;
            groupBoxLibrary.TabStop = false;
            // 
            // buttonResetLabyrinth
            // 
            buttonResetLabyrinth.Location = new Point(1110, 5);
            buttonResetLabyrinth.Name = "buttonResetLabyrinth";
            buttonResetLabyrinth.Size = new Size(150, 23);
            buttonResetLabyrinth.TabIndex = 38;
            buttonResetLabyrinth.Text = "Resetuj labirynt";
            buttonResetLabyrinth.UseVisualStyleBackColor = true;
            buttonResetLabyrinth.Click += buttonResetLabyrinth_Click;
            // 
            // comboBoxSizeMode
            // 
            comboBoxSizeMode.FormattingEnabled = true;
            comboBoxSizeMode.Location = new Point(1110, 40);
            comboBoxSizeMode.Name = "comboBoxSizeMode";
            comboBoxSizeMode.Size = new Size(150, 23);
            comboBoxSizeMode.TabIndex = 39;
            comboBoxSizeMode.SelectedIndexChanged += comboBoxSizeMode_SelectedIndexChanged;
            // 
            // LabiryntManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(comboBoxSizeMode);
            Controls.Add(buttonResetLabyrinth);
            Controls.Add(groupBoxLibrary);
            Controls.Add(groupBoxLabirynthChoice);
            Controls.Add(labelLibrary);
            Controls.Add(labelLabirynthChoice);
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
            groupBoxLabirynthChoice.ResumeLayout(false);
            groupBoxLibrary.ResumeLayout(false);
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
        private Label labelLabirynthChoice;
        private Label labelLibrary;
        private RadioButton radioButtonCreatingLabiryth;
        private RadioButton radioButtonLibraryAssembler;
        private RadioButton radioButtonSolvingLabiryth;
        private RadioButton radioButtonLibraryCplus;
        private RadioButton radioButtonLibraryCHash;
        private GroupBox groupBoxLabirynthChoice;
        private GroupBox groupBoxLibrary;
        private Button buttonResetLabyrinth;
        private ComboBox comboBoxSizeMode;
    }
}
