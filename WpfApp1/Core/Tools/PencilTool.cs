using System.Windows;

using WpfApp1.Figures;

namespace WpfApp1.Tools
{
    public class PencilTool : Tool
    {
        public override void MouseDown(Point pos)
        {
            Painter.Figures.Add(new Pencil(pos, Painter.SelectedFill));
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
