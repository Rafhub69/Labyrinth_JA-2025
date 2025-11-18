using System.Diagnostics;
using System.Windows.Forms;

namespace finalProjectJA_2025
{
    public partial class LabiryntManagement : Form
    {
        private int[] intCellSize = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];

        private int[] intTableSize = new int[255];

        private string loadedLibrary = "C#";

        private string[] pictureBoxSizeMods = ["Tryb Normalny", "Tryb Rozci¹gniêcia", "Tryb Wycentrowania", "Tryb Powiêkszenia"];

        private bool createOrSolveLabirynth = true;

        private int maxCoreNumber;

        private Labirynt solvedLabirynth;

        private Labirynt createdlabirynth;

        private Bitmap image;

        private Point imageNumber;

        public LabiryntManagement()
        {
            InitializeComponent();

            for (int i = 0; i < intCellSize.Length; i++)
            {
                comboBoxCellSize.Items.Add(intCellSize.GetValue(i));
            }

            maxCoreNumber = 1;

            for (int i = 1; i < 65; i++)
            {
                comboBoxCoresNumber.Items.Add(i);
            }

            for (int i = 0; i < pictureBoxSizeMods.GetLength(0); i++)
            {
                comboBoxSizeMode.Items.Add(pictureBoxSizeMods[i]);
            }

            for (int i = 0; i < intTableSize.Length; i++)
            {
                intTableSize[i] = i + 1;
            }

            createdlabirynth = new Labirynt(intCellSize[0], "maze");
            solvedLabirynth = new Labirynt(intCellSize[0], "solvedMaze");

            int totalWidth = solvedLabirynth.LabiryntSize.X * solvedLabirynth.CellSize.X;
            int totalHeight = solvedLabirynth.LabiryntSize.Y * solvedLabirynth.CellSize.Y;

            image = new Bitmap(totalWidth, totalHeight);
            pictureBoxCentral.Image = image;

            comboBoxCellSize.Text = intCellSize[4].ToString();

            comboBoxHeight.Text = intTableSize[4].ToString();
            comboBoxWidth.Text = intTableSize[4].ToString();

            comboBoxSizeMode.Text = pictureBoxSizeMods[2].ToString();
            comboBoxCoresNumber.Text = "1";

            radioButtonCreatingLabiryth.Checked = true;
            radioButtonLibraryCHash.Checked = true;

            SetSizeComboBox();

            SetMyImageId(saveFileDialog1);

            imageNumber = new Point(createdlabirynth.MyImageId, solvedLabirynth.MyImageId);
        }

        public void setControlsCoordinates()
        {
            //labelWidth
            //labelHeight
            //labelLibrary
            //labelCellSize
            //labelCoresNumber
            //labelLabirynthChoice
            //comboBoxWidth
            //comboBoxHeight
            //comboBoxCellSize
            //comboBoxCoresNumber
            //buttonSaveLabyrinth
            //buttonSolveLabyrinth
            //buttonCreateLabyrinth
            //buttonSaveSolvedLabyrinth
            //saveFileDialog1
            //pictureBoxCentral
            //pictureBoxBackground
        }

        private void SetSizeComboBox()
        {
            Size maxCellNumber = new Size(-1, -1);

            if (createOrSolveLabirynth)
            {
                maxCellNumber = createdlabirynth.getMaxTableSizeValues(pictureBoxCentral.Size);
            }
            else
            {
                maxCellNumber = solvedLabirynth.getMaxTableSizeValues(pictureBoxCentral.Size);
            }

            comboBoxHeight.Items.Clear();
            comboBoxWidth.Items.Clear();

            for (int i = 0; i < intTableSize.Length; i++)
            {

                if (intTableSize.GetValue(i).ToString() != "0")
                {
                    if ((int)intTableSize.GetValue(i) < maxCellNumber.Width)
                    {
                        comboBoxWidth.Items.Add(intTableSize.GetValue(i).ToString());
                    }

                    if ((int)intTableSize.GetValue(i) < maxCellNumber.Height)
                    {
                        comboBoxHeight.Items.Add(intTableSize.GetValue(i).ToString());
                    }
                }
            }

            Point newSize = new Point(intTableSize[maxCellNumber.Width - 2], intTableSize[maxCellNumber.Height - 2]);

            int indexWidth = comboBoxWidth.SelectedIndex > 0 ? comboBoxWidth.SelectedIndex : 0;
            int indexHeight = comboBoxHeight.SelectedIndex > 0 ? comboBoxHeight.SelectedIndex : 0;

            comboBoxWidth.SelectedItem = intTableSize[indexWidth];
            comboBoxHeight.SelectedItem = intTableSize[indexHeight];

            createdlabirynth.changeMaze(newSize);
            solvedLabirynth.changeMaze(newSize);

        }

        private void setNewLabirynthSize()
        {
            int indexWidth = comboBoxWidth.SelectedIndex > 0 ? comboBoxWidth.SelectedIndex : 0;
            int indexHeight = comboBoxHeight.SelectedIndex > 0 ? comboBoxHeight.SelectedIndex : 0;
            int indexCellSize = comboBoxCellSize.SelectedIndex > 0 ? comboBoxCellSize.SelectedIndex : 0;

            Debug.Write("1. indexWidth: " + intTableSize[indexWidth] + " indexHeight: " + intTableSize[indexHeight] + " indexCellSize: " + intCellSize[indexCellSize] + "\n");

            if (createOrSolveLabirynth)
            {
                createdlabirynth = new Labirynt(intTableSize[indexWidth], intTableSize[indexHeight], "maze");
                createdlabirynth.CellSize = new Point(intCellSize[indexCellSize], intCellSize[indexCellSize]);
                createdlabirynth.MyImageId = imageNumber.X;
            }
            else
            {
                solvedLabirynth = new Labirynt(intTableSize[indexWidth], intTableSize[indexHeight], "solvedMaze");
                solvedLabirynth.CellSize = new Point(intCellSize[indexCellSize], intCellSize[indexCellSize]);
                solvedLabirynth.MyImageId = imageNumber.Y;
            }
        }

        private void SetMyImageId(SaveFileDialog sfd)
        {
            createdlabirynth.SetMyImageId(sfd);
            solvedLabirynth.SetMyImageId(sfd);
            //Debug.Write("\n");
        }

        private void CreateLabyrinth()
        {

        }

        private void CreateLabyrinthC()
        {

        }

        private void CreateLabyrinthAssembler()
        {

        }

        private void SolveLabyrinth()
        {

        }

        private void SolveLabyrinthC()
        {

        }

        private void SolveLabyrinthAssembler()
        {

        }

        private void comboBoxHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            setNewLabirynthSize();

            pictureBoxCentral.Image = createOrSolveLabirynth ? createdlabirynth.showLabyrinth() : solvedLabirynth.showLabyrinth();
        }

        private void comboBoxWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            setNewLabirynthSize();

            pictureBoxCentral.Image = createOrSolveLabirynth ? createdlabirynth.showLabyrinth() : solvedLabirynth.showLabyrinth();
        }

        private void comboBoxCellSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (createOrSolveLabirynth)
            {
                createdlabirynth.CellSize = new Point(intCellSize[comboBoxCellSize.SelectedIndex], intCellSize[comboBoxCellSize.SelectedIndex]);
                SetSizeComboBox();
                pictureBoxCentral.Image = createdlabirynth.showLabyrinth();
            }
            else
            {
                solvedLabirynth.CellSize = new Point(intCellSize[comboBoxCellSize.SelectedIndex], intCellSize[comboBoxCellSize.SelectedIndex]);
                SetSizeComboBox();

                pictureBoxCentral.Image = solvedLabirynth.showLabyrinth();
            }

            int indexHeight = comboBoxHeight.SelectedIndex > 0 ? comboBoxHeight.SelectedIndex : 0;
            int indexWidth = comboBoxWidth.SelectedIndex > 0 ? comboBoxWidth.SelectedIndex : 0;

            comboBoxHeight.Text = intTableSize[indexHeight].ToString();
            comboBoxWidth.Text = intTableSize[indexWidth].ToString();
        }

        private void comboBoxCoresNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            maxCoreNumber = comboBoxCoresNumber.SelectedIndex + 1;
        }

        private void buttonCreateLabyrinth_Click(object sender, EventArgs e)
        {
            createOrSolveLabirynth = true;
            radioButtonCreatingLabiryth.Checked = true;

            if (loadedLibrary == "C#")
            {
                CreateLabyrinth();
            }
            else if (loadedLibrary == "C++")
            {
                CreateLabyrinthC();
            }
            else if (loadedLibrary == "Assembler")
            {
                CreateLabyrinthAssembler();
            }

            pictureBoxCentral.Image = createdlabirynth.showLabyrinth();
        }

        private void buttonSolveLabyrinth_Click(object sender, EventArgs e)
        {
            createOrSolveLabirynth = false;
            radioButtonSolvingLabiryth.Checked = true;

            if (loadedLibrary == "C#")
            {
                SolveLabyrinth();
            }
            else if (loadedLibrary == "C++")
            {
                SolveLabyrinthC();
            }
            else if (loadedLibrary == "Assembler")
            {
                SolveLabyrinthAssembler();
            }

            pictureBoxCentral.Image = solvedLabirynth.showLabyrinth();
        }

        private void buttonSaveLabyrinth_Click(object sender, EventArgs e)
        {
            solvedLabirynth.SaveMaze(saveFileDialog1, pictureBoxCentral.Image);
        }

        private void buttonSaveSolvedLabyrinth_Click(object sender, EventArgs e)
        {
            createdlabirynth.SaveMaze(saveFileDialog1, pictureBoxCentral.Image);
        }

        private void radioButtonCreatingLabiryth_CheckedChanged(object sender, EventArgs e)
        {
            createOrSolveLabirynth = radioButtonCreatingLabiryth.Checked;

            pictureBoxCentral.Image = createdlabirynth.showLabyrinth();
        }

        private void radioButtonSolvingLabiryth_CheckedChanged(object sender, EventArgs e)
        {
            createOrSolveLabirynth = !radioButtonSolvingLabiryth.Checked;

            pictureBoxCentral.Image = solvedLabirynth.showLabyrinth();
        }

        private void radioButtonLibraryAssembler_CheckedChanged(object sender, EventArgs e)
        {
            loadedLibrary = "Assembler";
        }

        private void radioButtonLibraryCplus_CheckedChanged(object sender, EventArgs e)
        {
            loadedLibrary = "C++";
        }

        private void radioButtonLibraryCHash_CheckedChanged(object sender, EventArgs e)
        {
            loadedLibrary = "C#";
        }

        private void buttonResetLabyrinth_Click(object sender, EventArgs e)
        {
            int indexWidth = comboBoxWidth.SelectedIndex > 0 ? comboBoxWidth.SelectedIndex : 3;
            int indexHeight = comboBoxHeight.SelectedIndex > 0 ? comboBoxHeight.SelectedIndex : 3;
            int indexCellSize = comboBoxCellSize.SelectedIndex > 0 ? comboBoxCellSize.SelectedIndex : 3;

            createdlabirynth.Reset(intCellSize[indexCellSize], intTableSize[indexWidth], intTableSize[indexHeight]);
            solvedLabirynth.Reset(intCellSize[indexCellSize], intTableSize[indexWidth], intTableSize[indexHeight]);

            pictureBoxCentral.Image = createOrSolveLabirynth ? createdlabirynth.showLabyrinth() : solvedLabirynth.showLabyrinth();
        }

        private void comboBoxSizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pictureBoxCentral == null)
            {
                return;
            }

            int index = comboBoxSizeMode.SelectedIndex;

            if (index == 0)
            {
                pictureBoxCentral.SizeMode = PictureBoxSizeMode.Normal;
            }
            else if (index == 1)
            {
                pictureBoxCentral.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (index == 2)
            {
                pictureBoxCentral.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else if (index == 3)
            {
                pictureBoxCentral.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void pictureBoxCentral_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (createOrSolveLabirynth)
            {
                createdlabirynth.setCellCoordinates(pictureBoxCentral.SizeMode, me.Location, new Point(pictureBoxCentral.Size));
                pictureBoxCentral.Image = createdlabirynth.showLabyrinth();
            }
            else
            {
                solvedLabirynth.setCellCoordinates(pictureBoxCentral.SizeMode, me.Location, new Point(pictureBoxCentral.Size));
                pictureBoxCentral.Image = solvedLabirynth.showLabyrinth();
            }
        }
    }
}
