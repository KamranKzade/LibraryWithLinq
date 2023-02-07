using LibraryWithLinq.DataAccess.SqlServer;
using LibraryWithLinq.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryWithLinq
{
    public partial class MainWindow : Window
    {
        MyLibraryDataClassesDataContext ldc = new MyLibraryDataClassesDataContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Minimize_Btn(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Close_Btn(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            int myId = int.Parse(id.Text);

            if (teacher_radio.IsChecked == true)
            {
                int? result = null;
                ldc.CheckTeacher(myId, firstname.Text, lastname.Text, ref result);

                if (result is 1)
                {
                    MessageBox.Show("Welcome");
                }
                else
                {
                    MessageBox.Show("Giris olmadi");
                }

            }

            else if (student_radio.IsChecked == true)
            {
                int? result = null;
                ldc.CheckStudent(myId, firstname.Text, lastname.Text, ref result);

                if (result is 1)
                {
                    MessageBox.Show("Welcome");
                }
                else
                {
                    MessageBox.Show("Giris olmadi");
                }
            }

            else if (libs_radio.IsChecked == true)
            {
                int? result = null;
                ldc.CheckLibs(myId, firstname.Text, lastname.Text, ref result);

                if (result is 1)
                {
                    MessageBox.Show("Welcome");
                }
                else
                {
                    MessageBox.Show("Giris olmadi");
                }
            }
            else
            {
                MessageBox.Show("Secimlerden Birini edin-> RadioButtonlardan");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
