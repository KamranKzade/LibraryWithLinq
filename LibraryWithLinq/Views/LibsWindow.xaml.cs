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
using System.Windows.Shapes;

namespace LibraryWithLinq.Views
{

    public partial class LibsWindow : Window
    {
        MyLibraryDataClassesDataContext dtx = new MyLibraryDataClassesDataContext();


        public LibsWindow()
        {
            InitializeComponent();

        }

        private void Add_Book_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add");
        }

        private void Delete_Book_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete");

        }

        private void Show_Book_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.ItemsSource != null)
            {
                myDataGrid.ItemsSource = null;
            }

            if (all_radio.IsChecked == true)
            {
                var result = from b in dtx.Books
                             join c in dtx.Categories on b.Id_Category equals c.Id
                             join a in dtx.Authors on b.Id_Author equals a.Id
                             join t in dtx.Themes on b.Id_Themes equals t.Id
                             join p in dtx.Presses on b.Id_Press equals p.Id
                             select new BookDTO { Id = b.Id, BookName = b.Name, Pages = b.Pages, YearPress = b.YearPress, AuthorFirstName = a.FirstName, AuthorLastName = a.LastName, CategotyName = c.Name, Comment = b.Comment, PressName = p.Name, Quantity = b.Quantity, ThemesName = t.Name };

                myDataGrid.ItemsSource = result;
            }
            else if (teacher_radio.IsChecked == true)
            {
                var result = from b in dtx.Books
                             join c in dtx.Categories on b.Id_Category equals c.Id
                             join a in dtx.Authors on b.Id_Author equals a.Id
                             join t in dtx.Themes on b.Id_Themes equals t.Id
                             join p in dtx.Presses on b.Id_Press equals p.Id
                             join tc in dtx.T_Cards on b.Id equals tc.Id_Book
                             join teac in dtx.Teachers on tc.Id_Teacher equals teac.Id
                             select new BookWithTeachers
                             {
                                 Id = teac.Id,
                                 AutohorFirstName = a.FirstName,
                                 AutohorLastName = a.LastName,
                                 BookName = b.Name,
                                 CategoryName = c.Name,
                                 Comment = b.Comment,
                                 PressName = p.Name,
                                 Quantity = b.Quantity,
                                 Pages = b.Pages,
                                 ThemesName = t.Name,
                                 TeacherLastName = teac.LastName,
                                 TeacherName = teac.FirstName,
                                 YearPress = b.YearPress,
                             };

                myDataGrid.ItemsSource = result;
            }
            else if (student_radio.IsChecked == true)
            {
                var result = from b in dtx.Books
                             join c in dtx.Categories on b.Id_Category equals c.Id
                             join a in dtx.Authors on b.Id_Author equals a.Id
                             join t in dtx.Themes on b.Id_Themes equals t.Id
                             join p in dtx.Presses on b.Id_Press equals p.Id
                             join sc in dtx.S_Cards on b.Id equals sc.Id_Book
                             join st in dtx.Students on sc.Id_Student equals st.Id
                             select new BookWithStudent
                             {
                                 Id = st.Id,
                                 AutohorFirstName = a.FirstName,
                                 AutohorLastName = a.LastName,
                                 BookName = b.Name,
                                 CategoryName = c.Name,
                                 Comment = b.Comment,
                                 PressName = p.Name,
                                 Quantity = b.Quantity,
                                 Pages = b.Pages,
                                 ThemesName = t.Name,
                                 StudentFirstName = st.FirstName,
                                 StudentLastName = st.LastName,
                                 YearPress = b.YearPress,
                             };
                myDataGrid.ItemsSource = result;
            }
            else
                MessageBox.Show("Zehmet olmasa secimlerden birini edin", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
