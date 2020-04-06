using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MenuAnimation
{
    /// <summary>
    /// Логика взаимодействия для Properties_Circle.xaml
    /// </summary>
    public partial class Properties_Circle : Window
    {
        private string[] A;
        private List<My_Circle> My_List_Circ;
        Canvas canvas;
        public Properties_Circle(string[] a, List<My_Circle> b, Canvas c)
        {
            InitializeComponent();
            A = a;
            My_List_Circ = b;
            canvas = c;
            X1.Text = Convert.ToString(My_List_Circ[Convert.ToInt32(A[2])].X);
            Y1.Text = Convert.ToString(My_List_Circ[Convert.ToInt32(A[2])].Y);
            Radius.Text = Convert.ToString(My_List_Circ[Convert.ToInt32(A[2])].Radius);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            My_List_Circ[Convert.ToInt32(A[2])].X = Convert.ToDouble(X1.Text);
            My_List_Circ[Convert.ToInt32(A[2])].Y = Convert.ToDouble(Y1.Text);
            My_List_Circ[Convert.ToInt32(A[2])].Radius = Convert.ToDouble(Radius.Text);
            My_List_Circ[Convert.ToInt32(A[2])].Show(canvas, false);
            My_List_Circ[Convert.ToInt32(A[2])].Show(canvas, false);
            this.Close();
        }
    }
}
