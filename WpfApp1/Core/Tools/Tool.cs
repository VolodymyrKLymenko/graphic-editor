using System.Windows;

namespace WpfApp1.Tools
{
    public abstract class Tool
    {
        public abstract void MouseDown(Point pos);

        public abstract void MouseMove(Point pos);

        public abstract void MouseUp(Point pos);
    }
}
