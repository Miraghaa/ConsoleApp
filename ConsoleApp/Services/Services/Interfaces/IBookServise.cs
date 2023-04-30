﻿

using ConsoleApp.Core.Enums;
using ConsoleApp.Core.Models;

namespace ConsoleApp.Services.Services.Interfaces
{
    public interface IBookServise
    {
        public Task<string> CreateAsync(int id, string name,  int numberofthebook, string information, double price, double discountprice, BookLanguage language, BookCategory category);
        public Task<string> DeleteAsync(int bookwriterId,int bookId);
        public Task<string> UpdateAsync(int bookwriterId, int bookId, string name, int numberofthebook, double price, double discountprice,string information);
        public Task<Book> GetAsync(int bookwriterId,int bookId);
        public Task GetAll();

        public Task<string> BuyBook(int bookwriterId, int bookId);
    }   
}
