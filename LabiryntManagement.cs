using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finalProjectJA_2025
{
    public partial class LabiryntManagement : Form
    {
        private int[] intTableSize = new int[255];

        private readonly int[] intCellSize = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];

        private readonly string[] pictureBoxSizeMods = ["Tryb Normalny", "Tryb Rozci¹gniêcia", "Tryb Wycentrowania", "Tryb Powiêkszenia"];

        private readonly string[] languagesTypes = ["C#", "C++", "Assembler"];

        private List<Point> activeCells = new List<Point>();

        private bool isMouseButtonPressed = false;
        private bool isLabirynthCreated = false;

        private string loadedLibrary = "C#";

        private int maxCoreNumber = 64;

        private Labirynt mylabirynth;

        [DllImport(@"C:\Users\Rafa³\source\repos\Projekty_Github\finalProjectJA_2025\x64\Debug\LabyrinthASM.dll")]
        static extern int CreateLAB(int a, int b, byte[] result, int lenght);

        [DllImport(@"C:\Users\Rafa³\source\repos\Projekty_Github\finalProjectJA_2025\x64\Debug\LabyrinthASM.dll")]
        static extern int SolveLAB(int a, int b, byte[] result, int lenght, byte startX, byte startY, byte endX, byte endY, int LabiryntSizeX, int LabiryntSizeY);

        public LabiryntManagement()
        {
            InitializeComponent();

            for (int i = 0; i < intCellSize.Length; i++)
            {
                comboBoxCellSize.Items.Add(intCellSize.GetValue(i));
            }

            for (int i = 1; i < 65; i++)
            {
                comboBoxCoresNumber.Items.Add(i);
            }

            maxCoreNumber = Environment.ProcessorCount;

            for (int i = 0; i < pictureBoxSizeMods.GetLength(0); i++)
            {
                comboBoxSizeMode.Items.Add(pictureBoxSizeMods[i]);
            }

            for (int i = 0; i < languagesTypes.GetLength(0); i++)
            {
                comboBoxLibrary.Items.Add(languagesTypes[i]);
            }

            for (int i = 0; i < intTableSize.Length; i++)
            {
                intTableSize[i] = i + 1;
            }

            mylabirynth = new Labirynt(intCellSize[4], "maze", Roles.Wall);

            int totalWidth = mylabirynth.LabiryntSize.X * mylabirynth.CellSize.X;
            int totalHeight = mylabirynth.LabiryntSize.Y * mylabirynth.CellSize.Y;

            pictureBoxCentral.Image = new Bitmap(totalWidth, totalHeight);

            comboBoxCellSize.Text = intCellSize[4].ToString();

            comboBoxHeight.Text = intTableSize[4].ToString();
            comboBoxWidth.Text = intTableSize[4].ToString();

            comboBoxSizeMode.Text = pictureBoxSizeMods[2].ToString();
            comboBoxLibrary.Text = languagesTypes[0];
            comboBoxCoresNumber.Text = maxCoreNumber.ToString();

            SetSizeComboBox();

            mylabirynth.SetMyImageId(saveFileDialog1);
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
            WrapperC myWrapper = new WrapperC(mylabirynth.LabiryntSize.X, mylabirynth.LabiryntSize.Y, mylabirynth.BeginingCell.X, mylabirynth.BeginingCell.Y, mylabirynth.EndCell.X, mylabirynth.EndCell.Y);

            int[] array = new int[mylabirynth.LabiryntSize.X * mylabirynth.LabiryntSize.Y];

            for (int i = 0; i < mylabirynth.LabiryntSize.X * mylabirynth.LabiryntSize.Y; i++)
            {
                array[i] = 0;
            }

            Stopwatch watch = Stopwatch.StartNew();

            myWrapper.createLabyrinthWrapper(array);

            mylabirynth.ChangeMaze(array);

            myWrapper.Dispose();

            return watch.ElapsedTicks;
        }

        byte setNewMask(int x, int y)
        {
            byte mask = 0b0000000;

            if (x < 0 || x > mylabirynth.LabiryntSize.X || y < 0 || y > mylabirynth.LabiryntSize.X)
            {
                return mask;
            }

            if (mylabirynth.Maze[x, y].Neighbors.ElementAt(0) != new Size(-1, -1))
            {
                mask += (byte)(1 << (0));
            }

            if (mylabirynth.Maze[x, y].Neighbors.ElementAt(1) != new Size(-1, -1))
            {
                mask += (byte)(1 << (1));
            }

            if (mylabirynth.Maze[x, y].Neighbors.ElementAt(2) != new Size(-1, -1))
            {
                mask += (byte)(1 << (2));
            }

            if (mylabirynth.Maze[x, y].Neighbors.ElementAt(3) != new Size(-1, -1))
            {
                mask += (byte)(1 << (3));
            }

            if (mylabirynth.Maze[x, y].Role == Roles.Wall)
            {
                mask += (byte)(1 << (4));
                mask += (byte)(1 << (5));
            }
            else if (mylabirynth.Maze[x, y].Role == Roles.Begining)
            {
                mask += (byte)(1 << (4));
            }
            else if (mylabirynth.Maze[x, y].Role == Roles.End)
            {
                mask += (byte)(1 << (5));
            }
            else if (mylabirynth.Maze[x, y].Role == Roles.Empty)
            {

            }

            if (mylabirynth.Maze[x, y].Parent == new Size(0, 0))
            {

            }
            else if (mylabirynth.Maze[x, y].Parent == new Size(0, 1))
            {

            }
            else if (mylabirynth.Maze[x, y].Parent == new Size(1, 0))
            {

            }
            else if (mylabirynth.Maze[x, y].Parent == new Size(1, 1))
            {

            }

            return mask;
        }

        void setElementsBasedOnMask(int x, int y, byte mask)
        {
            bool isStart = false, isEnd = false;
            Point oldStart = mylabirynth.BeginingCell, oldEnd = mylabirynth.EndCell;

            if (x < 0 || x > mylabirynth.LabiryntSize.X || y < 0 || y > mylabirynth.LabiryntSize.Y)
            {
                return;
            }

            if ((mask & (1 << 0)) == 0)
            {
                mylabirynth.Maze[x, y].Neighbors[0] = new Size(-1, -1);
            }

            if ((mask & (1 << 1)) != 0)
            {
                mylabirynth.Maze[x, y].Neighbors[1] = new Size(-1, -1);
            }

            if ((mask & (1 << 2)) != 0)
            {
                mylabirynth.Maze[x, y].Neighbors[2] = new Size(-1, -1);
            }

            if ((mask & (1 << 3)) != 0)
            {
                mylabirynth.Maze[x, y].Neighbors[3] = new Size(-1, -1);
            }

            if ((mask & (1 << 5)) != 0 && (mask & (1 << 4)) != 0)
            {
                mylabirynth.Maze[x, y].Role = Roles.Wall;
            }
            else if (((mask & (1 << 5)) != 0 && (mask & (1 << 4)) == 0))
            {
                if(mylabirynth.EndCell.Equals(new Point(-1, -1)))
                {
                    mylabirynth.Maze[x, y].Role = Roles.End;
                    mylabirynth.EndCell = new Point(x, y);
                    isEnd = true;
                }else
                {
                    mylabirynth.Maze[x, y].Role = Roles.Empty;
                }

            }
            else if (((mask & (1 << 5)) == 0 && (mask & (1 << 4)) != 0))
            {
                if (mylabirynth.BeginingCell.Equals(new Point(-1, -1)))
                {
                    mylabirynth.Maze[x, y].Role = Roles.Begining;
                    mylabirynth.BeginingCell = new Point(x, y);
                    isStart = true;
                }
                else
                {
                    mylabirynth.Maze[x, y].Role = Roles.Empty;
                }
                    
            }
            else if ((mask & (1 << 5)) == 0 && (mask & (1 << 4)) == 0)
            {
                mylabirynth.Maze[x, y].Role = Roles.Empty;
            }

            if ((mask & (1 << 6)) != 0 && (mask & (1 << 7)) != 0)//11
            {
                mylabirynth.Maze[x, y].Parent = new Size(x + 0, y - 1);
            }
            else if ((mask & (1 << 6)) != 0 && (mask & (1 << 7)) == 0)//10
            {
                mylabirynth.Maze[x, y].Parent = new Size(x + 1, y + 0);
            }
            else if ((mask & (1 << 6)) == 0 && (mask & (1 << 7)) != 0)//01
            {
                mylabirynth.Maze[x, y].Parent = new Size(x + 0, y + 1);
            }
            else if ((mask & (1 << 6)) == 0 && (mask & (1 << 7)) == 0)//00
            {
                mylabirynth.Maze[x, y].Parent = new Size(x - 1, y + 0);
            }

            if (isStart == false)
            {
                mylabirynth.BeginingCell = oldStart;
                mylabirynth.Maze[oldStart.X, oldStart.Y].Role = Roles.Begining;
            }

            if (isEnd == false)
            {
                mylabirynth.EndCell = oldEnd;
                mylabirynth.Maze[oldEnd.X, oldEnd.Y].Role = Roles.End;
            }
        }

        private long CreateLabyrinthAssembler()
        {
            int FullLabiryntSize = mylabirynth.LabiryntSize.X * mylabirynth.LabiryntSize.Y;
            int lenghtOfElement = 3, numberOfElements = lenghtOfElement * FullLabiryntSize;
            int x = 0, y = 0;

            //byte0: x, byte1: y, byte2: 2bit rodzic, 2bit stan, 4bit czy istnieje s¹siad

            byte[] results = new byte[numberOfElements];
            byte maskOne = 0b00000000;

            Debug.Write(" " + "\n");

            for (int i = 0; i < FullLabiryntSize; i++)
            {
                x = i / mylabirynth.LabiryntSize.Y;
                y = i % mylabirynth.LabiryntSize.Y;

                results[i * lenghtOfElement + 0] = ((byte)x); //Szerokoœæ
                results[i * lenghtOfElement + 1] = ((byte)y); //Wysokoœæ
                results[i * lenghtOfElement + 2] = 0b00000000;
                maskOne = setNewMask(x, y);

                results[i * lenghtOfElement + 2] |= maskOne;
            }

            Stopwatch watch = Stopwatch.StartNew();

            int retVal = CreateLAB(FullLabiryntSize, numberOfElements, results, lenghtOfElement);//rcx, rdx, r8, r9

            byte mask = 0b0000000;

            for (int i = 0; i < FullLabiryntSize; i++)
            {
                x = results[i * 3 + 0];
                y = results[i * 3 + 1];
                mask = results[i * 3 + 2];

                setElementsBasedOnMask(x, y, mask);
            }

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
            WrapperC myWrapper = new WrapperC(mylabirynth.LabiryntSize.X, mylabirynth.LabiryntSize.Y, mylabirynth.BeginingCell.X, mylabirynth.BeginingCell.Y, mylabirynth.EndCell.X, mylabirynth.EndCell.Y);

            int[] array = new int[mylabirynth.LabiryntSize.X * mylabirynth.LabiryntSize.Y];

            for (int i = 0; i < mylabirynth.LabiryntSize.X * mylabirynth.LabiryntSize.Y; i++)
            {
                int row = i / mylabirynth.LabiryntSize.Y;
                int col = i % mylabirynth.LabiryntSize.Y;

                array[i] = (int)mylabirynth.GetRole(new Point(row, col));
            }

            Stopwatch watch = Stopwatch.StartNew();

            myWrapper.solveLabyrinthWrapper(array);

            mylabirynth.ChangeMaze(array);

            SolveLabyrinth();

            myWrapper.Dispose();

            return watch.ElapsedTicks;
        }
        private long SolveLabyrinthAssembler()
        {
            int lenghtOfElement = 5, n = 0, x = 0, y = 0, index = 0;
            int FullLabiryntSize = mylabirynth.LabiryntSize.X * mylabirynth.LabiryntSize.Y;
            int numberOfElements = lenghtOfElement * FullLabiryntSize;

            string binaryString = " ";
            string formattedBinary = " ";

            //byte0: x, byte1: y, byte2: 2bit rodzic, 2bit stan, 4bit czy istnieje s¹siad,
            //byte3: odleg³oœæ od pocz¹tku x, byte4: odleg³oœæ od pocz¹tku y

            byte[] results = new byte[numberOfElements];
            byte maskOne = 0b0000000;

            for (int i = 0; i < FullLabiryntSize; i++)
            {
                x = i / mylabirynth.LabiryntSize.Y;
                y = i % mylabirynth.LabiryntSize.Y;
                

                results[i * lenghtOfElement + 0] = Convert.ToByte(x);//Szerokoœæ
                results[i * lenghtOfElement + 1] = Convert.ToByte(y); //Wysokoœæ
                results[i * lenghtOfElement + 2] = 0b00000000;
                results[i * lenghtOfElement + 3] = 0b11111111;
                results[i * lenghtOfElement + 4] = 0b11111111;

                maskOne = setNewMask(x, y);

                results[i * lenghtOfElement + 2] |= maskOne;
            }

            byte startX = ((byte)mylabirynth.BeginingCell.X), startY = ((byte)mylabirynth.BeginingCell.Y);
            byte endX = ((byte)mylabirynth.EndCell.X), endY = ((byte)mylabirynth.EndCell.Y);

            Stopwatch watch = Stopwatch.StartNew();

            int retVal = SolveLAB(FullLabiryntSize, numberOfElements, results, lenghtOfElement, startX, startY, endX, endY, (byte)mylabirynth.LabiryntSize.X, (byte)mylabirynth.LabiryntSize.Y);
            //rcx, rdx, r8,r9, rsp+96, rsp+104, rsp+112, rsp+120, rsp+128, rsp+136

            for (int i = 0; i < FullLabiryntSize; i++)
            {
                x = results[i * lenghtOfElement + 0];
                y = results[i * lenghtOfElement + 1];
                maskOne = results[i * lenghtOfElement + 2];

                setElementsBasedOnMask(x, y, maskOne);
            }

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

        private long testCreateLabyrinth()
        {
            Point newStart = new Point(1, 1);
            Point newEnd = new Point(mylabirynth.LabiryntSize.X - 1, mylabirynth.LabiryntSize.Y - 1);

            mylabirynth.Reset();
            mylabirynth.SetStartAndEnd(newStart, newEnd);

            long testTime = 0;
            long testTimeSum = 0;
            int numberOfTestRepetitions = 5;

            testTime = CreateLabyrinth();

            for (int i = 0; i < numberOfTestRepetitions; i++)
            {
                mylabirynth.ChangeMaze();
                mylabirynth.SetStartAndEnd(newStart, newEnd);

                testTime = CreateLabyrinth();
                testTimeSum += testTime;
            }

            testTimeSum /= numberOfTestRepetitions;

            isLabirynthCreated = true;

            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();

            return testTimeSum;
        }

        private long testSolveLabyrinth()
        {
            Point newStart = new Point(1, 1);
            Point newEnd = new Point(mylabirynth.LabiryntSize.X - 1, mylabirynth.LabiryntSize.Y - 1);

            mylabirynth.Reset();
            mylabirynth.SetStartAndEnd(newStart, newEnd);

            long testTime = 0;
            long testTimeSum = 0;
            int numberOfTestRepetitions = 5;

            CreateLabyrinth();
            testTime = SolveLabyrinth();

            for (int i = 0; i < numberOfTestRepetitions; i++)
            {
                mylabirynth.ResetPath();
                testTime = SolveLabyrinth();
                testTimeSum += testTime;
            }

            testTimeSum /= numberOfTestRepetitions;

            pictureBoxCentral.Image = mylabirynth.ShowLabyrinth();

            return testTimeSum;
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
            Point oldStart = mylabirynth.BeginingCell;
            Point oldEnd = mylabirynth.EndCell;
            Point error = new Point(-1, -1);

            mylabirynth.Reset();

            if (!error.Equals(oldStart) && !error.Equals(oldEnd))
            {
                mylabirynth.SetStartAndEnd(oldStart, oldEnd);
            }

            int status = SetStatus(mylabirynth);

            if (status > 0)
            {
                Debug.Write("status: " + status + " loadedLibrary: " + loadedLibrary + "\n");

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

        private void comboBoxLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxLibrary.SelectedIndex;

            index = (index < 0) ? 0 : index;

            index = (index > languagesTypes.GetLength(0)) ? languagesTypes.GetLength(0) - 1 : index;

            loadedLibrary = languagesTypes[index];
        }

        private void buttonTestCreation_Click(object sender, EventArgs e)
        {
            long time = testCreateLabyrinth();

            labelTestCreation.Text = "Czas testów stworzonego labiryntu: " + time;

        }

        private void buttonTestSolving_Click(object sender, EventArgs e)
        {
            long time = testSolveLabyrinth();

            labelTestSolving.Text = "Czas testów rozwi¹zania labiryntu: " + time;
        }
    }
}