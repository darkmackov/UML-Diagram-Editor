namespace UML_Diagram_Editor.Entities
{
    public class MoveSelection : Selection
    {
        public MoveSelection(DrawableElement obj, int x, int y)
            : base(obj, x, y)
        { }

        public override void Move(int x, int y)
        {
            SelectedObj.Move(x - _relativeX, y - _relativeY);
        }
    }
}
