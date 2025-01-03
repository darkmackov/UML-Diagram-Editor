using Newtonsoft.Json;

namespace UML_Diagram_Editor.Entities
{
    public class Box : DrawableElement
    {
        public string Title { get; set; }
        public List<TextContent> Properties { get; set; }
        public List<TextContent> Methods { get; set; }

        [JsonProperty]
        public int MinWidth { get; private set; }
        [JsonProperty]
        public int MinHeight { get; private set; }
        public int MaxWidth => 240 + MinWidth;
        public int MaxHeight => 280 + MinHeight;

        private Pen _color;

        public Box(int x, int y) 
            : base(x, y)
        {
            MinWidth = 80;
            MinHeight = 40;

            Title = "Class";
            Properties = new List<TextContent>();
            Methods = new List<TextContent>();

            _color = Pens.Black;
        }

        public override void Select()
        {
            _color = Pens.Blue;
        }

        public override void Unselect()
        {
            _color = Pens.Black;
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

        public void UpdateMinSize()
        {
            int maxVarLength = Properties.Any() ? Properties.Max(v => v.Content.Length) : 0;
            int maxMetLength = Methods.Any() ? Methods.Max(m => m.Content.Length) : 0;

            int maxLength = Math.Max(Math.Max(maxVarLength, maxMetLength), Title.Length);

            MinWidth = (maxLength + 2) * 7;
            MinHeight = (Properties.Count + Methods.Count + 2) * 20;
        }

        public override void Draw(Graphics g)
        {
            g.TranslateTransform(X, Y);
            g.FillRectangle(Brushes.White, 0, 0, Width, Height);
            g.DrawRectangle(_color, 0, 0, Width, Height);

            g.DrawString(Title, new Font("Arial", 10), Brushes.Black, 5, 5);
            g.DrawLine(Pens.Black, 0, 25, Width, 25);

            int offset = 10;
            foreach (var property in Properties)
            {
                offset += 20;
                g.DrawString(property.Content, new Font("Arial", 10), Brushes.Black, 5, offset);
            }

            g.DrawLine(Pens.Black, 0, offset + 20, Width, offset + 20);
            offset += 5;

            foreach (var method in Methods)
            {
                offset += 20;
                g.DrawString(method.Content, new Font("Arial", 10), Brushes.Black, 5, offset);
            }

            g.FillRectangle(Brushes.Green, Width - 10, Height - 10, 10, 10);
            g.ResetTransform();
        }

        public bool IsInCollisionWithCorner(int x, int y)
        {
            return x > (X + Width - 10) && x <= X + Width
                                                && y > (Y + Height - 10) && y <= Y + Height;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not Box other)
                return false;

            return Title == other.Title &&
                   X == other.X &&
                   Y == other.Y &&
                   Width == other.Width &&
                   Height == other.Height &&
                   MinWidth == other.MinWidth &&
                   MinHeight == other.MinHeight &&
                   Properties.SequenceEqual(other.Properties) &&
                   Methods.SequenceEqual(other.Methods);
        }
    }
}
