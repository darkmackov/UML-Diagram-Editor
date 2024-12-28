namespace UML_Diagram_Editor.Entities
{
    public class MoveSelection : Selection
    {
        public MoveSelection(Box box, int x, int y)
            : base(box, x, y)
        { }

        public override void Move(int x, int y)
        {
            SelectedBox.Move(x - _relativeX, y - _relativeY);
        }
    }
}
