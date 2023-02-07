using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithLinq.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string CategotyName { get; set; }
        public string PressName { get; set; }
        public string ThemesName { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int Pages { get; set; }
        public int YearPress { get; set; }
        public string Comment { get; set; }
        public int Quantity { get; set; }

    }

}
