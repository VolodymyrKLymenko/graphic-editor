using System.Windows;
using System.Windows.Media;

namespace WpfApp1.Figures
{
    public class Pencil : Figure
    {
        public Pencil(Point point, Brush strokeBrush) : base(point, strokeBrush) { }

        public override void Draw(DrawingContext drawingContext)
        {
            Pen pen = new Pen(_stokeColor, 5);
            pen.Freeze();

            var geometry = new StreamGeometry();
            using (var ctx = geometry.Open())
            {
                ctx.BeginFigure(_points[0], false, false);
                for (var i = 1; i < _points.Count; ++i)
                {
                    ctx.LineTo(_points[i], true, false);
                }

            }
            geometry.Freeze();

            drawingContext.DrawGeometry(_stokeColor, pen, geometry);
        }

        public override void AddPoint(Point point)
        {
            _points.Add(point);
        }
    }
}
