namespace UML_Diagram_Editor.Entities
{
    public class Box
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int MinWidth => 80;
        public int MinHeight => 40;
        public int MaxWidth => 320;
        public int MaxHeight => 320;

        private Pen _color;

        public Box(int x, int y)
        {
            PositionX = x;
            PositionY = y;

            Width = 80;
            Height = 80;
            _color = Pens.Black;
        }

        public void Select()
        {
            _color = Pens.Blue;
        }

        public void Unselect()
        {
            _color = Pens.Black;
        }

        public void Move(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public void Resize(int w, int h)
        {
            if (w < MinWidth)
                w = MinWidth;

            if (h < MinHeight)
                h = MinHeight;

            if (w > MaxWidth)
                w = MaxWidth;

            if (h > MaxHeight)
                h = MaxHeight;

            Width = w;
            Height = h;
        }

        public void Draw(Graphics g)
        {
            g.TranslateTransform(PositionX, PositionY);
            g.FillRectangle(Brushes.White, 0, 0, Width, Height);
            g.DrawRectangle(_color, 0, 0, Width, Height);
            g.FillRectangle(Brushes.Green, Width - 10, Height - 10, 10, 10);
            g.ResetTransform();
        }

        public bool IsInCollision(int x, int y)
        {
            return x > PositionX && x <= PositionX + Width
                                 && y > PositionY && y <= PositionY + Height;
        }

        public bool IsInCollisionWithCorner(int x, int y)
        {
            return x > (PositionX + Width - 10) && x <= PositionX + Width
                                                && y > (PositionY + Height - 10) && y <= PositionY + Height;
        }
    }
}
