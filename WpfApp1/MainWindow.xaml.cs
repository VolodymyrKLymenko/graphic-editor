using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public bool isPressed;
        private static List<Button> _buttons = new List<Button>();
        private static Button _selectedButton;

        public MainWindow()
        {
            InitializeComponent();

            MyCanvas.Children.Add(Painter.FigureHost);

            for (int i = 0; i < Painter.Tools.Count; i++)
            {
                //string str = "../icons/" + Painter.Tools[i].GetType().Name + ".png";
                //ImageBrush img = new ImageBrush();
                //BitmapImage bi3 = new BitmapImage();
                //bi3.BeginInit();
                //bi3.UriSource = new Uri(str, UriKind.Relative);
                //bi3.EndInit();
                //img.ImageSource = bi3;

                Button btn = new Button();
                MyDockPanel.Children.Add(btn);
                btn.BorderBrush = Brushes.Black;
                btn.Name = "btn" + i;
                btn.Height = 35;
                btn.Width = 75;
                btn.Tag = i;
                btn.Content = Painter.Tools[i].GetType().Name;
                btn.Background = Painter.SelectedTool == Painter.Tools[i]
                    ? Brushes.AliceBlue
                    : Brushes.White;
                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.Click += new RoutedEventHandler(Tool_Click);

                _buttons.Add(btn);
            }

            Brush[] colors =
            {
                Brushes.Crimson,
                Brushes.Maroon,
                Brushes.DeepPink,
                Brushes.DarkOrange,
                Brushes.Yellow,
                Brushes.Fuchsia,
                Brushes.BlueViolet,
                Brushes.Indigo,
                Brushes.Lime,
                Brushes.Teal,
                Brushes.Aqua,
                Brushes.LightCyan,
                Brushes.Blue,
                Brushes.Navy,
                Brushes.White,
                Brushes.Ivory,
                Brushes.Black
            };

            foreach (var brush in colors)
            {
                var newButton = new Button()
                {
                    Width = 20,
                    Height = 20,
                    Background = brush,
                    Tag = brush
                };
                newButton.Click += new RoutedEventHandler(ButtonFill_Click);
                DockPanelFill.Children.Add(newButton);
            }

            var selectedButton = new Button()
            {
                Width = 20,
                Height = 20,
                Background = Brushes.Aqua,
                Tag = Brushes.Aqua
            };
            DockPanelSelectedFill.Children.Add(selectedButton);
            _selectedButton = selectedButton;
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isPressed = true;
            Painter.SelectedTool.MouseDown(e.GetPosition(MyCanvas));
            Invalidate();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                Painter.SelectedTool.MouseMove(e.GetPosition(MyCanvas));
                Invalidate();
            }

        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isPressed = false;
            Invalidate();
        }

        public void Invalidate()
        {
            Painter.FigureHost.children.Clear();
            var dv = new DrawingVisual();
            var dc = dv.RenderOpen();

            foreach (var figure in Painter.Figures)
            {
                figure.Draw(dc);
            }
            dc.Close();

            Painter.FigureHost.children.Add(dv);
        }


        private void Tool_Click(object sender, RoutedEventArgs e)
        {
            Painter.SelectedTool = Painter.Tools[Convert.ToInt32((sender as Button).Tag)];
            CheckToolsBackgroundColors();
        }

        private void ButtonFill_Click(object sender, RoutedEventArgs e)
        {
            var selectedBrush = (sender as Button).Tag as Brush;

            Painter.SelectedFill = selectedBrush;
            _selectedButton.Background = selectedBrush;
        }

        private void ButtonLine_Click(object sender, RoutedEventArgs e)
        {
            Painter.SelectedLine = (sender as Button).Tag as Pen;
        }

        private static void CheckToolsBackgroundColors()
        {
            var i = 0;
            foreach (var btn in _buttons)
            {
                btn.Background = Painter.SelectedTool == Painter.Tools[i++]
                    ? Brushes.AliceBlue
                    : Brushes.White;
            }
        }
    }
}
