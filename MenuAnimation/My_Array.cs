using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAnimation
{
    class My_Array
    {
        private My_Line[] my_Lines;
        private My_Ellipse[] my_Ellipses;
        private My_Circle[] my_Circles;
        private My_Arrow[] my_Arrows;
        private My_Rectangle[] my_Rectangles;

        public My_Line[] My_Lines { get => my_Lines; set => my_Lines = value; }
        public My_Ellipse[] My_Ellipses { get => my_Ellipses; set => my_Ellipses = value; }
        public My_Circle[] My_Circles { get => my_Circles; set => my_Circles = value; }
        public My_Arrow[] My_Arrows { get => my_Arrows; set => my_Arrows = value; }
        public My_Rectangle[] My_Rectangles { get => my_Rectangles; set => my_Rectangles = value; }
        public My_Array()
        {
            My_Lines = new My_Line[0];
            my_Ellipses = new My_Ellipse[0];
            my_Circles = new My_Circle[0];
            my_Arrows = new My_Arrow[0];
            my_Rectangles = new My_Rectangle[0];
        }
        public bool isEmpty()
        {
            if (my_Lines == null && my_Rectangles == null && my_Arrows == null && my_Circles == null && my_Ellipses == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
