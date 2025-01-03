namespace UML_Diagram_Editor.Entities
{
    public class Line
    {
        public Box StartBox { get; set; }
        public string StartMultiplicity { get; set; }
        public Box EndBox { get; set; }
        public string EndMultiplicity { get; set; }
        public LineType LineType { get; set; }
        public List<CustomPoint> Points { get; private set; }

        private readonly Pen _pen;

        public Line(Box startBox, Box endBox, LineType lineType = LineType.Association)
        {
            StartBox = startBox;
            StartMultiplicity = "1";
            EndBox = endBox;
            EndMultiplicity = "1";
            LineType = lineType;
            Points = [];
            _pen = new Pen(Color.Black, 2);
        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < Points.Count - 1; i++)
                g.DrawLine(_pen,Points[i],Points[i + 1]);

            for (int i = 1; i < Points.Count - 1; i++)
                Points[i].Draw(g);

            DrawLineType(g);

            DrawMultiplicity(g, StartMultiplicity, Points[0], StartBox);
            DrawMultiplicity(g, EndMultiplicity, Points[^1], EndBox);
        }

        public void SetDefaultPoints()
        {
            if (Points.Count > 0)
                return;

            Points = 
            [
                new(StartBox.X + StartBox.Width / 2, StartBox.Y + StartBox.Height / 2),
                new(EndBox.X + EndBox.Width / 2, EndBox.Y + EndBox.Height / 2)
            ];
            UpdateNearestSidePoints();
        }

        public void UpdateNearestSidePoints()
        {
            if (StartBox == null || EndBox == null) 
                return;

            Point startReferencePoint = Points.Count > 1
                ? Points[1]
                : new Point(EndBox.X + EndBox.Width / 2, EndBox.Y + EndBox.Height / 2);

            Point endReferencePoint = Points.Count > 1
                ? Points[^2]
                : new Point(StartBox.X + StartBox.Width / 2, StartBox.Y + StartBox.Height / 2);

            Points[0] = GetCenterOfNearestSide(StartBox, startReferencePoint);
            Points[^1] = GetCenterOfNearestSide(EndBox, endReferencePoint);
        }

        public void AddPoint(CustomPoint point)
        {
            CustomPoint lastPoint = Points.Last();
            Points[^1] = point;
            Points.Add(lastPoint);
        }

        public void RemovePoint(CustomPoint point)
        {
            Points.Remove(point);
        }

        public bool IsInCollision(int x, int y, out CustomPoint? collisionPoint)
        {
            foreach (var point in Points.Where(point => point.IsInCollision(x, y)))
            {
                collisionPoint = point;
                return true;
            }

            collisionPoint = null;
            return false;
        }

        private Point RotatePoint(Point point, float angle, Point origin)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            int x = origin.X + (int)((point.X) * cos - (point.Y) * sin);
            int y = origin.Y + (int)((point.X) * sin + (point.Y) * cos);

            return new Point(x, y);
        }

        private Point GetCenterOfNearestSide(Box box, Point targetPoint)
        {
            Point[] sides = 
            [
                new(box.X, box.Y + box.Height / 2),
                new(box.X + box.Width, box.Y + box.Height / 2),
                new(box.X + box.Width / 2, box.Y),
                new(box.X + box.Width / 2, box.Y + box.Height)
            ];

            return sides.MinBy(p => GetDistance(p, targetPoint));
        }

        private double GetDistance(Point p1, Point p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        private void DrawMultiplicity(Graphics g, string multiplicity, Point point, Box box)
        {
            if (StartBox == null || EndBox == null)
                return;

            Point nearestSidePoint = GetCenterOfNearestSide(box, point);

            int boxCenterX = box.X + box.Width / 2;
            int boxCenterY = box.Y + box.Height / 2;

            int baseOffsetX = 0;
            int baseOffsetY = 0;

            if (nearestSidePoint.X == boxCenterX)
            {
                baseOffsetY = nearestSidePoint.Y < boxCenterY 
                    ? -24 
                    : 12;
            }
            else if (nearestSidePoint.Y == boxCenterY)
            {
                baseOffsetX = nearestSidePoint.X < boxCenterX 
                    ? -24 
                    : 12;
            }

            g.DrawString(multiplicity, new Font("Arial", 12, FontStyle.Bold), Brushes.Red, new Point(point.X + baseOffsetX, point.Y + baseOffsetY));
        }

        private void DrawLineType(Graphics g)
        {
            if (Points.Count < 2)
                return;

            Point secondToLast = Points[^2];
            Point last = Points[^1];

            float dx = last.X - secondToLast.X;
            float dy = last.Y - secondToLast.Y;
            float angle = (float)Math.Atan2(dy, dx) - (float)(Math.PI / 2);

            switch (LineType)
            {
                case LineType.Aggregation:
                    {
                        Point[] diamondPoints =
                        [
                            RotatePoint(new Point(0, 0), angle, last),
                            RotatePoint(new Point(-10, -5), angle, last),
                            RotatePoint(new Point(0, -10), angle, last),
                            RotatePoint(new Point(10, -5), angle, last)
                        ];

                        g.FillPolygon(Brushes.White, diamondPoints);
                        g.DrawPolygon(_pen, diamondPoints);
                    }
                    break;

                case LineType.Composition:
                    {
                        Point[] filledDiamondPoints =
                        [
                            RotatePoint(new Point(0, 0), angle, last),
                            RotatePoint(new Point(-10, -5), angle, last),
                            RotatePoint(new Point(0, -10), angle, last),
                            RotatePoint(new Point(10, -5), angle, last)
                        ];

                        g.FillPolygon(Brushes.Black, filledDiamondPoints);
                    }
                    break;

                case LineType.Generalization:
                    {
                        Point[] trianglePoints =
                        [
                            RotatePoint(new Point(0, 0), angle, last),
                            RotatePoint(new Point(-15, -15), angle, last),
                            RotatePoint(new Point(15, -15), angle, last)
                        ];

                        g.FillPolygon(Brushes.White, trianglePoints);
                        g.DrawPolygon(_pen, trianglePoints);
                    }
                    break;

                case LineType.OneWayAssociation:
                    {
                        Point arrowEnd1 = RotatePoint(new Point(10, -15), angle, last);
                        Point arrowEnd2 = RotatePoint(new Point(-10, -15), angle, last);

                        g.DrawLine(_pen, last, arrowEnd1);
                        g.DrawLine(_pen, last, arrowEnd2);
                    }
                    break;
            }
        }
    }
}
