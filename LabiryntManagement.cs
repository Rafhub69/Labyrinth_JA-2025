using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace finalProjectJA_2025
{
    public partial class LabiryntManagement : Form
    {
        private int[] intTableSize = new int[255];

        private readonly int[] intCellSize = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];

        private readonly string[] pictureBoxSizeMods = ["Tryb Normalny", "Tryb Rozci¹gniêcia", "Tryb Wycentrowania", "Tryb Powiêkszenia"];

        private readonly string[] languagesTypes = ["C#", "C++", "Assembler"];

        private bool createOrSolveLabirynth = true;
        private bool isMouseDown = false;

        List<Point> activeCells = new List<Point>();

        private string loadedLibrary = "C#";

        private Labirynt createdlabirynth;

        private Labirynt solvedLabirynth;

        private Point imageNumber;

        private int maxCoreNumber;

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

            for (int i = 0; i < pictureBoxSizeMods.GetLength(0); i++)
            {
                comboBoxSizeMode.Items.Add(pictureBoxSizeMods[i]);
            }

            for (int i = 0; i < intTableSize.Length; i++)
            {
                intTableSize[i] = i + 1;
            }

            createdlabirynth = new Labirynt(intCellSize[4], "maze", Roles.Wall);
            solvedLabirynth = new Labirynt(intCellSize[4], "solvedMaze", Roles.Empty);

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
                if ((int)intTableSize.GetValue(i) < maxCellNumber.Width && intTableSize.GetValue(i).ToString() != "0")
                {
                    comboBoxWidth.Items.Add(intTableSize.GetValue(i).ToString());
                }

                if ((int)intTableSize.GetValue(i) < maxCellNumber.Height && intTableSize.GetValue(i).ToString() != "0")
                {
                    comboBoxHeight.Items.Add(intTableSize.GetValue(i).ToString());
                }
            }

            Point newSize = new Point(intTableSize[maxCellNumber.Width - 2], intTableSize[maxCellNumber.Height - 2]);

            comboBoxWidth.SelectedIndex = comboBoxWidth.FindString(newSize.X.ToString());
            comboBoxHeight.SelectedIndex = comboBoxWidth.FindString(newSize.Y.ToString());

            createdlabirynth.changeMaze(newSize);
            solvedLabirynth.changeMaze(newSize);
        }

        private void setNewLabirynthSize()
        {
            int indexWidth = comboBoxWidth.SelectedIndex > 0 ? comboBoxWidth.SelectedIndex : 0;
            int indexHeight = comboBoxHeight.SelectedIndex > 0 ? comboBoxHeight.SelectedIndex : 0;

            if (createOrSolveLabirynth)
            {
                createdlabirynth.changeMaze(new Point(intTableSize[indexWidth], intTableSize[indexHeight]));
                pictureBoxCentral.Image = createdlabirynth.showLabyrinth();
            }
            else
            {
                solvedLabirynth.changeMaze(new Point(intTableSize[indexWidth], intTableSize[indexHeight]));
                pictureBoxCentral.Image = solvedLabirynth.showLabyrinth();
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
            Size error = new Size(-1,-1);
            int randomIndex = 0, randomIndexNew = 0, iterations = 10000;
            List<Size> frontierCells = new List<Size>();
            createdlabirynth.changeCellRole(createdlabirynth.BeginingCell, Roles.Empty);

            //Pick a begining cell, and carve path from it to frontier.
            Size[] newFrontireCells = createdlabirynth.SetFrontiers(createdlabirynth.BeginingCell, frontierCells, Roles.Wall);

            for (int i = 0; i < newFrontireCells.Length; i++)
            {
                if(!newFrontireCells[i].Equals(error))
                {
                    frontierCells.Add(newFrontireCells[i]);

                    createdlabirynth.carvePath((Size)createdlabirynth.BeginingCell, frontierCells[i], Roles.Empty);
                }
            }

            Random rnd = new Random();
            Size frontCell = new Size();

            while (frontierCells.Count() > 0 && iterations > 0)
            {
                randomIndex = rnd.Next(0, frontierCells.Count());

                //Pick a random cell from the frontier collection
                frontCell = frontierCells.ElementAt(randomIndex);

                //Get its neighbors: cells in distance 2 in state path (no wall)
                newFrontireCells = createdlabirynth.SetFrontiers(frontCell, frontierCells, Roles.Wall);

                if (newFrontireCells.Length > 0)
                {
                    //Pick a random neighbor
                    randomIndexNew = rnd.Next(0, newFrontireCells.Count());

                    //Connect the frontier cell with the neighbor
                    createdlabirynth.carvePath(frontCell, newFrontireCells[randomIndexNew], Roles.Empty);
                }

                //Compute the frontier cells of the chosen frontier cell and add them to the frontier collection
                newFrontireCells = createdlabirynth.SetFrontiers(frontCell, frontierCells, Roles.Wall);

                for (int i = 1; i < newFrontireCells.Length; i++)
                {
                    if (!newFrontireCells[i].Equals(error))
                    {
                        frontierCells.Add(newFrontireCells[i]);
                    }
                }

                //Remove frontier cell from the frontier collection
                frontierCells.RemoveAt(randomIndex);
                iterations--;
            }

            createdlabirynth.changeCellRole(createdlabirynth.BeginingCell, Roles.Begining);

        }

        private void CreateLabyrinthC()
        {

        }

        private void CreateLabyrinthAssembler()
        {

        }

        private void SolveLabyrinth()
        {
            bool isSame = true;
            bool isCurrentH = true;
            bool isCurrentDistance = true;
            Point currentPoint = new Point(-1, -1);
            List<Point> openNodes = new List<Point>();
            List<Point> closedNodes = new List<Point>();
            Point error = new Point(-1, -1);
            int newMovCostItem = 0;

            openNodes.Add(solvedLabirynth.BeginingCell);

            while (openNodes.Count > 0)
            {
                currentPoint = openNodes[0];

                for (int i = 1; i < openNodes.Count; i++)
                {
                    isCurrentDistance = solvedLabirynth.GetTotalDistance(openNodes[i]) < solvedLabirynth.GetTotalDistance(currentPoint);
                    isCurrentH = solvedLabirynth.GetDistanceFromEnd(openNodes[i]) < solvedLabirynth.GetDistanceFromEnd(currentPoint);
                    isSame = solvedLabirynth.GetTotalDistance(openNodes[i]) == solvedLabirynth.GetTotalDistance(currentPoint);

                    if (isCurrentDistance || isSame && isCurrentH)
                    {
                        currentPoint = openNodes[i];
                    }
                }

                openNodes.Remove(currentPoint);
                closedNodes.Add(currentPoint);

                if (solvedLabirynth.getRole(currentPoint) == Roles.End)
                {
                    bool isStartFound = false;
                    Point currentCell = solvedLabirynth.EndCell;
                    Point nextCell = solvedLabirynth.GetParent(currentCell);

                    while (!isStartFound)
                    {
                        currentCell = nextCell;
                        nextCell = solvedLabirynth.GetParent(currentCell);
                        solvedLabirynth.changeCellRole(currentCell, Roles.Path);

                        if (nextCell == solvedLabirynth.BeginingCell)
                        {
                            isStartFound = true;
                        }
                    }

                    return;
                }

                foreach (Point item in solvedLabirynth.getNeighbors(currentPoint))
                {
                    if (item.Equals(error))
                    {
                        //Debug.Write("item:" + item + "\n");

                        continue;
                    }

                    if (solvedLabirynth.getRole(item) == Roles.Wall || closedNodes.Contains((Point)item))
                    {
                        continue;
                    }

                    newMovCostItem = solvedLabirynth.GetDistanceFromStart(currentPoint) + solvedLabirynth.getHeuristics(currentPoint, item);

                    if (newMovCostItem < solvedLabirynth.GetDistanceFromStart(item) || !openNodes.Contains(item))
                    {
                        solvedLabirynth.SetDistanceFromEnd(item, solvedLabirynth.getHeuristics(item, solvedLabirynth.EndCell));
                        solvedLabirynth.SetDistanceFromStart(item, newMovCostItem);
                        solvedLabirynth.SetParent(item, currentPoint);
                        solvedLabirynth.SetTotalDistance(item);


                        if (!openNodes.Contains(item))
                        {
                            openNodes.Add(item);
                        }
                    }
                }
            }
        }

        private void SolveLabyrinthC()
        {

        }

        private void SolveLabyrinthAssembler()
        {

        }

        private void comboBoxHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWidth.SelectedIndex == -1)
            {
                return;
            }

            setNewLabirynthSize();
        }

        private void comboBoxWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHeight.SelectedIndex == -1)
            {
                return;
            }

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
            radioButtonCreatingLabiryth.Checked = true;

            int status = setStatus(createdlabirynth);

            if (status > 0)
            {
                return;
            }

            if (loadedLibrary == languagesTypes[0])
            {
                CreateLabyrinth();
            }
            else if (loadedLibrary == languagesTypes[1])
            {
                CreateLabyrinthC();
            }
            else if (loadedLibrary == languagesTypes[2])
            {
                CreateLabyrinthAssembler();
            }

            pictureBoxCentral.Image = createdlabirynth.showLabyrinth();
        }

        private void buttonSolveLabyrinth_Click(object sender, EventArgs e)
        {
            createOrSolveLabirynth = false;
            radioButtonSolvingLabiryth.Checked = true;

            int status = setStatus(solvedLabirynth);

            if (status > 0)
            {
                return;
            }

            solvedLabirynth.ResetPath();

            if (loadedLibrary == languagesTypes[0])
            {
                SolveLabyrinth();
            }
            else if (loadedLibrary == languagesTypes[1])
            {
                SolveLabyrinthC();
            }
            else if (loadedLibrary == languagesTypes[2])
            {
                SolveLabyrinthAssembler();
            }

            pictureBoxCentral.Image = solvedLabirynth.showLabyrinth();
        }

        private int setStatus(Labirynt lab)
        {
            int status = 0;
            string massage = "Brakuje";
            Point nullPoint = new Point(-1, -1);

            bool isBegining = lab.BeginingCell.Equals(nullPoint);
            bool isEnding = lab.EndCell.Equals(nullPoint);

            status = (isEnding && isBegining) ? 2 : (isBegining ? 1 : (isEnding ? 3 : 0));

            if (status == 1)
            {
                massage += " pocz¹tku";
            }
            else if (status == 2)
            {
                massage += " pocz¹tku i koñca";
            }
            else if (status == 3)
            {
                massage += " koñca";
            }

            if (status > 0)
            {
                massage += " labiryntu.";

                MessageBox.Show(massage);
            }

            return status;
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

        private void radioButtonLibraryCHash_CheckedChanged(object sender, EventArgs e)
        {
            loadedLibrary = languagesTypes[0];
        }

        private void radioButtonLibraryCplus_CheckedChanged(object sender, EventArgs e)
        {
            loadedLibrary = languagesTypes[1];
        }

        private void radioButtonLibraryAssembler_CheckedChanged(object sender, EventArgs e)
        {
            loadedLibrary = languagesTypes[2];
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

            if (!isMouseDown)
            {
                return;
            }

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

        private void pictureBoxCentral_MouseMove(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if(!activeCells.Contains(me.Location) && isMouseDown)
            {
                activeCells.Add(me.Location);
            }
        }

        private void pictureBoxCentral_MouseDown(object sender, EventArgs e)
        {
            activeCells.Clear();

            isMouseDown = true;
        }

        private void pictureBoxCentral_MouseUp(object sender, EventArgs e)
        {
            isMouseDown = false;

            for (int i = 0; i < activeCells.Count(); i++)
            {
                if (createOrSolveLabirynth)
                {
                    createdlabirynth.setCellCoordinates(pictureBoxCentral.SizeMode, activeCells.ElementAt(i), new Point(pictureBoxCentral.Size));
                }
                else
                {
                    solvedLabirynth.setCellCoordinates(pictureBoxCentral.SizeMode, activeCells.ElementAt(i), new Point(pictureBoxCentral.Size));  
                }
            }

            if (createOrSolveLabirynth)
            {
                pictureBoxCentral.Image = createdlabirynth.showLabyrinth();
            }
            else
            {
                pictureBoxCentral.Image = solvedLabirynth.showLabyrinth();
            }
        }
    }
}
