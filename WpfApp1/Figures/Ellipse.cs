using System.Windows;
using System.Windows.Media;

namespace WpfApp1.Figures
{
    public class Ellipse : Figure
    {
        public Ellipse(Point point, Point point1, Brush brush) : base(point, brush) { }

        public override void Draw(DrawingContext drawingContext)
        {
            Ellipse ellipse = new Ellipse(_points[0], _points[1], _stokeColor);
            Pen pen = new Pen(_stokeColor, 5);

            Vector center = Point.Subtract(_points[1], _points[0]) / 2;
            drawingContext.DrawEllipse(null, pen, Point.Add(_points[0], center), center.X, center.Y);
        }

        public override void AddPoint(Point point)
        {
            _points[1] = point;
        }
    }
}
