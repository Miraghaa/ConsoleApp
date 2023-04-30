

using ConsoleApp.Core.Models;

namespace ConsoleApp.Services.Services.Interfaces
{
    public interface IBookWriterService
    {
        public Task<string> CreateAsync(string name,string surname, string birthdate,string phonenumber,string adress,int books);
        public Task<string> DeleteAsync(int id);
        public Task<string> UpdateAsync(int id, string name, string surname, string adress, int books, string phonenumber);
        public Task<BookWriter> GetAsync(int id);
        public Task GetAllAsync();
        public Task<List<Book>> GetAllBooksAsync(int id);
    }
}
