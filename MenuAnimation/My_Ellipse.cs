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
    public class My_Ellipse:My_Circle
    {
        private double radius2;
        private double x0;
        private double y0;
        private bool isMenuCaptured;
        private bool My_Visible;
        

        
        public double Radius2 { get => radius2; set => radius2 = value; }
        public double X0 { get => x0; set => x0 = value; }
        public double Y0 { get => y0; set => y0 = value; }

        public My_Ellipse(double x2, double y2, double x, double y, bool _isMenu,Canvas canvas):base(x2,y2,x,y,_isMenu,canvas)
        {
            My_Visible = true;
            isMenuCaptured = _isMenu;
            x0 = (x2 + x) / 2;
            y0 = (y2 + y) / 2;
            base.Radius = Math.Abs(x2 - x0);
            radius2 = Math.Abs(y2 - y0);
            MessageBox.Show("Объект My_Ellipse создан");
        }

        public My_Ellipse(Canvas canvas):base(canvas)
        {
            Random rnd = new Random();
            My_Visible = true;
            isMenuCaptured = false;
            x0 = rnd.Next(0, Convert.ToInt32(canvas.ActualWidth));
            y0 = rnd.Next(90, Convert.ToInt32(canvas.ActualHeight));
            base.Radius = rnd.Next(20, 150);
            radius2 = rnd.Next(20, 150);
            MessageBox.Show("Объект My_Ellipse создан");
        }
        public override void Show(Canvas canvas, bool from_MOVE)
        {
            
            if (isMenuCaptured)
            {
                L.Width = 2 * base.Radius;
                L.Height = 2 * radius2;
                Canvas.SetLeft(L, X0 - 250 - base.Radius);
                Canvas.SetTop(L, Y0 - 140 - radius2);
            }
            else
            {
                L.Width = 2 * base.Radius;
                L.Height = 2 * radius2;
                Canvas.SetLeft(L, X0 - base.Radius);
                Canvas.SetTop(L, Y0 - 90 - radius2);
            }

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
            x0 += e.GetPosition(null).X - X;
            y0 += e.GetPosition(null).Y - Y;
            try { Show(canvas, true); }
            catch (Exception) { }
        }

        public void turn_90()
        {
            double t = radius2;
            radius2 = base.Radius;
            base.Radius = t;
        }
        private Ellipse L = new Ellipse();
    }
}
