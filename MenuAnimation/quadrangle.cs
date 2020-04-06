using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MenuAnimation
{
    public abstract class quadrangle:TFigure
    {
        private double width;
        private double height;
        
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }

        public quadrangle(double x, double y, double x2, double y2) : base(x, y)
        {
            this.width = x2 - x;
            this.height = y2 - y;
        }

        public quadrangle(Canvas canvas) : base(canvas)
        {
            Random rnd = new Random();
            width = rnd.Next(50, 350);
            height = rnd.Next(50, 350);
        }

    }
}
