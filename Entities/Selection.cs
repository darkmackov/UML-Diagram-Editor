namespace UML_Diagram_Editor.Entities
{
    public abstract class Selection
    {
        public Box SelectedBox { get; protected set; }
        protected int _relativeX;
        protected int _relativeY;

        protected Selection(Box box, int x, int y)
        {
            SelectedBox = box;
            _relativeX = x - box.PositionX;
            _relativeY = y - box.PositionY;
        }

        public void Select()
        {
            SelectedBox.Select();
        }

        public void Unselect()
        {
            SelectedBox.Unselect();
        }

        public abstract void Move(int x, int y);
    }
}
