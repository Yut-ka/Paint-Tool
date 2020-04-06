using System;

namespace MenuAnimado1
{
    public class Line
    {
        public Line1(object sender, MouseEventArgs e)
        {
            position.Content = "X=" + e.GetPosition(null).X + " Y=" + e.GetPosition(null).Y;
        }
    }
}

