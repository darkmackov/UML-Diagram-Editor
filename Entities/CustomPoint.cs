namespace UML_Diagram_Editor.Entities
{
    public class CustomPoint : DrawableElement
    {
        private Brush _color;

        public CustomPoint(int x, int y) 
            : base(x, y)
        {
            _color = Brushes.DarkGray;

            Width = 8;
            Height = 8;
        }

        public override void Draw(Graphics g)
        {
            g.TranslateTransform(X - Width, Y - Height);
            g.FillEllipse(_color, 0 + Width / 2, 0 + Height / 2, Width, Height);
            g.ResetTransform();
        }

        public override bool IsInCollision(int x, int y)
        {
            return x > X - Width / 2 && x <= X + Width / 2
                                     && y > Y - Height / 2 && y <= Y + Height / 2;
        }

        public override void Select()
        {
            _color = Brushes.Blue;
        }

        public override void Unselect()
        {
            _color = Brushes.DarkGray;
        }

        public static implicit operator Point(CustomPoint p)
        {
            return new Point(p.X, p.Y);
        }

        public static implicit operator CustomPoint(Point point)
        {
            return new CustomPoint(point.X, point.Y);
        }
    }
}
