using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

using WpfApp1.Figures;
using WpfApp1.Tools;

namespace WpfApp1
{

    public static class Painter
    {
        public static List<Figure> Figures = new List<Figure>();
        public static Brush SelectedFill = Brushes.Aqua;
        public static Pen SelectedLine = new Pen(Brushes.Aqua, 5);

        public static readonly List<Tool> Tools = new List<Tool>
        {
            new PencilTool(),
            new LineTool(),
            new EllipseTool(),
            new RectangleTool(),
            new RoundedRectangleTool(),

        };


        public static Tool SelectedTool = Tools[0];

        public static FigureHost FigureHost = new FigureHost();

        public static Vector Move; 
    }
}
