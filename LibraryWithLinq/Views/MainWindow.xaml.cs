using LibraryWithLinq.DataAccess.SqlServer;
using LibraryWithLinq.Views;
using System.Windows;
using System.Windows.Input;

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
                    BooksWindow window = new BooksWindow(myId);
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"{firstname.Text} {lastname.Text} istifadeci movcud deyil");
                }

            }

            else if (student_radio.IsChecked == true)
            {
                int? result = null;
                ldc.CheckStudent(myId, firstname.Text, lastname.Text, ref result);

                if (result is 1)
                {
                    BooksWindowForStudent window = new BooksWindowForStudent(myId);
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"{firstname.Text} {lastname.Text} istifadeci movcud deyil");
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
                    MessageBox.Show($"{firstname.Text} {lastname.Text} istifadeci movcud deyil");
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
