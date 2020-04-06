
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MenuAnimation
{
    public class My_Rectangle :quadrangle
    {
        private bool isMenuCaptured;
        private bool My_Visible;
        

        public My_Rectangle(double x, double y, double x2, double y2, bool _isMenu):base(x,y,x2,y2)
        {
            My_Visible = true;
            isMenuCaptured = _isMenu;
            MessageBox.Show("Создан объект My_Rectangle");
        }
        public My_Rectangle(Canvas canvas):base(canvas)
        {  
            My_Visible = true;
            isMenuCaptured = false;
            MessageBox.Show("Создан объект My_Rectangle");
        }
        public override void Show(Canvas canvas, bool from_MOVE)
        {
            MessageBox.Show(Convert.ToString(base.Height));
            PointCollection polygonPoints = new PointCollection();
            if (isMenuCaptured)
            {
                polygonPoints.Add(new Point(base.X - 250, base.Y - 140));
                polygonPoints.Add(new Point(base.X - 250, base.Y + base.Height - 140));
                polygonPoints.Add(new Point(base.X + base.Width - 250, base.Y + base.Height - 140));
                polygonPoints.Add(new Point(base.X + base.Width - 250, base.Y - 140));
                polygonPoints.Add(new Point(base.X - 250, base.Y - 140));
            }
            else
            {
                polygonPoints.Add(new Point(base.X, base.Y - 90));
                polygonPoints.Add(new Point(base.X, base.Y + base.Height - 90));
                polygonPoints.Add(new Point(base.X + base.Width, base.Y + base.Height - 90));
                polygonPoints.Add(new Point(base.X + base.Width, base.Y - 90));
                polygonPoints.Add(new Point(base.X, base.Y - 90));
            }
            L.Points = polygonPoints;
            L.StrokeThickness = 5;
            L.Stroke = Brushes.Black;
            if (!from_MOVE)
            {
                if (My_Visible)
                {
                    Canvas.SetZIndex(L, 100);
                    My_Visible = false;
                    canvas.Children.Add(L);
                }
                else
                {
                    canvas.Children.Remove(L);
                    My_Visible = true;
                }
            }

            
        }
        public override void MoveTo(MouseEventArgs e, Canvas canvas, double X, double Y)
        {
            base.X += e.GetPosition(null).X - X;
            base.Y += e.GetPosition(null).Y - Y;
            try { Show(canvas, true); }
            catch (Exception) { }

        }
        private Polyline L = new Polyline();
    }
}
