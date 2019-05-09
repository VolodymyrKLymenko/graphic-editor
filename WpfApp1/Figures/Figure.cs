using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1.Figures
{
    public abstract class Figure
    {
        protected Brush _stokeColor;

        protected List<Point> _points;

        public Figure(Point point, Brush strokeBrush)
        {
            _points = new List<Point> { point, point };
            _stokeColor = strokeBrush;
        }

        public abstract void Draw(DrawingContext drawingContext);

        public abstract void AddPoint(Point point);
    }
}
