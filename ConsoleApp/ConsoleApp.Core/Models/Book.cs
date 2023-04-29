

using ConsoleApp.Core.Enums;
using ConsoleApp.Core.Models.Base;
using Microsoft.VisualBasic;

namespace ConsoleApp.Core.Models
{
    public class Book:Basemodel
    {
        private static int _id;
        public string BookWriter { get; set; }
        public string BookLanguage { get; set; }
        public int NumberOfTheBook { get; set; }
        public string BookInformation { get; set; }
        public double Price { get; set; }
        public double DisountPrice { get; set; }

        public bool InStock;
        public BookCategory Category { get; set; }
        public BookWriter bookWriter { get; set; }
        


        public Book(string name,string bookwriter,string language,int numberofthebook,string information, double price, double discountprice, BookCategory category, BookWriter bookWriter  )
        {
            _id++;
            Id = _id;
            Name = name;
            BookWriter = bookwriter;
            BookLanguage = language;
            NumberOfTheBook = numberofthebook;
            BookInformation=information;
            Price = price;
            DisountPrice = discountprice;
            Category = category;
            BookWriter =bookwriter;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

    }
}
