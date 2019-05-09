using System.Windows;
using System.Windows.Media;

namespace WpfApp1.Figures
{
    public class RoundedRectangle : Figure
    {
        public RoundedRectangle(Point point, Point point1, Brush strokeBrush) : base(point, strokeBrush) { } 

        public override void Draw(DrawingContext drawingContext)
        {
            
            Pen pen = new Pen(_stokeColor, 5);
            Vector point0 = Point.Subtract(_points[0], _points[1]);

            drawingContext.DrawRoundedRectangle(null, pen, new Rect(_points[1], point0), 20.0, 20.0);
        }

        public override void AddPoint(Point point)
        {
            _points[1] = point;
        }
    }
}
