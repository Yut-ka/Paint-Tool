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
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using MenuAnimation;


namespace MenuAnimation
{ 
    public class My_Line
    {
        private double x2;
        private double y2;
        private double x1;
        private double y1;
        bool isMenuCaptured;
        
        public bool My_Visible;

        public double X2 { get => x2; set => x2 = value; }
        public double Y2 { get => y2; set => y2 = value; }
        public double X1 { get => x1; set => x1 = value; }
        public double Y1 { get => y1; set => y1 = value; }

        public My_Line(MouseEventArgs e, double x, double y, bool _isMenu)
        {
            My_Visible = true;
            X2 = e.GetPosition(null).X;
            Y2 = e.GetPosition(null).Y;
            X1 = x;
            Y1 = y;
            isMenuCaptured = _isMenu;
        }

        public My_Line(Canvas canvas)
        {
            Random rnd = new Random();
            My_Visible = true;
            isMenuCaptured = false;
            x1 = rnd.Next(0, Convert.ToInt32(canvas.ActualWidth));
            y1 = rnd.Next(90, Convert.ToInt32(canvas.ActualHeight));
            x2 = rnd.Next(0, Convert.ToInt32(canvas.ActualWidth));
            y2 = rnd.Next(90, Convert.ToInt32(canvas.ActualHeight));
        }

        public My_Line()
        {

        }

        public void Show(Canvas canvas, bool from_MOVE)
        {
            if (isMenuCaptured)
            {
                L.X2 = X2 - 250;
                L.Y2 = Y2 - 140;
                L.X1 = X1 - 250;
                L.Y1 = Y1 - 140;
            }
            else
            {
                L.X2 = X2;
                L.Y2 = Y2 - 90;
                L.X1 = X1;
                L.Y1 = Y1 - 90;
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

        


        public void MoveTo(MouseEventArgs e,Canvas canvas,double X, double Y)
        {
            x2 += e.GetPosition(null).X - X;
            x1 += e.GetPosition(null).X - X;
            y2 += e.GetPosition(null).Y - Y;
            y1 += e.GetPosition(null).Y - Y;
            try { Show(canvas,true); }
            catch(Exception) { }
            
        }

        public void Delete(Canvas canvas)
        {
            canvas.Children.Remove(L);
        }

        private Line L = new Line();
    }
}
