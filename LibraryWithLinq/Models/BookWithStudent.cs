using System;

namespace LibraryWithLinq.Models
{
    public class BookWithStudent
    {
        public int Id { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string BookName { get; set; }
        public int Pages { get; set; }
        public int YearPress { get; set; }
        public string CategoryName { get; set; }
        public string ThemesName { get; set; }
        public string AutohorFirstName { get; set; }
        public string AutohorLastName { get; set; }
        public string PressName { get; set; }
        public string Comment { get; set; }
        public int Quantity { get; set; }
    }
}
