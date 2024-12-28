using Newtonsoft.Json;

namespace UML_Diagram_Editor.Entities
{
    public class Box
    {
        [JsonProperty]
        public int PositionX { get; private set; }
        [JsonProperty]
        public int PositionY { get; private set; }
        [JsonProperty]
        public int Width { get; private set; }
        [JsonProperty]
        public int Height { get; private set; }
        public string Title { get; set; }
        public List<TextContent> Variables { get; set; }
        public List<TextContent> Methods { get; set; }

        [JsonProperty]
        public int MinWidth { get; private set; }
        [JsonProperty]
        public int MinHeight { get; private set; }
        public int MaxWidth => 240 + MinWidth;
        public int MaxHeight => 280 + MinHeight;

        private Pen _color;

        public Box(int x, int y)
        {
            PositionX = x;
            PositionY = y;

            Width = 80;
            Height = 80;

            MinWidth = 80;
            MinHeight = 40;

            Title = "Class";
            Variables = new List<TextContent>();
            Methods = new List<TextContent>();

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

        public void UpdateMinSize()
        {
            int maxVarLength = Variables.Any() ? Variables.Max(v => v.Content.Length) : 0;
            int maxMetLength = Methods.Any() ? Methods.Max(m => m.Content.Length) : 0;

            int maxLength = Math.Max(Math.Max(maxVarLength, maxMetLength), Title.Length);

            MinWidth = (maxLength + 2) * 7;
            MinHeight = (Variables.Count + Methods.Count + 2) * 20;
        }


        public void Draw(Graphics g)
        {
            g.TranslateTransform(PositionX, PositionY);
            g.FillRectangle(Brushes.White, 0, 0, Width, Height);
            g.DrawRectangle(_color, 0, 0, Width, Height);

            g.DrawString(Title, new Font("Arial", 10), Brushes.Black, 5, 5);
            g.DrawLine(Pens.Black, 0, 25, Width, 25);

            int offset = 10;
            foreach (var variable in Variables)
            {
                offset += 20;
                g.DrawString(variable.Content, new Font("Arial", 10), Brushes.Black, 5, offset);
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
