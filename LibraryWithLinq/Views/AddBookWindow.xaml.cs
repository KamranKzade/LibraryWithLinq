using LibraryWithLinq.DataAccess.SqlServer;
using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace LibraryWithLinq.Views
{
    public partial class AddBookWindow : Window
    {
        MyLibraryDataClassesDataContext dtx = new MyLibraryDataClassesDataContext();

        public AddBookWindow()
        {
            InitializeComponent();

            var result = from b in dtx.Books
                         select b;

            int Id_Press_Max = result.Max(b => b.Id_Press);
            int Id_Press_Min = result.Min(b => b.Id_Press);

            int Id_Category_Max = result.Max(b => b.Id_Category);
            int Id_Category_Min = result.Min(b => b.Id_Category);

            int Id_Themes_Max = result.Max(b => b.Id_Themes);
            int Id_Themes_Min = result.Min(b => b.Id_Themes);

            int Id_Author_Max = result.Max(b => b.Id_Author);
            int Id_Author_Min = result.Min(b => b.Id_Author);

            int Quantity_Max = result.Max(b => b.Quantity);
            int Quantity_Min = result.Min(b => b.Quantity);

            for (int i = Id_Press_Min; i <= Id_Press_Max; i++)
                idPress_txt.Items.Add(i.ToString());

            for (int i = Id_Author_Min; i <= Id_Author_Max; i++)
                idAuthor_txt.Items.Add(i.ToString());

            for (int i = Id_Themes_Min; i <= Id_Themes_Max; i++)
                idThemes_txt.Items.Add(i.ToString());

            for (int i = Id_Category_Min; i <= Id_Category_Max; i++)
                idCategory_txt.Items.Add(i.ToString());
            for (int i = Quantity_Min; i <= Quantity_Max; i++)
                quantity_txt.Items.Add(i.ToString());


            idAuthor_txt.SelectedIndex = 0;
            idCategory_txt.SelectedIndex = 0;
            idPress_txt.SelectedIndex = 0;
            idThemes_txt.SelectedIndex = 0;
            quantity_txt.SelectedIndex = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;


            if (string.IsNullOrWhiteSpace(id_txt.Text))
            {
                sb.Append("Id ni Daxil edin, zehmet olmasa\n");
                count++;
            }
            if (string.IsNullOrWhiteSpace(name_txt.Text))
            {
                sb.Append("Name Daxil edin, zehmet olmasa\n");
                count++;
            }
            if (string.IsNullOrWhiteSpace(pages_txt.Text))
            {
                sb.Append("Pages Daxil edin, zehmet olmasa\n");
                count++;
            }
            if (string.IsNullOrWhiteSpace(yearpress_txt.Text))
            {
                sb.Append("YearPress Daxil edin, zehmet olmasa\n");
                count++;
            }
            if (count > 0)
                MessageBox.Show(sb.ToString(), "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            else
            {
                if (id_txt.Text != null)
                {
                    var book = dtx.Books.FirstOrDefault(b => b.Id == int.Parse(id_txt.Text));
                    if (book != null)
                        MessageBox.Show("Bu Idli Kitab var, yeniden basqa Id daxil edin", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            try
            {
                dtx.Books.InsertOnSubmit(new Book
                {
                    Id = int.Parse(id_txt.Text),
                    Name = name_txt.Text,
                    Pages = int.Parse(pages_txt.Text),
                    YearPress = int.Parse(yearpress_txt.Text),
                    Comment = comment_txt.Text,
                    Quantity = int.Parse(quantity_txt.Text),
                    Id_Author = int.Parse(idAuthor_txt.SelectedItem.ToString()),
                    Id_Category = int.Parse(idCategory_txt.SelectedItem.ToString()),
                    Id_Press = int.Parse(idPress_txt.SelectedItem?.ToString()),
                    Id_Themes = int.Parse(idThemes_txt.SelectedItem.ToString())
                });
                MessageBox.Show("Successfully, Added Book", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            try
            {
                dtx.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
