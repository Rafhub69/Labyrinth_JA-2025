namespace finalProjectJA_2025
{
    public enum Roles
    {
        Empty,
        Wall,
        Begining,
        End,
        Path
    };

    internal class Cell
    {
        Dictionary<string, Color> borderColor = new Dictionary<string, Color>();
        Dictionary<string, Color> roleColor = new Dictionary<string, Color>();
        Size[] neighbors = new Size[4];
        int distanceFromStart = -1;
        int distanceFromEnd = -1;
        int totalDistance = -1;
        Rectangle rectangle;
        Size parent;
        Roles role;

        public Cell()
        {
            setColor();

            Parent = new Size(-1, -1);
            Rectangle = new Rectangle(0, 0, 50, 50);

            Neighbors[0] = new Size(-1, -1);//left
            Neighbors[1] = new Size(-1, -1);//right
            Neighbors[2] = new Size(-1, -1);//top
            Neighbors[3] = new Size(-1, -1);//bottom
        }

        public Cell(Size newParent, Rectangle newRectangle)
        {
            setColor();

            Parent = newParent;

            Neighbors[0] = new Size(-1, -1);
            Neighbors[1] = new Size(-1, -1);
            Neighbors[2] = new Size(-1, -1);
            Neighbors[3] = new Size(-1, -1);

            this.rectangle = newRectangle;
        }

        public Cell(int newParentX, int newParentY, Rectangle newRectangle)
        {
            Parent = new Size(newParentX, newParentY);

            this.rectangle = newRectangle;

            setColor();
        }

        private void setColor()
        {
            RoleColor.Add(Roles.Empty.ToString(), Color.White);
            RoleColor.Add(Roles.Wall.ToString(), Color.DarkGray);
            RoleColor.Add(Roles.Begining.ToString(), Color.Red);
            RoleColor.Add(Roles.End.ToString(), Color.Blue);
            RoleColor.Add(Roles.Path.ToString(), Color.Firebrick);

            BorderColor.Add(Roles.Empty.ToString(), Color.Black);
            BorderColor.Add(Roles.Wall.ToString(), Color.Black);
            BorderColor.Add(Roles.Begining.ToString(), Color.Black);
            BorderColor.Add(Roles.End.ToString(), Color.Black);
            BorderColor.Add(Roles.Path.ToString(), Color.Black);
        }

        public Color getRoleColor(string name)
        {
            if(!RoleColor.Keys.Contains(name))
            {
                return Color.White;
            }

            return RoleColor[name];
        }

        public Dictionary<string, Color> BorderColor { get => borderColor; set => borderColor = value; }
        public Dictionary<string, Color> RoleColor { get => roleColor; set => roleColor = value; }
        public int DistanceFromStart { get => distanceFromStart; set => distanceFromStart = value; }
        public int DistanceFromEnd { get => distanceFromEnd; set => distanceFromEnd = value; }
        public int TotalDistance { get => totalDistance; set => totalDistance = value; }
        public Rectangle Rectangle { get => rectangle; set => rectangle = value; }
        public Size[] Neighbors { get => neighbors; set => neighbors = value; }
        public Size Parent { get => parent; set => parent = value; }
        public Roles Role { get => role; set => role = value; }
    }
}
