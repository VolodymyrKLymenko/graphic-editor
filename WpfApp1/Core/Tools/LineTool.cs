using System.Windows;

using WpfApp1.Figures;

namespace WpfApp1.Tools
{
    public class LineTool : Tool
    {
        public override void MouseDown(Point pos)
        {
            Painter.Figures.Add(new Line(pos, Painter.SelectedFill));
        }

        public override void MouseMove(Point pos)
        {
            Painter.Figures[Painter.Figures.Count - 1].AddPoint(pos);
        }

        public override void MouseUp(Point pos)
        {

        }
    }
}
