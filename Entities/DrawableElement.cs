using Newtonsoft.Json;

namespace UML_Diagram_Editor.Entities
{
    public abstract class DrawableElement
    {
        [JsonProperty]
        public int X { get; protected set; }
        [JsonProperty]
        public int Y { get; protected set; }
        public virtual int Width { get; protected set; }
        public virtual int Height { get; protected set; }

        protected DrawableElement(int x, int y)
        {
            X = x;
            Y = y;

            Width = 80;
            Height = 80;
        }

        public abstract void Draw(Graphics g);
        public abstract void Select();
        public abstract void Unselect();

        public virtual void Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual bool IsInCollision(int x, int y)
        {
            return x > X && x <= X + Width
                && y > Y && y <= Y + Height;
        }

    }
}
