

using ConsoleApp.Core.Enums;
using ConsoleApp.Core.Models.Base;
using Microsoft.VisualBasic;

namespace ConsoleApp.Core.Models
{
    public class Book:Basemodel
    {
        private static int _id;
        public int NumberOfTheBook { get; set; }
        public string BookInformation { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }

        public bool BookInStock { get; set; }
        public BookLanguage Language { get; set; }
        public BookCategory Category { get; set; }
        public BookWriter bookWriter { get; set; }
        


        public Book(string name, int numberofthebook, string information, double price, double discountprice, bool bookInStock, BookCategory category, BookLanguage language, BookWriter bookWriter  )
        {
            _id++;
            Id = _id;
            Name = name;
            NumberOfTheBook = numberofthebook;
            BookInformation=information;
            Price = price;
            DiscountPrice = discountprice;
            BookInStock = bookInStock;
            Language = language;
            Category = category;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }


        public override string ToString()
        {

            if (DiscountPrice < Price)
            {
                return $"There is  {Price - DiscountPrice} DiscountPrice   Name: {Name}, NumberOfTheBook: {NumberOfTheBook}, BookInformation: {BookInformation}, Price: {DiscountPrice}, BookInStock:{BookInStock}, Language: {Language}, Category: {Category}, BookWriter: {bookWriter} ";
            }


            return $"Name: {Name}, NumberOfTheBook: {NumberOfTheBook}, BookInformation: {BookInformation}, ,Price: {Price}, BookInStock{BookInStock}, Language: {Language}, Category: {Category}, BookWriter: {bookWriter} ";
        }
    }

}

