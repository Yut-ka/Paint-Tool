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
    /// Логика взаимодействия для Properties_Ellipse.xaml
    /// </summary>
    public partial class Properties_Ellipse : Window
    {
        private string[] A;
        private List<My_Ellipse> My_List_Ell;
        Canvas canvas;
        public Properties_Ellipse(string[] a, List<My_Ellipse> b, Canvas c)
        {
            InitializeComponent();
            A = a;
            My_List_Ell = b;
            canvas = c;
            X1.Text = Convert.ToString(My_List_Ell[Convert.ToInt32(A[2])].X0);
            Y1.Text = Convert.ToString(My_List_Ell[Convert.ToInt32(A[2])].Y0);
            Radius1.Text = Convert.ToString(My_List_Ell[Convert.ToInt32(A[2])].Radius);
            Radius2.Text = Convert.ToString(My_List_Ell[Convert.ToInt32(A[2])].Radius2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            My_List_Ell[Convert.ToInt32(A[2])].X0 = Convert.ToDouble(X1.Text);
            My_List_Ell[Convert.ToInt32(A[2])].Y0 = Convert.ToDouble(Y1.Text);
            My_List_Ell[Convert.ToInt32(A[2])].Radius = Convert.ToDouble(Radius1.Text);
            My_List_Ell[Convert.ToInt32(A[2])].Radius2 = Convert.ToDouble(Radius2.Text);
            My_List_Ell[Convert.ToInt32(A[2])].Show(canvas, false);
            My_List_Ell[Convert.ToInt32(A[2])].Show(canvas, false);
            this.Close();
        }
    }
}
