using System.Windows;
using System.Windows.Media;

namespace WpfApp1
{
    public class FigureHost : FrameworkElement
    {
        public VisualCollection children;

        public FigureHost()
        {
            children = new VisualCollection(this);
        }

        protected override int VisualChildrenCount => children.Count;

        protected override Visual GetVisualChild(int index)
        {
            return children[index];
        }
    }
}
