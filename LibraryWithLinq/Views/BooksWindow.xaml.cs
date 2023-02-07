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


    public partial class BooksWindow : Window
    {
        MyLibraryDataClassesDataContext dtx = new MyLibraryDataClassesDataContext();
        BookDto resultTam = null;

        public BooksWindow(int TeacherId)
        {
            InitializeComponent();

            var result = from b in dtx.Books
                         join c in dtx.Categories on b.Id_Category equals c.Id
                         join a in dtx.Authors on b.Id_Author equals a.Id
                         join t in dtx.Themes on b.Id_Themes equals t.Id
                         join p in dtx.Presses on b.Id_Press equals p.Id
                         select new BookDTO { Id = b.Id, BookName = b.Name, Pages = b.Pages, YearPress = b.YearPress, AuthorFirstName = a.FirstName, AuthorLastName = a.LastName, CategotyName = c.Name, Comment = b.Comment, PressName = p.Name, Quantity = b.Quantity, ThemesName = t.Name };


            myDataGrid.ItemsSource = result;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idBook = int.Parse(id_txt.Text);

            var result = from b in dtx.Books
                         where b.Id == idBook
                         select b;

            myDataGrid.ItemsSource = result;


        }
    }

}
