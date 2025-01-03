using Newtonsoft.Json;

namespace UML_Diagram_Editor.Entities
{
    public class Canvas
    {
        [JsonIgnore]
        public Selection? Selection { get; private set; }

        [JsonProperty]
        public List<Box> Boxes { get; private set; }

        [JsonProperty]
        public List<Line> Lines { get; private set; }

        public Canvas()
        {
            Boxes = new List<Box>();
            Lines = new List<Line>();
            Selection = null;
        }

        public void Draw(Graphics g)
        {
            foreach (var line in Lines)
                line.Draw(g);

            foreach (var obj in Boxes)
                obj.Draw(g);
        }

        public void Select(int x, int y)
        {
            Unselect();
            foreach (var box in Boxes)
            {
                if (box.IsInCollisionWithCorner(x, y))
                {
                    Selection = new ResizeSelection(box, x, y);
                    Selection.Select();
                    return;
                }
                else if (box.IsInCollision(x, y))
                {
                    Selection = new MoveSelection(box, x, y);
                    Selection.Select();
                    return;
                }
            }

            foreach (var line in Lines)
            {
                if (line.IsInCollision(x, y, out CustomPoint collisionPoint))
                {
                    Selection = new MoveSelection(collisionPoint, x, y);
                    Selection.Select();
                    return;
                }
            }
        }

        public void Unselect()
        {
            if (Selection == null)
                return;

            Selection.Unselect();
            Selection = null;
        }

        public void Move(int x, int y)
        {
            if (Selection == null)
                return;

            Selection.Move(x, y);
            Lines.Where(l => l.StartBox.Equals(Selection.SelectedObj) || l.EndBox.Equals(Selection.SelectedObj))
                .ToList()
                .ForEach(l => l.UpdateNearestSidePoints());
        }

        public void AddBox()
        {
            var box = new Box(250, 250);
            Boxes.Add(box);
        }

        public void AddLine(LineType lineType)
        {
            //TODO: Implement adding lines
            Box start = new(0,0);
            Box end = new(0, 0);
            var line = new Line(start, end, lineType);
            Lines.Add(line);
        }

        public void ReconnectLines()
        {
            foreach (var line in Lines)
            {
                line.StartBox = Boxes.FirstOrDefault(b => b.Equals(line.StartBox));
                line.EndBox = Boxes.FirstOrDefault(b => b.Equals(line.EndBox));

                line.UpdateNearestSidePoints();
            }
        }

        public void RemoveSelected()
        {
            if (Selection == null)
                return;

            if (Selection.SelectedObj is CustomPoint point)
            {
                RemovePointFromLines(point);
            }
            else if (Selection.SelectedObj is Box box)
            {
                RemoveBoxAndConnectedLines(box);
            }
            Unselect();
        }

        private void RemovePointFromLines(CustomPoint point)
        {
            foreach (var line in Lines)
            {
                if (line.IsInCollision(point.X, point.Y, out CustomPoint collisionPoint))
                {
                    line.RemovePoint(collisionPoint);
                    return;
                }
            }
        }

        private void RemoveBoxAndConnectedLines(Box box)
        {
            Lines.RemoveAll(line => line.StartBox.Equals(box) || line.EndBox.Equals(box));
            Boxes.Remove(box);
        }
    }
}
