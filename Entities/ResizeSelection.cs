namespace UML_Diagram_Editor.Entities
{
    public class ResizeSelection : Selection
    {
        public ResizeSelection(Box box, int x, int y)
            : base(box, x, y)
        { }

        public override void Move(int x, int y)
        {
            int dx = SelectedObj.Width - _relativeX;
            int dy = SelectedObj.Height - _relativeY;

            Box selectedBox = (Box)SelectedObj;
            selectedBox.Resize(x - SelectedObj.X + dx, y - SelectedObj.Y + dy);

            _relativeX = SelectedObj.Width - dx;
            _relativeY = SelectedObj.Height - dy;
        }
    }
}
