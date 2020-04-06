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
    public class My_Circle: TFigure
    {
        private double radius;
        private double x1;
        private double y1;
        private bool isMenuCaptured;
        private bool My_Visible;
        

        public double Radius { get => radius; set => radius = value; }
        public double X1 { get => x1; set => x1 = value; }
        public double Y1 { get => y1; set => y1 = value; }

        public My_Circle(double x1, double y1, double x, double y, bool _isMenu, Canvas canvas):base(x,y)
        {
            My_Visible = true;            
            radius = Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2));
            isMenuCaptured = _isMenu;
            if ((!isMenuCaptured && (x + radius > canvas.ActualWidth || x - radius < 0 || y + radius > canvas.ActualHeight || y - radius < 90)) 
                || (isMenuCaptured && (x + radius > canvas.ActualWidth + 250 || x - radius < 250 || y + radius > canvas.ActualHeight || y - radius < 140)))
            {
                MessageBox.Show("Радиус выходит за пределы CANVAS");
                Random rnd = new Random();
                while (true)
                {
                    radius = rnd.Next(0, 50);
                    if ((!isMenuCaptured && !(x + radius > canvas.ActualWidth || x - radius < 0 || y + radius > canvas.ActualHeight + 90 || y - radius < 90))
                        || (isMenuCaptured && !(x + radius > canvas.ActualWidth + 250 || x - radius < 250 || y + radius > canvas.ActualHeight + 140 || y - radius < 140))) { break; }
                }

            }
            MessageBox.Show("Объект My_Circle создан");
        }

        public My_Circle(Canvas canvas):base(canvas)
        {
            Random rnd = new Random();
            My_Visible = true;
            isMenuCaptured = false;
            radius = rnd.Next(20,100);
            MessageBox.Show("Объект My_Circle создан");
        }
        public override void Show(Canvas canvas, bool from_MOVE)
        { 
            if (isMenuCaptured)
            {
                L.Width = 2 * radius;
                L.Height = 2 * radius;
                Canvas.SetLeft(L, base.X - 250 - radius);
                Canvas.SetTop(L, base.Y - 140 - radius);
            }
            else
            {
                L.Width = 2 * radius;
                L.Height = 2 * radius;
                Canvas.SetLeft(L, base.X - radius);
                Canvas.SetTop(L, base.Y - 90 - radius);
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
            base.X += e.GetPosition(null).X - X;
            base.Y += e.GetPosition(null).Y - Y;
            try { Show(canvas, true); }
            catch (Exception) { }
        }

        public void Change_Radius(double Radius)
        {
            radius = Radius;
        }
        private Ellipse L = new Ellipse();
    }
}
