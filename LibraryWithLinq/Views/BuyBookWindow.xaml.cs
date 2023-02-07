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


    public partial class BuyBookWindow : Window
    {

        MyLibraryDataClassesDataContext dtx = new MyLibraryDataClassesDataContext();
        int TeacherId, bookId;

        public BuyBookWindow(int teacherId, int BookId)
        {
            InitializeComponent();


            var result = from b in dtx.Books
                         join c in dtx.Categories on b.Id_Category equals c.Id
                         join a in dtx.Authors on b.Id_Author equals a.Id
                         join t in dtx.Themes on b.Id_Themes equals t.Id
                         join p in dtx.Presses on b.Id_Press equals p.Id
                         where b.Id == BookId
                         select new BookDTO { Id = b.Id, BookName = b.Name, Pages = b.Pages, YearPress = b.YearPress, AuthorFirstName = a.FirstName, AuthorLastName = a.LastName, CategotyName = c.Name, Comment = b.Comment, PressName = p.Name, Quantity = b.Quantity, ThemesName = t.Name };

            dataGrid.ItemsSource = result;

            DateIn.Text = DateTime.Now.AddDays(4).ToString();
            pay_txt.Text = $"{(new Random().Next(0, 100) * 4)} Azn";

            TeacherId = teacherId;
            bookId = BookId;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dtx.T_Cards.InsertOnSubmit(new T_Card
            {
                Id = new Random().Next(9, 100),
                Id_Teacher = TeacherId,
                Id_Book = bookId,
                DateOut = DateTime.Now,
                DateIn = DateTime.Now.AddDays(4),
                Id_Lib = 1
            });

            dtx.SubmitChanges();
            MessageBox.Show("Successfully ");

            DialogResult = true;
        }
    }
}
