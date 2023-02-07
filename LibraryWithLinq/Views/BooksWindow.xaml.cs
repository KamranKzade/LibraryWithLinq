using System.Linq;
using System.Windows;
using LibraryWithLinq.Models;
using LibraryWithLinq.DataAccess.SqlServer;

namespace LibraryWithLinq.Views
{

    public partial class BooksWindow : Window
    {
        int teacherId;
        bool hasTeacher;

        MyLibraryDataClassesDataContext dtx = new MyLibraryDataClassesDataContext();


        public BooksWindow(int TeacherId, bool HasTeacher)
        {
            InitializeComponent();

            teacherId = TeacherId;
            hasTeacher = HasTeacher;

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

            int? result = null;
            dtx.CheckBookQuantity(idBook, ref result);


            if (result != 0 && hasTeacher == true)
            {
                BuyBookWindow window = new BuyBookWindow(teacherId, idBook, true);
                window.ShowDialog();

                DialogResult = true;
            }
            else if (result != 0 && hasTeacher == false)
            {
                BuyBookWindow window = new BuyBookWindow(teacherId, idBook, false);
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
