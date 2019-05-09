using System.Windows;
using System.Windows.Media;

namespace WpfApp1.Figures
{
    public class Rectangle : Figure
    {
        public Rectangle(Point point, Brush strokeBrush) : base(point, strokeBrush) { }

        public override void Draw(DrawingContext drawingContext)
        {
            Rect rectangle = new Rect(_points[0], _points[1]);
            Pen pen = new Pen(_stokeColor, 5);

            drawingContext.DrawRectangle(null, pen, rectangle);
        }

        public override void AddPoint(Point point)
        {
            _points[1] = point;
        }
    }
}
