using System.Diagnostics;
using System.Windows.Forms;

namespace finalProjectJA_2025
{
    public partial class LabiryntManagement : Form
    {
        private int[] intCellSize = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];

        private int[] intTableSize = new int[255];

        private bool createOrSolveLabirynth = true;

        private int maxCoreNumber;

        private Labirynt solvedLabirynth;

        private Labirynt createdlabirynth;

        private Bitmap image;

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

            for (int i = 0; i < intTableSize.Length; i++)
            {
                intTableSize[i] = i + 1;
            }

            createdlabirynth = new Labirynt();
            solvedLabirynth = new Labirynt();

            for (int i = 0; i < intTableSize.Length; i++)
            {
                comboBoxWidth.Items.Add(intTableSize.GetValue(i).ToString());
                comboBoxHeight.Items.Add(intTableSize.GetValue(i).ToString());
            }

            comboBoxHeight.Text = intTableSize[4].ToString();
            comboBoxWidth.Text = intTableSize[4].ToString();

            comboBoxCellSize.Text = intCellSize[4].ToString();
            comboBoxCoresNumber.Text = "1";

            SetMyImageId(saveFileDialog1);
        }

        private void SetSizeComboBox()
        {
            Size maxCellNumber = createdlabirynth.getMaxTableSizeValues(pictureBoxCentral.Size);
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

            createdlabirynth.changeMaze(newSize);
            solvedLabirynth.changeMaze(newSize);

            comboBoxHeight.Text = intTableSize[maxCellNumber.Height - 2].ToString();
            comboBoxWidth.Text = intTableSize[maxCellNumber.Width - 2].ToString();
        }

        private void setNewLabirynthSize()
        {
            int indexWidth = comboBoxWidth.SelectedIndex > 0 ? comboBoxWidth.SelectedIndex : 1;
            int indexHeight = comboBoxHeight.SelectedIndex > 0 ? comboBoxHeight.SelectedIndex : 1;
            int indexCellSize = comboBoxCellSize.SelectedIndex > 0 ? comboBoxCellSize.SelectedIndex : 1;

            if (createOrSolveLabirynth)
            {
                createdlabirynth = new Labirynt(intTableSize[indexWidth], intTableSize[indexHeight]);
                createdlabirynth.CellSize = new Point(intCellSize[indexCellSize], intCellSize[indexCellSize]);
            }
            else
            {
                solvedLabirynth = new Labirynt(intTableSize[indexWidth], intTableSize[indexHeight]);
                solvedLabirynth.CellSize = new Point(intCellSize[indexCellSize], intCellSize[indexCellSize]);
            }

            createdlabirynth.Name = "maze";
            solvedLabirynth.Name = "solvedMaze";

            SetMyImageId(saveFileDialog1);
        }

        private void SetMyImageId(SaveFileDialog sfd)
        {
            createdlabirynth.SetMyImageId(sfd);
            solvedLabirynth.SetMyImageId(sfd);
            //Debug.Write("\n");
        }

        private void comboBoxHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            setNewLabirynthSize();
        }

        private void comboBoxWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            setNewLabirynthSize();
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
        }

        private void comboBoxCoresNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            maxCoreNumber = comboBoxCoresNumber.SelectedIndex + 1;
        }

        private void buttonCreateLabyrinth_Click(object sender, EventArgs e)
        {
            createOrSolveLabirynth = true;
            pictureBoxCentral.Image = createdlabirynth.showLabyrinth();
        }

        private void buttonSolveLabyrinth_Click(object sender, EventArgs e)
        {
            createOrSolveLabirynth = false;
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
    }
}
