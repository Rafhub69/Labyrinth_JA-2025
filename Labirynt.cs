using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace finalProjectJA_2025
{
    internal class Labirynt
    {
        private Point cellSize = new Point(50, 50);
        private Point labiryntSize = new Point(5, 5);

        private Point beginingCell = new Point(-1, -1);
        private Point endCell = new Point(-1, -1);

        private int myImageId = -1;

        private Cell[,] maze;

        private string name;

        public Labirynt()
        {
            changeMaze();
        }

        public Labirynt(Point newSize)
        {
            changeMaze(newSize);
        }

        public Labirynt(int x, int y, string newName)
        {
            Name = newName;

            changeMaze(new Point(x, y));
        }

        public Labirynt(int newCellSize, string newName)
        {
            CellSize = new Point(newCellSize, newCellSize);
            Name = newName;

            changeMaze();
        }

        public void Reset(int newCellSize, int newMazeWidth, int newMazeHeight)
        {
            CellSize = new Point(newCellSize, newCellSize);
            labiryntSize = new Point(newMazeWidth, newMazeHeight);

            Reset();
        }

        public void Reset()
        {
            ResetRole();
            changeMaze();
        }

        public void ResetRole()
        {
            BeginingCell = new Point(-1, -1);
            EndCell = new Point(-1, -1);
        }

        public void ResetPath()
        {
            for (int i = 0; i < LabiryntSize.X; i++)
            {
                for (int j = 0; j < LabiryntSize.Y; j++)
                {
                    if (Maze[i, j].Role == Roles.Path)
                    {
                        Maze[i, j].Role = Roles.Empty;
                    }
                }
            }
        }

        public void changeMaze(Point newSize)
        {
            LabiryntSize = newSize;

            changeMaze();
        }

        public void changeMaze()
        {
            Maze = new Cell[LabiryntSize.X, LabiryntSize.Y];

            int maxDistance = LabiryntSize.X * LabiryntSize.Y;

            for (int i = 0; i < LabiryntSize.X; i++)
            {
                for (int j = 0; j < LabiryntSize.Y; j++)
                {
                    Maze[i, j] = new Cell();
                    Maze[i, j].DistanceFromStart = 0;
                    Maze[i, j].TotalDistance = maxDistance;
                    Maze[i, j].DistanceFromEnd = maxDistance;
                    Maze[i, j].Rectangle = new Rectangle(i * CellSize.X, j * CellSize.Y, CellSize.X, CellSize.Y);
                    SetNeighbors(i, j);
                }
            }

            ResetRole();
        }

        public int getHeuristics(Size start, Size end)
        {
            int newHeuristic = LabiryntSize.X * LabiryntSize.Y;

            Size error = new Size(-1, -1);

            if (start.Equals(error) || end.Equals(error))
            {
                return newHeuristic;
            }

            newHeuristic = Math.Abs(end.Height - start.Height) + Math.Abs(end.Width - start.Width);

            Maze[start.Width, start.Height].DistanceFromEnd = newHeuristic;

            //Debug.Write("Heuristic[" + start.Width + " ," + start.Height + "]: " + Heuristic[start.Width, start.Height] + "\n");

            return newHeuristic;
        }

        public int getHeuristics(Point start, Point end)
        {
            int newHeuristic = LabiryntSize.X * LabiryntSize.Y;

            Point error = new Point(-1, -1);

            if (start.Equals(error) || end.Equals(error))
            {
                return newHeuristic;
            }

            newHeuristic = Math.Abs(end.Y - start.Y) + Math.Abs(end.X - start.X);

            Maze[start.X, start.Y].DistanceFromEnd = newHeuristic;

            return newHeuristic;
        }

        public void SetDistanceFromStart(Point cord, int dist)
        {
            Maze[cord.X, cord.Y].DistanceFromStart = dist;
        }

        public void SetDistanceFromStart(Size cord, int dist)
        {
            Maze[cord.Width, cord.Height].DistanceFromStart = dist;
        }

        public int GetDistanceFromStart(Point cord)
        {
            return Maze[cord.X, cord.Y].DistanceFromStart;
        }

        public int GetDistanceFromStart(Size cord)
        {
            return Maze[cord.Width, cord.Height].DistanceFromStart;
        }

        public void SetDistanceFromEnd(Point cord, int dist)
        {
            Maze[cord.X, cord.Y].DistanceFromEnd = dist;
        }

        public void SetDistanceFromEnd(Size cord, int dist)
        {
            Maze[cord.Width, cord.Height].DistanceFromEnd = dist;
        }


        public int GetDistanceFromEnd(Point cord)
        {
            return Maze[cord.X, cord.Y].DistanceFromEnd;
        }

        public int GetDistanceFromEnd(Size cord)
        {
            return Maze[cord.Width, cord.Height].DistanceFromEnd;
        }

        public void SetTotalDistance(Point cord)
        {
            Maze[cord.X, cord.Y].TotalDistance = Maze[cord.X, cord.Y].DistanceFromEnd + Maze[cord.X, cord.Y].DistanceFromStart;
        }

        public void SetTotalDistance(Size cord)
        {
            Maze[cord.Width, cord.Height].TotalDistance = Maze[cord.Width, cord.Height].DistanceFromEnd + Maze[cord.Width, cord.Height].DistanceFromStart;
        }

        public int GetTotalDistance(Point cord)
        {
            return Maze[cord.X, cord.Y].TotalDistance;
        }

        public int GetTotalDistance(Size cord)
        {
            return Maze[cord.Width, cord.Height].TotalDistance;
        }

        public void SetNeighbors(Point cord)
        {
            SetNeighbors(new Point(cord.X, cord.Y));
        }

        public void SetNeighbors(int x, int y)
        {
            //left
            if (x > 0)
            {
                maze[x, y].Neighbors[0] = new Size(x - 1, y);
            }
            //right
            if (x < labiryntSize.X - 1)
            {
                maze[x, y].Neighbors[1] = new Size(x + 1, y);
            }
            //top
            if (y > 0)
            {
                maze[x, y].Neighbors[2] = new Size(x, y - 1);
            }
            //bottom
            if (y < labiryntSize.Y - 1)
            {
                maze[x, y].Neighbors[3] = new Size(x, y + 1);
            }
        }

        public void SetParent(Point currentCell, Point newParent)
        {
            Size error = new Size(-1, -1);

            if (currentCell.Equals(error))
            {
                return;
            }

            maze[currentCell.X, currentCell.Y].Parent = (Size)newParent;
        }

        public void SetParent(Size currentCell, Size newParent)
        {
            Size error = new Size(-1, -1);

            if (currentCell.Equals(error))
            {
                return;
            }

            maze[currentCell.Width, currentCell.Height].Parent = newParent;
        }

        public Point GetParent(Point currentCell)
        {
            return (Point)maze[currentCell.X, currentCell.Y].Parent;
        }

        public Size GetParent(Size currentCell)
        {
            return maze[currentCell.Width, currentCell.Height].Parent;
        }


        public Size[] getNeighbors(Point cord)
        {
            if (cord.X < 0 || cord.Y < 0 || cord.X > maze.GetLength(0) || cord.Y > maze.GetLength(1))
            {
                Size error = new Size(-1, -1);

                Size[] tab = new Size[4];

                for (int i = 0; i < 4; i++)
                {
                    tab[i] = error;
                }

                //Debug.Write("cord: " + cord.X + " " + cord.Y + "\n");
                return tab;
            }

            return maze[cord.X, cord.Y].Neighbors;
        }

        public Size[] getNeighbors(Size cord)
        {
            if (cord.Width < 0 || cord.Height < 0 || cord.Width > maze.GetLength(0) || cord.Height > maze.GetLength(1))
            {
                Size error = new Size(-1, -1);

                Size[] tab = new Size[4];

                for (int i = 0; i < 4; i++)
                {
                    tab[i] = error;
                }

                //Debug.Write("cord: " + cord.Width + " " + cord.Height + "\n");
                return tab;
            }

            return maze[cord.Width, cord.Height].Neighbors;
        }

        public Size[] getNeighbors(int x, int y)
        {
            return maze[x, y].Neighbors;
        }

        public Size getNeighbor(Point cord, int index)
        {
            return maze[cord.X, cord.Y].Neighbors[index];
        }

        public Size getNeighbor(Size cord, int index)
        {
            return maze[cord.Width, cord.Height].Neighbors[index];
        }

        public Size getNeighbor(int x, int y, int index)
        {
            return maze[x, y].Neighbors[index];
        }

        public Roles getRole(Point cord)
        {
            return maze[cord.X, cord.Y].Role;

        }

        public Roles getRole(Size cord)
        {
            return maze[cord.Width, cord.Height].Role;

        }

        public Roles getRole(int x, int y)
        {
            return maze[x, y].Role;
        }

        public bool isCellNull(Point cord)
        {
            Point error = new Point(-1, -1);

            if (cord.Equals(error))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isCellNull(Size cord)
        {
            Size error = new Size(-1, -1);

            if (cord.Equals(error))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isCellNull(int x, int y)
        {
            int errorX = -1;
            int errorY = -1;

            if (x == errorX & y == errorY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Bitmap showLabyrinth()
        {
            int totalWidth = LabiryntSize.X * cellSize.X;
            int totalHeight = LabiryntSize.Y * cellSize.Y;

            Bitmap image = new Bitmap(totalWidth, totalHeight);
            Graphics graphics = Graphics.FromImage(image);

            Pen pen = new Pen(Color.Black, 4);
            SolidBrush brush = new SolidBrush(Color.White);
            Brush textBrush = new SolidBrush(Color.Black);
            Font font = new Font("Segoe UI", 9F, FontStyle.Bold);

            StringFormat sfCenter = new StringFormat();
            StringFormat sfRight = new StringFormat();
            StringFormat sfLeft = new StringFormat();
            sfCenter.LineAlignment = StringAlignment.Center;
            sfCenter.Alignment = StringAlignment.Center;

            sfRight.LineAlignment = StringAlignment.Far;
            sfRight.Alignment = StringAlignment.Far;

            sfLeft.LineAlignment = StringAlignment.Near;
            sfLeft.Alignment = StringAlignment.Near;

            for (int i = 0; i < LabiryntSize.X; i++)
            {
                for (int j = 0; j < LabiryntSize.Y; j++)
                {
                    brush.Color = maze[i, j].RoleColor[maze[i, j].Role.ToString()];
                    pen.Color = maze[i, j].BorderColor[maze[i, j].Role.ToString()];

                    graphics.FillRectangle(brush, maze[i, j].Rectangle);

                    graphics.DrawRectangle(pen, maze[i, j].Rectangle);

                    if(cellSize.X > 45)
                    {
                        graphics.DrawString(maze[i, j].DistanceFromEnd.ToString(), font, textBrush, maze[i, j].Rectangle, sfRight);

                        graphics.DrawString(maze[i, j].DistanceFromStart.ToString(), font, textBrush, maze[i, j].Rectangle, sfLeft);

                        graphics.DrawString(maze[i, j].TotalDistance.ToString(), font, textBrush, maze[i, j].Rectangle, sfCenter);
                    }
                }
            }

            return image;
        }

        public Size getMaxTableSizeValues(Size fullSize)
        {
            double w = fullSize.Width / cellSize.X;
            double h = fullSize.Height / cellSize.Y;

            int maxCellNumberWidth = Convert.ToInt32(w);
            int maxCellNumberHeight = Convert.ToInt32(h);

            Size maxValues = new Size(maxCellNumberWidth, maxCellNumberHeight);

            //Debug.Write("w: " + w + " h: " + h + " cellWidth: " + cellWidth + "\n");

            return maxValues;
        }

        public void SaveMaze(SaveFileDialog saveFileDialog, Image image)
        {
            string filePath = name + MyImageId + ".jpg";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.FileName = filePath;

            if (saveFileDialog.FileName != "" && saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyImageId++;

                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();

                image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                fs.Close();
            }
        }

        public void SetMyImageId(SaveFileDialog sfd)
        {
            string[] jpgFileNames = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.jpg").Select(Path.GetFileName).ToArray();
            string stringSeparators = ".jpg";

            int numCreated = -1;
            int numSolved = -1;
            string[] result;
            string[] number;

            foreach (string name in jpgFileNames)
            {
                result = name.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                foreach (var item in result)
                {
                    number = item.Split(Name, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    foreach (string item2 in number)
                    {
                        if (Int32.TryParse(item2, out numCreated))
                        {
                            if (numCreated > MyImageId)
                            {
                                numCreated++;
                                MyImageId = numCreated;
                            }
                            else if (numCreated == MyImageId)
                            {
                                MyImageId++;
                            }
                        }
                        else
                        {
                            Debug.Write("Item isn't a number.\n");
                        }
                    }
                }
            }
        }

        public void setCellCoordinates(PictureBoxSizeMode SizeMode, Point mouseCoordinates, Point pictureBoxSize)
        {
            Point totalSize = new Point(LabiryntSize.X * CellSize.X, LabiryntSize.Y * CellSize.Y);
            Point correction = new Point(-(pictureBoxSize.X - totalSize.X) / 2, -(pictureBoxSize.Y - totalSize.Y) / 2);

            if (SizeMode == PictureBoxSizeMode.Normal)
            {

            }
            else if (SizeMode == PictureBoxSizeMode.StretchImage)
            {
                mouseCoordinates.Offset(correction);
            }
            else if (SizeMode == PictureBoxSizeMode.Zoom)
            {
                mouseCoordinates.Offset(correction);
            }
            else if (SizeMode == PictureBoxSizeMode.CenterImage)
            {
                mouseCoordinates.Offset(correction);
            }

            Point coordinates = new Point((mouseCoordinates.X / CellSize.X), (mouseCoordinates.Y / CellSize.Y));

            if (coordinates.X > -1 && coordinates.X < LabiryntSize.X && coordinates.Y > -1 && coordinates.Y < LabiryntSize.Y)
            {
                changeCellRole(coordinates);
            }

        }

        public void changeCellRole(Point mainPoint, Roles newRole)
        {
            changeCellRole(mainPoint.X, mainPoint.Y, newRole);
        }

        public void changeCellRole(int coordinatesI, int coordinatesJ, Roles newRole)
        {
            maze[coordinatesI, coordinatesJ].Role = newRole;
        }

        public void changeCellRole(Point mainPoint)
        {
            changeCellRole(mainPoint.X, mainPoint.Y);
        }

        public void changeCellRole(int coordinatesI, int coordinatesJ)
        {
            Point initPoint = new Point(-1, -1);

            if (maze[coordinatesI, coordinatesJ].Role == Roles.Empty)
            {
                if (beginingCell.Equals(initPoint))
                {
                    maze[coordinatesI, coordinatesJ].Role = Roles.Begining;
                    beginingCell = new Point(coordinatesI, coordinatesJ);
                }
                else if (endCell.Equals(initPoint))
                {
                    maze[coordinatesI, coordinatesJ].Role = Roles.End;
                    endCell = new Point(coordinatesI, coordinatesJ);
                }
                else
                {
                    maze[coordinatesI, coordinatesJ].Role = Roles.Wall;
                }
            }
            else if (maze[coordinatesI, coordinatesJ].Role == Roles.Begining)
            {
                maze[coordinatesI, coordinatesJ].Role = Roles.Wall;
                beginingCell = initPoint;
            }
            else if (maze[coordinatesI, coordinatesJ].Role == Roles.End)
            {
                maze[coordinatesI, coordinatesJ].Role = Roles.Wall;
                endCell = initPoint;
            }
            else if (maze[coordinatesI, coordinatesJ].Role == Roles.Wall || maze[coordinatesI, coordinatesJ].Role == Roles.Path)
            {
                if (beginingCell.Equals(initPoint))
                {
                    maze[coordinatesI, coordinatesJ].Role = Roles.Begining;
                    beginingCell = new Point(coordinatesI, coordinatesJ);
                }
                else if (endCell.Equals(initPoint))
                {
                    maze[coordinatesI, coordinatesJ].Role = Roles.End;
                    endCell = new Point(coordinatesI, coordinatesJ);
                }
                else
                {
                    maze[coordinatesI, coordinatesJ].Role = Roles.Empty;
                }
            }
        }

        public Point EndCell { get => endCell; set => endCell = value; }
        public Point CellSize { get => cellSize; set => cellSize = value; }
        public Point LabiryntSize { get => labiryntSize; set => labiryntSize = value; }
        public Point BeginingCell { get => beginingCell; set => beginingCell = value; }
        public int MyImageId { get => myImageId; set => myImageId = value; }
        internal Cell[,] Maze { get => maze; set => maze = value; }
        public string Name { get => name; set => name = value; }

    }
}
