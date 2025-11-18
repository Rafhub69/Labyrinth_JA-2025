using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            changeMaze(labiryntSize);
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

            changeMaze(labiryntSize);
        }

        public void Reset()
        {
            BeginingCell = new Point(-1, -1);
            CellSize = new Point(50, 50);
            EndCell = new Point(-1, -1);
            changeMaze(LabiryntSize);
        }

        public void changeMaze(Point newSize)
        {
            LabiryntSize = newSize;

            Maze = new Cell[LabiryntSize.X, LabiryntSize.Y];

            for (int i = 0; i < LabiryntSize.X; i++)
            {
                for (int j = 0; j < LabiryntSize.Y; j++)
                {
                    Maze[i, j] = new Cell();
                    Maze[i, j].Rectangle = new Rectangle(i * CellSize.X, j * CellSize.Y, CellSize.X, CellSize.Y);
                    SetNeighbors(i, j);
                }
            }
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

        public Bitmap showLabyrinth()
        {
            int totalWidth = LabiryntSize.X * cellSize.X;
            int totalHeight = LabiryntSize.Y * cellSize.Y;

            Bitmap image = new Bitmap(totalWidth, totalHeight);
            Graphics graphics = Graphics.FromImage(image);

            Pen pen = new Pen(Color.Black, 4);
            SolidBrush brush = new SolidBrush(Color.White);

            for (int i = 0; i < LabiryntSize.X; i++)
            {
                for (int j = 0; j < LabiryntSize.Y; j++)
                {
                    brush.Color = maze[i, j].RoleColor[maze[i, j].Role.ToString()];
                    pen.Color = maze[i, j].BorderColor[maze[i, j].Role.ToString()];

                    graphics.FillRectangle(brush, maze[i, j].Rectangle);

                    graphics.DrawRectangle(pen, maze[i, j].Rectangle);
                }
            }

            //Debug.Write("i: " + i + " j: " + j + "\n");

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

        public Point CellSize { get => cellSize; set => cellSize = value; }
        public Point LabiryntSize { get => labiryntSize; set => labiryntSize = value; }
        public Point BeginingCell { get => beginingCell; set => beginingCell = value; }
        public Point EndCell { get => endCell; set => endCell = value; }
        public int MyImageId { get => myImageId; set => myImageId = value; }
        internal Cell[,] Maze { get => maze; set => maze = value; }
        public string Name { get => name; set => name = value; }
    }
}
