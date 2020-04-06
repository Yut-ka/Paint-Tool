using MenuAnimation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MenuAnimado1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    

    public partial class MainWindow : Window
    {
        private static List<My_Line> My_List_Line = new List<My_Line>();
        private static List<My_Rectangle> My_List_Rect = new List<My_Rectangle>();
        private static List<My_Circle> My_List_Circ = new List<My_Circle>();
        private static List<My_Ellipse> My_List_Ell = new List<My_Ellipse>();
        private static List<My_Arrow> My_List_Arr = new List<My_Arrow>();
        private static List<My_Romb> My_List_Romb = new List<My_Romb>();
        private static List<My_Trap> My_List_Trap = new List<My_Trap>();
        private static int Count_Line = 0;
        private static int Count_Rect = 0;
        private static int Count_Circ = 0;
        private static int Count_Ell = 0;
        private static int Count_Arr = 0;
        private static int Count_Romb = 0;
        private static int Count_Trap = 0;
        My_Line[] Line_Array = new My_Line[0];
        My_Circle[] Circ_Array = new My_Circle[0];
        My_Rectangle[] Rect_Array = new My_Rectangle[0];
        My_Arrow[] Arr_Array = new My_Arrow[0];
        My_Ellipse[] Ell_Array = new My_Ellipse[0];
        My_Romb[] Romb_Array = new My_Romb[0];
        My_Trap[] Trap_Array = new My_Trap[0];
        int i_Line = 0;
        int i_Rect = 0;
        int i_Circ = 0;
        int i_Ell = 0;
        int i_Arr = 0;
        int i_Romb = 0;
        int i_Trap = 0;
        private static bool isMenuCaptured = false;
        private static double start_X;
        private static double start_Y;
        private static string Change = "Create";
        private static string Changed_figure = null;
        private object selected_obj = null;

        public MainWindow()
        {
            Loading();  // функция прокрутки ролика
            InitializeComponent();
            media.Source = new Uri(Environment.CurrentDirectory + @"\Lab4.avi");  // меди ресурс - вступительный ролик
        }

        

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            start_X = e.GetPosition(null).X;
            start_Y = e.GetPosition(null).Y;
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Change == "Move")
            {
                try
                {
                    string[] A = ComboBox.Text.Split(new char[] { '.' });
                    if (ComboBox.Text != "" && isEmpty())
                    {
                        if (A[1] == "My_Line")
                        {
                            My_List_Line[Convert.ToInt32(A[2])].MoveTo(e, canvas, start_X, start_Y);
                        }
                        if (A[1] == "My_Rectangle")
                        {
                            My_List_Rect[Convert.ToInt32(A[2])].MoveTo(e, canvas, start_X, start_Y);
                        }
                        if (A[1] == "My_Ellipse")
                        {
                            My_List_Ell[Convert.ToInt32(A[2])].MoveTo(e, canvas, start_X, start_Y);
                        }
                        if (A[1] == "My_Circle")
                        {
                            My_List_Circ[Convert.ToInt32(A[2])].MoveTo(e, canvas, start_X, start_Y);
                        }
                        if (A[1] == "My_Arrow")
                        {
                            My_List_Arr[Convert.ToInt32(A[2])].MoveTo(e, canvas, start_X, start_Y);
                        }
                        if (A[1] == "My_Romb")
                        {
                            My_List_Romb[Convert.ToInt32(A[2])].MoveTo(e, canvas, start_X, start_Y);
                        }
                        if (A[1] == "My_Trap")
                        {
                            My_List_Trap[Convert.ToInt32(A[2])].MoveTo(e, canvas, start_X, start_Y);
                        }
                    }

                    foreach (My_Line i in Line_Array)
                    {
                        i.MoveTo(e, canvas, start_X, start_Y);
                    }
                    foreach (My_Rectangle i in Rect_Array)
                    {
                        i.MoveTo(e, canvas, start_X, start_Y);
                    }
                    foreach (My_Circle i in Circ_Array)
                    {
                        i.MoveTo(e, canvas, start_X, start_Y);
                    }
                    foreach (My_Arrow i in Arr_Array)
                    {
                        i.MoveTo(e, canvas, start_X, start_Y);
                    }
                    foreach (My_Ellipse i in Ell_Array)
                    {
                        i.MoveTo(e, canvas, start_X, start_Y);
                    }
                    foreach (My_Romb i in Romb_Array)
                    {
                        i.MoveTo(e, canvas, start_X, start_Y);
                    }
                    foreach (My_Trap i in Trap_Array)
                    {
                        i.MoveTo(e, canvas, start_X, start_Y);
                    }

                }
                catch
                {
                    MessageBox.Show("Выберите элемент из ChekBox");
                }
            }
            if (Change == "Create")
            {
                if (Changed_figure == "Line")
                {
                    My_Line obj = new My_Line(e, start_X, start_Y, isMenuCaptured);
                    Add_to_ComboBox(obj, Count_Line);
                    My_List_Line.Add(obj);
                    My_List_Line[Count_Line++].Show(canvas, false);
                }
                if (Changed_figure == "Rectangle")
                {
                    My_Rectangle obj = new My_Rectangle(start_X, start_Y, e.GetPosition(null).X, e.GetPosition(null).Y, isMenuCaptured);
                    Add_to_ComboBox(obj, Count_Rect);
                    My_List_Rect.Add(obj);
                    My_List_Rect[Count_Rect++].Show(canvas, false);
                }
                if (Changed_figure == "Arrow")
                {
                    My_Arrow obj = new My_Arrow(e, start_X, start_Y, isMenuCaptured);
                    Add_to_ComboBox(obj, Count_Arr);
                    My_List_Arr.Add(obj);
                    My_List_Arr[Count_Arr++].Show(canvas, false);
                }
                if (Changed_figure == "Ellipse")
                {
                    My_Ellipse obj = new My_Ellipse(e.GetPosition(null).X, e.GetPosition(null).Y, start_X, start_Y, isMenuCaptured,canvas);
                    Add_to_ComboBox(obj, Count_Ell);
                    My_List_Ell.Add(obj);
                    My_List_Ell[Count_Ell++].Show(canvas, false);
                }
                if (Changed_figure == "Circle")
                {
                    My_Circle obj = new My_Circle(e.GetPosition(null).X, e.GetPosition(null).Y, start_X, start_Y, isMenuCaptured,canvas);
                    Add_to_ComboBox(obj, Count_Circ);
                    My_List_Circ.Add(obj);
                    My_List_Circ[Count_Circ++].Show(canvas, false);
                }
                if (Changed_figure == "Romb")
                {
                    My_Romb obj = new My_Romb(e.GetPosition(null).X, e.GetPosition(null).Y, start_X, start_Y, isMenuCaptured);
                    Add_to_ComboBox(obj, Count_Romb);
                    My_List_Romb.Add(obj);
                    My_List_Romb[Count_Romb++].Show(canvas, false);
                }
                if (Changed_figure == "Trap")
                {
                    My_Trap obj = new My_Trap(e.GetPosition(null).X, e.GetPosition(null).Y, start_X, start_Y, isMenuCaptured);
                    Add_to_ComboBox(obj, Count_Trap);
                    My_List_Trap.Add(obj);
                    My_List_Trap[Count_Trap++].Show(canvas, false);
                }

            }
            
            
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] A = ComboBox.Text.Split(new char[] { '.' });
                if (ComboBox.Text != "" && isEmpty())
                {
                    if (A[1] == "My_Line")
                    {
                        My_List_Line[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Rectangle")
                    {
                        My_List_Rect[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Ellipse")
                    {
                        My_List_Ell[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Circle")
                    {
                        My_List_Circ[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Arrow")
                    {
                        My_List_Arr[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Romb")
                    {
                        My_List_Romb[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Trap")
                    {
                        My_List_Trap[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                }
                
                Show_Click_Array();
            }
            catch
            {
                
            }

        }

        public void Show_Click_Array()
        {
            foreach(My_Line i in Line_Array)
            {
                i.Show(canvas, false);
            }
            foreach (My_Rectangle i in Rect_Array)
            {
                i.Show(canvas, false);
            }
            foreach (My_Circle i in Circ_Array)
            {
                i.Show(canvas, false);
            }
            foreach (My_Arrow i in Arr_Array)
            {
                i.Show(canvas, false);
            }
            foreach (My_Ellipse i in Ell_Array)
            {
                i.Show(canvas, false);
            }
            foreach (My_Romb i in Romb_Array)
            {
                i.Show(canvas, false);
            }
            foreach (My_Trap i in Trap_Array)
            {
                i.Show(canvas, false);
            }
        }

        private void Random_Create_Click(object sender, RoutedEventArgs e)
        {
            if (Changed_figure == "Line")
            {
                My_Line obj = new My_Line(canvas);
                Add_to_ComboBox(obj, Count_Line);
                My_List_Line.Add(obj);
                My_List_Line[Count_Line++].Show(canvas, false);
            }
            if (Changed_figure == "Rectangle")
            {
                My_Rectangle obj = new My_Rectangle(canvas);
                Add_to_ComboBox(obj, Count_Rect);
                My_List_Rect.Add(obj);
                My_List_Rect[Count_Rect++].Show(canvas, false);
            }
            if (Changed_figure == "Arrow")
            {
                My_Arrow obj = new My_Arrow(canvas);
                Add_to_ComboBox(obj, Count_Arr);
                My_List_Arr.Add(obj);
                My_List_Arr[Count_Arr++].Show(canvas, false);
            }
            if (Changed_figure == "Ellipse")
            {
                My_Ellipse obj = new My_Ellipse(canvas);
                Add_to_ComboBox(obj, Count_Ell);
                My_List_Ell.Add(obj);
                My_List_Ell[Count_Ell++].Show(canvas, false);
            }
            if (Changed_figure == "Circle")
            {
                My_Circle obj = new My_Circle(canvas);
                Add_to_ComboBox(obj, Count_Circ);
                My_List_Circ.Add(obj);
                My_List_Circ[Count_Circ++].Show(canvas, false);
            }
            if (Changed_figure == "Romb")
            {
                My_Romb obj = new My_Romb(canvas);
                Add_to_ComboBox(obj, Count_Romb);
                My_List_Romb.Add(obj);
                My_List_Romb[Count_Romb++].Show(canvas, false);
            }
            if (Changed_figure == "Trap")
            {
                My_Trap obj = new My_Trap(canvas);
                Add_to_ComboBox(obj, Count_Trap);
                My_List_Trap.Add(obj);
                My_List_Trap[Count_Trap++].Show(canvas, false);
            }
        }

        private void Random_Pair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] A = ComboBox.Text.Split(new char[] { '.' });
                if (ComboBox.Text != "" && isEmpty())
                {
                    if (A[1] == "My_Line")
                    {
                        My_List_Line[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_Line obj = new My_Line(canvas);
                        My_List_Line[Convert.ToInt32(A[2])] = obj;
                        My_List_Line[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Rectangle")
                    {
                        My_List_Rect[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_Rectangle obj = new My_Rectangle(canvas);
                        My_List_Rect[Convert.ToInt32(A[2])] = obj;
                        My_List_Rect[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Ellipse")
                    {
                        My_List_Ell[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_Ellipse obj = new My_Ellipse(canvas);
                        My_List_Ell[Convert.ToInt32(A[2])] = obj;
                        My_List_Ell[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Circle")
                    {
                        My_List_Circ[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_Circle obj = new My_Circle(canvas);
                        My_List_Circ[Convert.ToInt32(A[2])] = obj;
                        My_List_Circ[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Arrow")
                    {
                        My_List_Arr[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_Arrow obj = new My_Arrow(canvas);
                        My_List_Arr[Convert.ToInt32(A[2])] = obj;
                        My_List_Arr[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Romb")
                    {
                        My_List_Romb[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_Romb obj = new My_Romb(canvas);
                        My_List_Romb[Convert.ToInt32(A[2])] = obj;
                        My_List_Romb[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Trap")
                    {
                        My_List_Trap[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_Trap obj = new My_Trap(canvas);
                        My_List_Trap[Convert.ToInt32(A[2])] = obj;
                        My_List_Trap[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                }
                
                Random_Pair_Click_Array(A);
            }
            catch(Exception er)
            {
                
            }
        }

        private void Random_Pair_Click_Array(string[] A)
        {

            for (int i = 0; i < Line_Array.Length; i++)
            {
                
                Line_Array[i].Show(canvas, false);
                My_Line obj = new My_Line(canvas);
                My_List_Line[My_List_Line.IndexOf(Line_Array[i])] = obj;
                Line_Array[i] = obj;
                Line_Array[i].Show(canvas, false);
                
            }
            for (int i = 0; i < Rect_Array.Length; i++)
            {
                Rect_Array[i].Show(canvas, false);
                My_Rectangle obj1 = new My_Rectangle(canvas);
                My_List_Rect[My_List_Rect.IndexOf(Rect_Array[i])] = obj1;
                Rect_Array[i] = obj1;
                Rect_Array[i].Show(canvas, false);
            }
            for (int i = 0; i < Ell_Array.Length; i++)
            {
                Ell_Array[i].Show(canvas, false);
                My_Ellipse obj2 = new My_Ellipse(canvas);
                My_List_Ell[My_List_Ell.IndexOf(Ell_Array[i])] = obj2;
                Ell_Array[i] = obj2;
                Ell_Array[i].Show(canvas, false);
            }
            for (int i = 0; i < Circ_Array.Length; i++)
            {
                Circ_Array[i].Show(canvas, false);
                My_Circle obj3 = new My_Circle(canvas);
                My_List_Circ[My_List_Circ.IndexOf(Circ_Array[i])] = obj3;
                Circ_Array[i] = obj3;
                Circ_Array[i].Show(canvas, false);
            }
            for (int i = 0; i < Arr_Array.Length; i++)
            {
                Arr_Array[i].Show(canvas, false);
                My_Arrow obj4 = new My_Arrow(canvas);
                My_List_Arr[My_List_Arr.IndexOf(Arr_Array[i])] = obj4;
                Arr_Array[i] = obj4;
                Arr_Array[i].Show(canvas, false);
            }
            for (int i = 0; i < Romb_Array.Length; i++)
            {
                Romb_Array[i].Show(canvas, false);
                My_Romb obj4 = new My_Romb(canvas);
                My_List_Romb[My_List_Romb.IndexOf(Romb_Array[i])] = obj4;
                Romb_Array[i] = obj4;
                Romb_Array[i].Show(canvas, false);
            }
            for (int i = 0; i < Trap_Array.Length; i++)
            {
                Trap_Array[i].Show(canvas, false);
                My_Trap obj4 = new My_Trap(canvas);
                My_List_Trap[My_List_Trap.IndexOf(Trap_Array[i])] = obj4;
                Trap_Array[i] = obj4;
                Trap_Array[i].Show(canvas, false);
            }
        }

        private void Random_Move_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rnd = new Random();
                string[] A = ComboBox.Text.Split(new char[] { '.' });
                if (ComboBox.Text != "" && isEmpty())
                {
                    if (A[1] == "My_Line")
                    {
                        var x = rnd.Next(-50, 50);
                        var y = rnd.Next(-50, 50);
                        My_List_Line[Convert.ToInt32(A[2])].X1 += x;
                        My_List_Line[Convert.ToInt32(A[2])].Y1 += y;
                        My_List_Line[Convert.ToInt32(A[2])].X2 += x;
                        My_List_Line[Convert.ToInt32(A[2])].Y2 += y;
                        My_List_Line[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_List_Line[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Rectangle")
                    {
                        My_List_Rect[Convert.ToInt32(A[2])].X += rnd.Next(-50, 50);
                        My_List_Rect[Convert.ToInt32(A[2])].Y += rnd.Next(-50, 50);
                        My_List_Rect[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_List_Rect[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Ellipse")
                    {
                        My_List_Ell[Convert.ToInt32(A[2])].X0 += rnd.Next(-50, 50);
                        My_List_Ell[Convert.ToInt32(A[2])].Y0 += rnd.Next(-50, 50);
                        My_List_Ell[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_List_Ell[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Circle")
                    {
                        My_List_Circ[Convert.ToInt32(A[2])].X += rnd.Next(-50, 50);
                        My_List_Circ[Convert.ToInt32(A[2])].Y += rnd.Next(-50, 50);
                        My_List_Circ[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_List_Circ[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Arrow")
                    {
                        My_List_Arr[Convert.ToInt32(A[2])].X1 += rnd.Next(-50, 50);
                        My_List_Arr[Convert.ToInt32(A[2])].Y1 += rnd.Next(-50, 50);
                        My_List_Arr[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_List_Arr[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Romb")
                    {
                        My_List_Romb[Convert.ToInt32(A[2])].X += rnd.Next(-50, 50);
                        My_List_Romb[Convert.ToInt32(A[2])].Y += rnd.Next(-50, 50);
                        My_List_Romb[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_List_Romb[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                    if (A[1] == "My_Trap")
                    {
                        My_List_Trap[Convert.ToInt32(A[2])].X += rnd.Next(-50, 50);
                        My_List_Trap[Convert.ToInt32(A[2])].Y += rnd.Next(-50, 50);
                        My_List_Trap[Convert.ToInt32(A[2])].Show(canvas, false);
                        My_List_Trap[Convert.ToInt32(A[2])].Show(canvas, false);
                    }
                }
               
                Random_Move_Click_Array();

            }
            catch (Exception er)
            {

            }
        }

        private void Random_Move_Click_Array()
        {
            Random rnd = new Random();
            foreach (My_Line i in Line_Array)
            {
                var x = rnd.Next(-50, 50);
                var y = rnd.Next(-50, 50);
                i.X1 += x;
                i.Y1 += y;
                i.X2 += x;
                i.Y2 += y;
                i.Show(canvas, false);
                i.Show(canvas, false);
            }
                
            
            foreach (My_Rectangle i in Rect_Array)
                {
                    i.X += rnd.Next(-50, 50);
                    i.Y += rnd.Next(-50, 50);
                    i.Show(canvas, false);
                    i.Show(canvas, false);
                }
               
            
            foreach (My_Ellipse i in Ell_Array)
                {
                    i.X0 += rnd.Next(-50, 50);
                    i.Y0 += rnd.Next(-50, 50);
                    i.Show(canvas, false);
                    i.Show(canvas, false);
                }
                
            
            foreach (My_Circle i in Circ_Array)
                {
                    i.X += rnd.Next(-50, 50);
                    i.Y += rnd.Next(-50, 50);
                    i.Show(canvas, false);
                    i.Show(canvas, false);
                }
                
            
            foreach (My_Arrow i in Arr_Array)
                {
                    i.X1 += rnd.Next(-50, 50);
                    i.Y1 += rnd.Next(-50, 50);
                    i.Show(canvas, false);
                    i.Show(canvas, false);
                }
            foreach (My_Romb i in Romb_Array)
                {
                    i.X += rnd.Next(-50, 50);
                    i.Y += rnd.Next(-50, 50);
                    i.Show(canvas, false);
                    i.Show(canvas, false);
                }
            foreach (My_Trap i in Trap_Array)
                {
                    i.X += rnd.Next(-50, 50);
                    i.Y += rnd.Next(-50, 50);
                    i.Show(canvas, false);
                    i.Show(canvas, false);
                }


        }

        private void Change_Property_Click(object sender, RoutedEventArgs e)
        {
            string[] A = ComboBox.Text.Split(new char[] { '.' });
            if (ComboBox.Text != "")
            {
                if (A[1] == "My_Line")
                {
                    Properties_Line properties_Line = new Properties_Line(A, My_List_Line, canvas);
                    properties_Line.Show();
                }
                if (A[1] == "My_Rectangle")
                {
                    Properties_Rectangle properties_Rectangle = new Properties_Rectangle(A, My_List_Rect, canvas);
                    properties_Rectangle.Show();
                }
                if (A[1] == "My_Ellipse")
                {
                    Properties_Ellipse properties_Ellipse = new Properties_Ellipse(A, My_List_Ell, canvas);
                    properties_Ellipse.Show();
                }
                if (A[1] == "My_Circle")
                {
                    Properties_Circle properties_Circle = new Properties_Circle(A, My_List_Circ, canvas);
                    properties_Circle.Show();
                }
                if (A[1] == "My_Arrow")
                {
                    Properties_Arrow properties_Arrow = new Properties_Arrow(A, My_List_Arr, canvas);
                    properties_Arrow.Show();
                }
                if (A[1] == "My_Romb")
                {
                    Properties_Romb properties_Romb = new Properties_Romb(A, My_List_Romb, canvas);
                    properties_Romb.Show();
                }
                if (A[1] == "My_Trap")
                {
                    Properties_Trap properties_Trap = new Properties_Trap(A, My_List_Trap, canvas);
                    properties_Trap.Show();
                }
            }
            
        }
        private void Change_Radius_Click(object sender, RoutedEventArgs e)
        {
            string[] A = ComboBox.Text.Split(new char[] { '.' });
            if (ComboBox.Text != "")
            {
                if (A[1] == "My_Circle")
                {
                    Change_Radius change_Radius = new Change_Radius(A, My_List_Circ, canvas);
                    change_Radius.Show();
                }
            }
                
        }
        private void Turn_90_Click(object sender, RoutedEventArgs e)
        {
            string[] A = ComboBox.Text.Split(new char[] { '.' });
            if (ComboBox.Text != "")
            {
                if (A[1] == "My_Ellipse")
                {
                    My_List_Ell[Convert.ToInt32(A[2])].Show(canvas, false);
                    My_List_Ell[Convert.ToInt32(A[2])].turn_90();
                    My_List_Ell[Convert.ToInt32(A[2])].Show(canvas, false);
                }
            }
        }
        private void Move_Click(object sender, RoutedEventArgs e)
        {
            Change = "Move";
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            string[] A = ComboBox.Text.Split(new char[] { '.' });
            if (ComboBox.Text != "" && isEmpty())
            {
                if (A[1] == "My_Line")
                {
                    
                    My_List_Line[Convert.ToInt32(A[2])].Show(canvas, false);
                    ComboBox.Items.Remove("MenuAnimation.My_Line." + Convert.ToString(My_List_Line.IndexOf(My_List_Line[Convert.ToInt32(A[2])])));
                    
                }
                if (A[1] == "My_Rectangle")
                {
                    
                        My_List_Rect[Convert.ToInt32(A[2])].Show(canvas, false);
                        ComboBox.Items.Remove("MenuAnimation.My_Rectangle." + Convert.ToString(My_List_Rect.IndexOf(My_List_Rect[Convert.ToInt32(A[2])])));
                    
                }
                if (A[1] == "My_Ellipse")
                {
                    
                        My_List_Ell[Convert.ToInt32(A[2])].Show(canvas, false);
                        ComboBox.Items.Remove("MenuAnimation.My_Ellipse." + Convert.ToString(My_List_Ell.IndexOf(My_List_Ell[Convert.ToInt32(A[2])])));
                    
                }
                if (A[1] == "My_Circle")
                {
                    
                        My_List_Circ[Convert.ToInt32(A[2])].Show(canvas, false);
                        ComboBox.Items.Remove("MenuAnimation.My_Circle." + Convert.ToString(My_List_Circ.IndexOf(My_List_Circ[Convert.ToInt32(A[2])])));
                    
                }
                if (A[1] == "My_Arrow")
                {
                    
                        My_List_Arr[Convert.ToInt32(A[2])].Show(canvas, false);
                        ComboBox.Items.Remove("MenuAnimation.My_Arrow." + Convert.ToString(My_List_Arr.IndexOf(My_List_Arr[Convert.ToInt32(A[2])])));
                    
                }
                if (A[1] == "My_Romb")
                {

                    My_List_Romb[Convert.ToInt32(A[2])].Show(canvas, false);
                    ComboBox.Items.Remove("MenuAnimation.My_Romb." + Convert.ToString(My_List_Romb.IndexOf(My_List_Romb[Convert.ToInt32(A[2])])));

                }
                if (A[1] == "My_Trap")
                {

                    My_List_Trap[Convert.ToInt32(A[2])].Show(canvas, false);
                    ComboBox.Items.Remove("MenuAnimation.My_Trap." + Convert.ToString(My_List_Trap.IndexOf(My_List_Trap[Convert.ToInt32(A[2])])));

                }
            } 
            
            foreach (My_Line i in Line_Array)
            {
                i.Show(canvas, false);
                ComboBox.Items.Remove("MenuAnimation.My_Line." + Convert.ToString(My_List_Line.IndexOf(i)));
            }
            Array.Resize<My_Line>(ref Line_Array, 0);
            i_Line = 0;

            foreach (My_Rectangle i in Rect_Array)
            {
                i.Show(canvas, false);
                ComboBox.Items.Remove("MenuAnimation.My_Rectangle." + Convert.ToString(My_List_Rect.IndexOf(i)));
            }
            Array.Resize<My_Rectangle>(ref Rect_Array, 0);
            i_Rect = 0;
  
            foreach (My_Ellipse i in Ell_Array)
            {
                i.Show(canvas, false);
                ComboBox.Items.Remove("MenuAnimation.My_Ellipse." + Convert.ToString(My_List_Ell.IndexOf(i)));
            }
            Array.Resize<My_Ellipse>(ref Ell_Array, 0);
            i_Ell = 0;
   
            foreach (My_Circle i in Circ_Array)
            {
                i.Show(canvas, false);
                ComboBox.Items.Remove("MenuAnimation.My_Circle." + Convert.ToString(My_List_Circ.IndexOf(i)));
            }
            Array.Resize<My_Circle>(ref Circ_Array, 0);
            i_Circ = 0;

            foreach (My_Arrow i in Arr_Array)
            {
                i.Show(canvas, false);
                ComboBox.Items.Remove("MenuAnimation.My_Arrow." + Convert.ToString(My_List_Arr.IndexOf(i)));
            }
            Array.Resize<My_Arrow>(ref Arr_Array, 0);
            i_Arr = 0;

            foreach (My_Romb i in Romb_Array)
            {
                i.Show(canvas, false);
                ComboBox.Items.Remove("MenuAnimation.My_Romb." + Convert.ToString(My_List_Romb.IndexOf(i)));
            }
            Array.Resize<My_Romb>(ref Romb_Array, 0);
            i_Romb = 0;

            foreach (My_Trap i in Trap_Array)
            {
                i.Show(canvas, false);
                ComboBox.Items.Remove("MenuAnimation.My_Trap." + Convert.ToString(My_List_Trap.IndexOf(i)));
            }
            Array.Resize<My_Trap>(ref Trap_Array, 0);
            i_Trap = 0;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            ComboBox.Items.Clear();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            string[] A = ComboBox.Text.Split(new char[] { '.' });
            if (A[1] == "My_Line")
            {
                
                if(Array.IndexOf(Line_Array, My_List_Line[Convert.ToInt32(A[2])]) == -1)
                {
                    Array.Resize<My_Line>(ref Line_Array, Line_Array.Length + 1);
                    Line_Array[i_Line++] = My_List_Line[Convert.ToInt32(A[2])];
                }
                
            }
            if (A[1] == "My_Rectangle")
            {
                if (Array.IndexOf(Rect_Array, My_List_Rect[Convert.ToInt32(A[2])]) == -1)
                {
                    Array.Resize<My_Rectangle>(ref Rect_Array, Rect_Array.Length + 1);
                    Rect_Array[i_Rect++] = My_List_Rect[Convert.ToInt32(A[2])];
                }
                    
            }
            if (A[1] == "My_Ellipse")
            {
                if (Array.IndexOf(Ell_Array, My_List_Ell[Convert.ToInt32(A[2])]) == -1)
                {
                    Array.Resize<My_Ellipse>(ref Ell_Array, Ell_Array.Length + 1);
                    Ell_Array[i_Ell++] = My_List_Ell[Convert.ToInt32(A[2])];
                }
                    
            }
            if (A[1] == "My_Circle")
            {
                if (Array.IndexOf(Circ_Array, My_List_Circ[Convert.ToInt32(A[2])]) == -1)
                {
                    Array.Resize<My_Circle>(ref Circ_Array, Circ_Array.Length + 1);
                    Circ_Array[i_Circ++] = My_List_Circ[Convert.ToInt32(A[2])];
                }
                    
            }
            if (A[1] == "My_Arrow")
            {
                if (Array.IndexOf(Arr_Array, My_List_Arr[Convert.ToInt32(A[2])]) == -1)
                {
                    Array.Resize<My_Arrow>(ref Arr_Array, Arr_Array.Length + 1);
                    Arr_Array[i_Arr++] = My_List_Arr[Convert.ToInt32(A[2])];
                }     
            }
            if (A[1] == "My_Romb")
            {
                if (Array.IndexOf(Romb_Array, My_List_Romb[Convert.ToInt32(A[2])]) == -1)
                {
                    Array.Resize<My_Romb>(ref Romb_Array, Romb_Array.Length + 1);
                    Romb_Array[i_Romb++] = My_List_Romb[Convert.ToInt32(A[2])];
                }
            }
            if (A[1] == "My_Trap")
            {
                if (Array.IndexOf(Trap_Array, My_List_Trap[Convert.ToInt32(A[2])]) == -1)
                {
                    Array.Resize<My_Trap>(ref Trap_Array, Trap_Array.Length + 1);
                    Trap_Array[i_Trap++] = My_List_Trap[Convert.ToInt32(A[2])];
                }
            }
        }

        private bool isEmpty()
        {
            if (Line_Array.Length == 0 && Rect_Array.Length == 0 && Arr_Array.Length == 0 && Circ_Array.Length == 0 && Ell_Array.Length == 0 && Romb_Array.Length == 0 && Trap_Array.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Clear_Array_Click(object sender, RoutedEventArgs e)
        {
            Array.Resize(ref Line_Array, 0);
            Array.Resize(ref Circ_Array, 0);
            Array.Resize(ref Rect_Array, 0);
            Array.Resize(ref Ell_Array, 0);
            Array.Resize(ref Arr_Array, 0);
            Array.Resize(ref Romb_Array, 0);
            Array.Resize(ref Trap_Array, 0);
            i_Line = 0;
            i_Circ = 0;
            i_Rect = 0;
            i_Arr = 0;
            i_Ell = 0;
            i_Romb = 0;
            i_Trap = 0;
        }

        

        private void Add_to_ComboBox(object obj,int count)
        {
            ComboBox.Items.Add(Convert.ToString(obj) + "." + Convert.ToString(count++));
        }

        /// <summary>
        /// Логика взаимодействия для визуального функционала
        /// </summary>



        private void ButtonMAX_Click(object sender, RoutedEventArgs e)      // Полноэкранный режим программы
        {
            WindowState = WindowState.Maximized;
            ButtonMAX.Visibility = Visibility.Collapsed;
            ButtonMIN.Visibility = Visibility.Visible;
        }

        private void ButtonMIN_Click(object sender, RoutedEventArgs e)      // Оконный режим программы
        {
            WindowState = WindowState.Normal;
            ButtonMAX.Visibility = Visibility.Visible;
            ButtonMIN.Visibility = Visibility.Collapsed;
        }

        private void ButtonDefault_Click(object sender, RoutedEventArgs e)  // Сворачивание программы
        {
            WindowState = WindowState.Minimized;
        }
        DispatcherTimer timer = new DispatcherTimer();                      // объект для времени

        private void ButtonClose_Click(object sender, RoutedEventArgs e)   //  Закрытие программы
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e) // Открытие меню
        {
            isMenuCaptured = true;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e) // Сворачивание меню
        {
            isMenuCaptured = false;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }


        private void timer_tick(object sender, EventArgs e)  // функция Задержки времени для ролика
        {
            timer.Stop();
            media.Visibility = Visibility.Collapsed;
            workplace.Visibility = Visibility.Visible;
        }

        void Loading()                                      // Проигрывание ролика
        {
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            Changed_figure = "Line";
            Change = "Create";
        }

        private void ListViewItem1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Changed_figure = "Rectangle";
            Change = "Create";
        }

        private void ListViewItem2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Changed_figure = "Arrow";
            Change = "Create";
        }

        private void ListViewItem3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Changed_figure = "Ellipse";
            Change = "Create";
        }

        private void ListViewItem4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Changed_figure = "Circle";
            Change = "Create";
        }

        private void ListViewItem5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Changed_figure = "Romb";
            Change = "Create";
        }

        private void ListViewItem6_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Changed_figure = "Trap";
            Change = "Create";
        }
    } 
}
