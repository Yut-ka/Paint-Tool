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
    /// Логика взаимодействия для Properties_Trap.xaml
    /// </summary>
    public partial class Properties_Trap : Window
    {
        private string[] A;
        private List<My_Trap> My_List_Trap;
        Canvas canvas;
        public Properties_Trap(string[] a, List<My_Trap> b, Canvas c)
        {
            InitializeComponent();
            A = a;
            My_List_Trap = b;
            canvas = c;
            X1.Text = Convert.ToString(My_List_Trap[Convert.ToInt32(A[2])].X);
            Y1.Text = Convert.ToString(My_List_Trap[Convert.ToInt32(A[2])].Y);
            Width.Text = Convert.ToString(My_List_Trap[Convert.ToInt32(A[2])].Width);
            Height.Text = Convert.ToString(My_List_Trap[Convert.ToInt32(A[2])].Height);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            My_List_Trap[Convert.ToInt32(A[2])].X = Convert.ToDouble(X1.Text);
            My_List_Trap[Convert.ToInt32(A[2])].Y = Convert.ToDouble(Y1.Text);
            My_List_Trap[Convert.ToInt32(A[2])].Width = Convert.ToDouble(Width.Text);
            My_List_Trap[Convert.ToInt32(A[2])].Height = Convert.ToDouble(Height.Text);
            My_List_Trap[Convert.ToInt32(A[2])].Show(canvas, false);
            My_List_Trap[Convert.ToInt32(A[2])].Show(canvas, false);
            this.Close();
        }
    }
}
