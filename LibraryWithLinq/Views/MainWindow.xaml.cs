using System.Windows;
using System.Windows.Input;
using LibraryWithLinq.Views;
using LibraryWithLinq.DataAccess.SqlServer;


namespace LibraryWithLinq
{
    public partial class MainWindow : Window
    {
        MyLibraryDataClassesDataContext ldc = new MyLibraryDataClassesDataContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Btn(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void Minimize_Btn(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            int myId = int.Parse(id.Text);
            int? result = null;

            // Teacher giris
            if (teacher_radio.IsChecked == true)
            {
                ldc.CheckTeacher(myId, firstname.Text, lastname.Text, ref result);

                if (result is 1)
                {
                    BooksWindow window = new BooksWindow(myId, true);
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"{firstname.Text} {lastname.Text} istifadeci movcud deyil");
                }

            }

            // Student Giris
            else if (student_radio.IsChecked == true)
            {
                ldc.CheckStudent(myId, firstname.Text, lastname.Text, ref result);

                if (result is 1)
                {
                    BooksWindow window = new BooksWindow(myId, false);
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"{firstname.Text} {lastname.Text} istifadeci movcud deyil");
                }
            }

            // Libs Giris
            else if (libs_radio.IsChecked == true)
            {
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
    }
}
