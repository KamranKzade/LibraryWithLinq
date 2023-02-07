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

    public partial class BooksWindowForStudent : Window
    {
        MyLibraryDataClassesDataContext dtx = new MyLibraryDataClassesDataContext();
        int studentId;

        public BooksWindowForStudent(int StudentId)
        {
            InitializeComponent();

            var result = from b in dtx.Books
                         join c in dtx.Categories on b.Id_Category equals c.Id
                         join a in dtx.Authors on b.Id_Author equals a.Id
                         join t in dtx.Themes on b.Id_Themes equals t.Id
                         join p in dtx.Presses on b.Id_Press equals p.Id
                         select new BookDTO { Id = b.Id, BookName = b.Name, Pages = b.Pages, YearPress = b.YearPress, AuthorFirstName = a.FirstName, AuthorLastName = a.LastName, CategotyName = c.Name, Comment = b.Comment, PressName = p.Name, Quantity = b.Quantity, ThemesName = t.Name };


            myDataGrid.ItemsSource = result;
            studentId = StudentId;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idBook = int.Parse(id_txt.Text);

            int? result = null;
            dtx.CheckBookQuantity(idBook, ref result);

            if (result != 0)
            {
               BuyBookWindowForStudent window = new BuyBookWindowForStudent(studentId, idBook);
               window.ShowDialog();

                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Bu Kitabdan hal hazirda stokda yoxdur!!!", "Information", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

    }
}
