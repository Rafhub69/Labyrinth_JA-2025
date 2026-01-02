using System.Diagnostics;

namespace finalProjectJA_2025
{
    public partial class LabiryntManagement : Form
    {
        private int[] intTableSize = new int[255];

        private readonly int[] intCellSize = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];

        private readonly string[] pictureBoxSizeMods = ["Tryb Normalny", "Tryb Rozci¹gniêcia", "Tryb Wycentrowania", "Tryb Powiêkszenia"];

        private readonly string[] languagesTypes = ["C#", "C++", "Assembler"];

        private bool isMouseButtonPressed = false;
        private bool isLabirynthCreated = false;

        private List<Point> activeCells = new List<Point>();

        private string loadedLibrary = "C#";

        private Labirynt mylabirynth;

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

            mylabirynth = new Labirynt(intCellSize[4], "maze", Roles.Wall);

            int totalWidth = mylabirynth.LabiryntSize.X * mylabirynth.CellSize.X;
            int totalHeight = mylabirynth.LabiryntSize.Y * mylabirynth.CellSize.Y;

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

            mylabirynth.SetMyImageId(saveFileDialog1);

            imageNumber = new Point(mylabirynth.MyImageId, mylabirynth.MyImageId);
        }

        public void SetControlsCoordinates()
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

            maxCellNumber = mylabirynth.GetMaxTableSizeValues(pictureBoxCentral.Size);

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

            mylabirynth.ChangeMaze(newSize);
        }

        private void SetNewLabirynthSize()
        {
            int indexWidth = comboBoxWidth.SelectedIndex > 0 ? comboBoxWidth.SelectedIndex : 0;
            int indexHeight = comboBoxHeight.SelectedIndex > 0 ? comboBoxHeight.SelectedIndex : 0;

            mylabirynth.ChangeMaze(new Point(intTableSize[indexWidth], intTableSize[indexHeight]));
            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();
        }

        private long CreateLabyrinth()
        {
            int randomIndex = 0;
            Random rnd = new Random();
            List<Size> frontierCells = new List<Size>();
            List<Size> adjacentCells = new List<Size>();
            Size currentElement = (Size)mylabirynth.BeginingCell;
            int maxNumberOfCells = mylabirynth.Maze.GetLength(0) * mylabirynth.Maze.GetLength(1);
            mylabirynth.ChangeCellRole(mylabirynth.BeginingCell, Roles.Empty);
            mylabirynth.ChangeCellRole(mylabirynth.EndCell, Roles.Wall);

            Stopwatch watch = Stopwatch.StartNew();

            adjacentCells = mylabirynth.SetListFrontiers(currentElement, Roles.Wall);

            mylabirynth.ChangeCellsRole(adjacentCells, Roles.Empty);

            for (int i = 0; i < adjacentCells.Count; i++)
            {
                mylabirynth.SetParent(adjacentCells.ElementAt(i), currentElement);
            }

            frontierCells.AddRange(adjacentCells);

            while (frontierCells.Count < maxNumberOfCells * 2 && frontierCells.Count > 0)
            {
                randomIndex = rnd.Next(0, frontierCells.Count);

                currentElement = frontierCells.ElementAt(randomIndex);

                adjacentCells = mylabirynth.SetListFrontiers(currentElement, Roles.Wall);

                mylabirynth.ChangeCellsRole(adjacentCells, Roles.Empty);

                mylabirynth.CarvePath(mylabirynth.GetParent(currentElement), currentElement, Roles.Empty);

                for (int i = 0; i < adjacentCells.Count; i++)
                {
                    mylabirynth.SetParent(adjacentCells.ElementAt(i), currentElement);
                }

                frontierCells.AddRange(adjacentCells);

                frontierCells.RemoveAt(randomIndex);
            }

            watch.Stop();

            mylabirynth.ChangeCellRole(mylabirynth.BeginingCell, Roles.Begining);
            mylabirynth.ChangeCellRole(mylabirynth.EndCell, Roles.End);

            return watch.ElapsedTicks;
        }

        private long CreateLabyrinthC()
        {
            Stopwatch watch = Stopwatch.StartNew();



            return watch.ElapsedTicks;
        }

        private long CreateLabyrinthAssembler()
        {
            Stopwatch watch = Stopwatch.StartNew();

            return watch.ElapsedTicks;
        }

        private long SolveLabyrinth()
        {
            bool isSame = true;
            bool isCurrentH = true;
            bool isCurrentDistance = true;
            Point currentPoint = new Point(-1, -1);
            List<Point> openNodes = new List<Point>();
            List<Point> closedNodes = new List<Point>();
            Point error = new Point(-1, -1);
            int newMovCostItem = 0;

            openNodes.Add(mylabirynth.BeginingCell);

            Stopwatch watch = Stopwatch.StartNew();

            while (openNodes.Count > 0)
            {
                currentPoint = openNodes[0];

                for (int i = 1; i < openNodes.Count; i++)
                {
                    isCurrentDistance = mylabirynth.GetTotalDistance(openNodes[i]) < mylabirynth.GetTotalDistance(currentPoint);
                    isCurrentH = mylabirynth.GetDistanceFromEnd(openNodes[i]) < mylabirynth.GetDistanceFromEnd(currentPoint);
                    isSame = mylabirynth.GetTotalDistance(openNodes[i]) == mylabirynth.GetTotalDistance(currentPoint);

                    if (isCurrentDistance || isSame && isCurrentH)
                    {
                        currentPoint = openNodes[i];
                    }
                }

                openNodes.Remove(currentPoint);
                closedNodes.Add(currentPoint);

                if (mylabirynth.GetRole(currentPoint) == Roles.End)
                {
                    bool isStartFound = false;
                    Point currentCell = mylabirynth.EndCell;
                    Point nextCell = mylabirynth.GetParent(currentCell);

                    while (!isStartFound)
                    {
                        currentCell = nextCell;
                        nextCell = mylabirynth.GetParent(currentCell);
                        mylabirynth.ChangeCellRole(currentCell, Roles.Path);

                        if (nextCell == mylabirynth.BeginingCell)
                        {
                            isStartFound = true;
                        }
                    }

                    return watch.ElapsedTicks;
                }

                foreach (Point item in mylabirynth.GetNeighbors(currentPoint))
                {
                    if (item.Equals(error))
                    {
                        continue;
                    }

                    if (mylabirynth.GetRole(item) == Roles.Wall || closedNodes.Contains((Point)item))
                    {
                        continue;
                    }

                    newMovCostItem = mylabirynth.GetDistanceFromStart(currentPoint) + mylabirynth.GetHeuristics(currentPoint, item);

                    if (newMovCostItem < mylabirynth.GetDistanceFromStart(item) || !openNodes.Contains(item))
                    {
                        mylabirynth.SetDistanceFromEnd(item, mylabirynth.GetHeuristics(item, mylabirynth.EndCell));
                        mylabirynth.SetDistanceFromStart(item, newMovCostItem);
                        mylabirynth.SetParent(item, currentPoint);
                        mylabirynth.SetTotalDistance(item);


                        if (!openNodes.Contains(item))
                        {
                            openNodes.Add(item);
                        }
                    }
                }
            }

            return watch.ElapsedTicks;
        }

        private long SolveLabyrinthC()
        {
            Stopwatch watch = Stopwatch.StartNew();

            return watch.ElapsedTicks;
        }

        private long SolveLabyrinthAssembler()
        {
            Stopwatch watch = Stopwatch.StartNew();

            return watch.ElapsedTicks;
        }

        private int SetStatus(Labirynt lab)
        {
            string massage = "Brakuje";
            Point nullPoint = new Point(-1, -1);

            bool isBegining = lab.BeginingCell.Equals(nullPoint);
            bool isEnding = lab.EndCell.Equals(nullPoint);

            int status = (isEnding && isBegining) ? 2 : (isBegining ? 1 : (isEnding ? 3 : 0));

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

        private void comboBoxHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWidth.SelectedIndex == -1)
            {
                return;
            }

            SetNewLabirynthSize();
        }

        private void comboBoxWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHeight.SelectedIndex == -1)
            {
                return;
            }

            SetNewLabirynthSize();
        }

        private void comboBoxCellSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            mylabirynth.CellSize = new Point(intCellSize[comboBoxCellSize.SelectedIndex], intCellSize[comboBoxCellSize.SelectedIndex]);
            SetSizeComboBox();
            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();
        }

        private void comboBoxCoresNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            maxCoreNumber = comboBoxCoresNumber.SelectedIndex + 1;
        }

        private void buttonCreateLabyrinth_Click(object sender, EventArgs e)
        {
            radioButtonCreatingLabiryth.Checked = true;

            Point oldStart = mylabirynth.BeginingCell;
            Point oldEnd = mylabirynth.EndCell;

            mylabirynth.Reset();

            mylabirynth.SetStartAndEnd(oldStart, oldEnd);

            int status = SetStatus(mylabirynth);

            if (status > 0)
            {
                return;
            }

            if (loadedLibrary == languagesTypes[0])
            {
                mylabirynth.Time = CreateLabyrinth();
            }
            else if (loadedLibrary == languagesTypes[1])
            {
                mylabirynth.Time = CreateLabyrinthC();
            }
            else if (loadedLibrary == languagesTypes[2])
            {
                mylabirynth.Time = CreateLabyrinthAssembler();
            }

            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();

            labelTimeCreation.Text = "Czas stworzenia labiryntu: " + mylabirynth.Time;

            isLabirynthCreated = true;
        }

        private void buttonSolveLabyrinth_Click(object sender, EventArgs e)
        {
            radioButtonSolvingLabiryth.Checked = true;

            if (isLabirynthCreated)
            {
                mylabirynth.ResetPath();
            }

            int status = SetStatus(mylabirynth);

            if (status > 0)
            {
                return;
            }

            mylabirynth.ResetPath();

            if (loadedLibrary == languagesTypes[0])
            {
                mylabirynth.Time = SolveLabyrinth();

            }
            else if (loadedLibrary == languagesTypes[1])
            {
                mylabirynth.Time = SolveLabyrinthC();
            }
            else if (loadedLibrary == languagesTypes[2])
            {
                mylabirynth.Time = SolveLabyrinthAssembler();
            }

            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();

            labelTimeSolved.Text = "Czas rozwi¹zania labiryntu: " + mylabirynth.Time;
        }

        private void buttonSaveLabyrinth_Click(object sender, EventArgs e)
        {
            mylabirynth.SaveMaze(saveFileDialog1, pictureBoxCentral.Image);
        }

        private void buttonSaveSolvedLabyrinth_Click(object sender, EventArgs e)
        {
            mylabirynth.SaveMaze(saveFileDialog1, pictureBoxCentral.Image);
        }

        private void radioButtonCreatingLabiryth_CheckedChanged(object sender, EventArgs e)
        {
            //createOrSolveLabirynth = radioButtonCreatingLabiryth.Checked;

            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();
        }

        private void radioButtonSolvingLabiryth_CheckedChanged(object sender, EventArgs e)
        {
            //createOrSolveLabirynth = !radioButtonSolvingLabiryth.Checked;

            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();
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

            mylabirynth.Reset(intCellSize[indexCellSize], intTableSize[indexWidth], intTableSize[indexHeight]);

            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();

            labelTimeCreation.Text = "Czas stworzenia labiryntu: " + mylabirynth.Time;
            labelTimeSolved.Text = "Czas rozwi¹zania labiryntu: " + mylabirynth.Time;

            isLabirynthCreated = false;
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

            if (!isMouseButtonPressed)
            {
                return;
            }

            mylabirynth.SetCellCoordinates(pictureBoxCentral.SizeMode, me.Location, new Point(pictureBoxCentral.Size));
            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();
        }

        private void pictureBoxCentral_MouseMove(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (!activeCells.Contains(me.Location) && isMouseButtonPressed)
            {
                activeCells.Add(me.Location);
            }
        }

        private void pictureBoxCentral_MouseDown(object sender, EventArgs e)
        {
            activeCells.Clear();

            isMouseButtonPressed = true;
        }

        private void pictureBoxCentral_MouseUp(object sender, EventArgs e)
        {
            isMouseButtonPressed = false;

            for (int i = 0; i < activeCells.Count; i++)
            {
                mylabirynth.SetCellCoordinates(pictureBoxCentral.SizeMode, activeCells.ElementAt(i), new Point(pictureBoxCentral.Size));
            }

            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();
        }

    }
}