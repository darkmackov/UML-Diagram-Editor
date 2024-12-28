namespace UML_Diagram_Editor.Entities
{
    public class ResizeSelection : Selection
    {
        public ResizeSelection(Box box, int x, int y)
            : base(box, x, y)
        { }

        public override void Move(int x, int y)
        {
            int dx = SelectedBox.Width - _relativeX;
            int dy = SelectedBox.Height - _relativeY;

            SelectedBox.Resize(x - SelectedBox.PositionX + dx, y - SelectedBox.PositionY + dy);

            _relativeX = SelectedBox.Width - dx;
            _relativeY = SelectedBox.Height - dy;
        }
    }
}
