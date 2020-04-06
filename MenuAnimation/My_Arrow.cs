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
    public class My_Arrow
    {
        private double x1;
        private double y1;
        private double width;
        private double height;
        private bool isMenuCaptured;
        private bool My_Visible;
        

        public double X1 { get => x1; set => x1 = value; }
        public double Y1 { get => y1; set => y1 = value; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }

        public My_Arrow(MouseEventArgs e, double x, double y, bool _isMenu)
        {
            My_Visible = true;
            x1 = x;
            y1 = y;
            isMenuCaptured = _isMenu;
            width = e.GetPosition(null).X - x;
            height = e.GetPosition(null).Y - y;
        }

        public My_Arrow(Canvas canvas)
        {
            Random rnd = new Random();
            My_Visible = true;
            isMenuCaptured = false;
            x1 = rnd.Next(0, Convert.ToInt32(canvas.ActualWidth));
            y1 = rnd.Next(90, Convert.ToInt32(canvas.ActualHeight));
            width = rnd.Next(0, 350);
            height = rnd.Next(0, 350);
        }
       
        public void Show(Canvas canvas, bool from_MOVE)
        {

            PointCollection polygonPoints = new PointCollection();
            if (isMenuCaptured)
            {
                polygonPoints.Add(new Point(X1 - 250, Y1 - 140 + height*0.2));
                polygonPoints.Add(new Point(X1 - 250, Y1 - 140 + height*0.8));
                polygonPoints.Add(new Point(X1 + width*0.6 - 250, Y1 - 140 + height * 0.8));
                polygonPoints.Add(new Point(X1 + width*0.6 - 250, Y1 - 140 + height));
                polygonPoints.Add(new Point(X1 - 250 + width, Y1 - 140 + height*0.5));
                polygonPoints.Add(new Point(X1 + width * 0.6 - 250, Y1 - 140));
                polygonPoints.Add(new Point(X1 + width * 0.6 - 250, Y1 - 140 + height * 0.2));
                polygonPoints.Add(new Point(X1 - 250, Y1 - 140 + height * 0.2));
            }
            else
            {
                polygonPoints.Add(new Point(X1, Y1 - 90 + height * 0.2));
                polygonPoints.Add(new Point(X1, Y1 - 90 + height * 0.8));
                polygonPoints.Add(new Point(X1 + width * 0.6, Y1 - 90 + height * 0.8));
                polygonPoints.Add(new Point(X1 + width * 0.6, Y1 - 90 + height));
                polygonPoints.Add(new Point(X1 + width, Y1 - 90 + height * 0.5));
                polygonPoints.Add(new Point(X1 + width * 0.6, Y1 - 90));
                polygonPoints.Add(new Point(X1 + width * 0.6, Y1 - 90 + height * 0.2));
                polygonPoints.Add(new Point(X1, Y1 - 90 + height * 0.2));
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
        public void MoveTo(MouseEventArgs e, Canvas canvas, double X, double Y)
        {
            x1 += e.GetPosition(null).X - X;
            y1 += e.GetPosition(null).Y - Y;
            try { Show(canvas, true); }
            catch (Exception) { }

        }
        public void Delete(Canvas canvas)
        {
            canvas.Children.Remove(L);
        }
        private Polyline L = new Polyline();
    }
}
