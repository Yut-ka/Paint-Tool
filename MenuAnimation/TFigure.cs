using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MenuAnimation
{
    public abstract class TFigure
    {
        private double x;
        private double y;
        
       

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        

        protected TFigure(double x1, double y1)
        {
            x = x1;
            y = y1;
            MessageBox.Show("Координаты заданы");
        }
        protected TFigure(Canvas canvas)
        {
            Random rnd = new Random();
            x = rnd.Next(0, Convert.ToInt32(canvas.ActualWidth));
            y = rnd.Next(90, Convert.ToInt32(canvas.ActualHeight));
            MessageBox.Show("Координаты заданы");
        }
        abstract public void Show(Canvas canvas, bool from_MOVE);
        abstract public void MoveTo(MouseEventArgs e, Canvas canvas, double X, double Y);
    }
}
