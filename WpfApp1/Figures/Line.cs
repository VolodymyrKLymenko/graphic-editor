using System.Windows;
using System.Windows.Media;

namespace WpfApp1.Figures
{
    public class Line : Figure
    {
        public Line(Point point, Brush strokeBrush) : base(point, strokeBrush) { }

        public override void Draw(DrawingContext drawingContext)
        {
            drawingContext.DrawLine(new Pen(_stokeColor, 4), _points[0], _points[1]);
        }

        public override void AddPoint(Point point)
        {
            _points[1] = point;
        }
    }
}
