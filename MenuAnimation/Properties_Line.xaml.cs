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
    /// Логика взаимодействия для Properties_Line.xaml
    /// </summary>
    public partial class Properties_Line : Window
    {
        private string[] A;
        private List<My_Line> My_List_Line;
        Canvas canvas;
        public Properties_Line(string[] a, List<My_Line> b,Canvas c)
        {
            InitializeComponent();
            A = a;
            My_List_Line = b;
            canvas = c;
            X1.Text = Convert.ToString(My_List_Line[Convert.ToInt32(A[2])].X1);
            Y1.Text = Convert.ToString(My_List_Line[Convert.ToInt32(A[2])].Y1);
            X2.Text = Convert.ToString(My_List_Line[Convert.ToInt32(A[2])].X2);
            Y2.Text = Convert.ToString(My_List_Line[Convert.ToInt32(A[2])].Y2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            My_List_Line[Convert.ToInt32(A[2])].X1 = Convert.ToDouble(X1.Text);
            My_List_Line[Convert.ToInt32(A[2])].Y1 = Convert.ToDouble(Y1.Text);
            My_List_Line[Convert.ToInt32(A[2])].X2 = Convert.ToDouble(X2.Text);
            My_List_Line[Convert.ToInt32(A[2])].Y2 = Convert.ToDouble(Y2.Text);
            My_List_Line[Convert.ToInt32(A[2])].Show(canvas, false);
            My_List_Line[Convert.ToInt32(A[2])].Show(canvas, false);
            this.Close();
        }
       

        
    }
}
