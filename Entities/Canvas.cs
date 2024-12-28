namespace UML_Diagram_Editor.Entities
{
    public class Canvas
    {
        public Selection? Selection { get; private set; }

        private List<Box> _boxes;

        public Canvas()
        {
            _boxes = new List<Box>();
            Selection = null;
        }

        public void Draw(Graphics g)
        {
            foreach (Box box in _boxes)
                box.Draw(g);
        }

        public void Select(int x, int y)
        {
            Unselect();
            for (int i = 0; i < _boxes.Count; i++)
            {
                Box box = _boxes[i];
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
            _boxes.Add(box);
        }

        public void RemoveBox()
        {
            if (Selection == null)
                return;

            _boxes.Remove(Selection.SelectedBox);
            Unselect();
        }
    }
}
