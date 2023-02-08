using System;
using System.Linq;
using System.Windows;
using LibraryWithLinq.Models;
using LibraryWithLinq.DataAccess.SqlServer;

namespace LibraryWithLinq.Views
{

    public partial class BuyBookWindow : Window
    {
        bool HasTeacher;
        int TeacherId, bookId;

        MyLibraryDataClassesDataContext dtx = new MyLibraryDataClassesDataContext();

        public BuyBookWindow(int teacherId, int BookId, bool hasTeacher)
        {
            InitializeComponent();

            TeacherId = teacherId;
            bookId = BookId;
            HasTeacher = hasTeacher;

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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (HasTeacher)
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
                MessageBox.Show("Successfully Add T_Card", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (HasTeacher is false)
            {
                dtx.S_Cards.InsertOnSubmit(new S_Card
                {
                    Id = new Random().Next(9, 100),
                    Id_Student = TeacherId,
                    Id_Book = bookId,
                    DateOut = DateTime.Now,
                    DateIn = DateTime.Now.AddDays(4),
                    Id_Lib = 1
                });

                MessageBox.Show("Successfully Add S_Card", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DialogResult = true;
            dtx.SubmitChanges();
        }
    }
}
