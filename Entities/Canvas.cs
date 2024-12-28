using Newtonsoft.Json;

namespace UML_Diagram_Editor.Entities
{
    public class Canvas
    {
        [JsonIgnore]
        public Selection? Selection { get; private set; }

        [JsonProperty]
        public List<Box> Boxes { get; private set; }

        public Canvas()
        {
            Boxes = new List<Box>();
            Selection = null;
        }

        public void Draw(Graphics g)
        {
            foreach (Box box in Boxes)
                box.Draw(g);
        }

        public void Select(int x, int y)
        {
            Unselect();
            for (int i = 0; i < Boxes.Count; i++)
            {
                Box box = Boxes[i];
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
        }

        public void AddBox()
        {
            var box = new Box(250, 250);
            Boxes.Add(box);
        }

        public void RemoveBox()
        {
            if (Selection == null)
                return;

            Boxes.Remove(Selection.SelectedBox);
            Unselect();
        }
    }
}
