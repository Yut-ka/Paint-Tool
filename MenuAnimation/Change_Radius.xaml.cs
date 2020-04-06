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
    /// Логика взаимодействия для Change_Radius.xaml
    /// </summary>
    public partial class Change_Radius : Window
    {
        private string[] A;
        private List<My_Circle> My_List_Circ;
        Canvas canvas;
        public Change_Radius(string[] a, List<My_Circle> b, Canvas c)
        {
            InitializeComponent();
            A = a;
            My_List_Circ = b;
            canvas = c;
            Radius.Text = Convert.ToString(My_List_Circ[Convert.ToInt32(A[2])].Radius);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            My_List_Circ[Convert.ToInt32(A[2])].Change_Radius(Convert.ToDouble(Radius.Text));
            My_List_Circ[Convert.ToInt32(A[2])].Show(canvas, false);
            My_List_Circ[Convert.ToInt32(A[2])].Show(canvas, false);
            this.Close();
        }

    }
}
