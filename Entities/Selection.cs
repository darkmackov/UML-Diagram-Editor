namespace UML_Diagram_Editor.Entities
{
    public abstract class Selection
    {
        public DrawableElement SelectedObj { get; protected set; }
        protected int _relativeX;
        protected int _relativeY;

        protected Selection(DrawableElement obj, int x, int y)
        {
            SelectedObj = obj;
            _relativeX = x - obj.X;
            _relativeY = y - obj.Y;
        }

        public void Select() => SelectedObj.Select();
        public void Unselect() => SelectedObj.Unselect();

        public abstract void Move(int x, int y);
    }
}
