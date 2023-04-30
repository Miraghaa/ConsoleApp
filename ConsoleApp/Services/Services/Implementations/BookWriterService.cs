

using ConsoleApp.Core.Models;
using ConsoleApp.Data.Repositories.BookWriters;
using ConsoleApp.Services.Services.Interfaces;
using System.Text.RegularExpressions;

namespace ConsoleApp.Services.Services.Implementations
{
    public class BookWriterService : IBookWriterService
    {
        private readonly  BookWriterRepository _repository = new BookWriterRepository();
        public async Task<string> CreateAsync(string name, string surname, string birthdate, string phonenumber, string adress, int books)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(name))
                return "There is no such Name";

            if (string.IsNullOrWhiteSpace(surname))
                return "There is no such Surname";


            Regex regex1 = new Regex(@"^(\+994)?(994)?(51|55|77|70|60|90|99|050|051|055|077|070|060|090|099)\d{7}$");
            bool result1 = regex1.IsMatch(phonenumber);
            if (!result1)
                return "The phone number is not correct";
            Regex regex = new Regex(@"^([012]\d|30|31).(0\d|10|11|12).\d{4}$");
            bool result = regex.IsMatch(birthdate);
            if (!result)
                return "Date of birth is incorrect";

            if (string.IsNullOrWhiteSpace(adress))
                return "the address is not correct";
            if (books < 0)
                return "there is no book";

            Console.ForegroundColor = ConsoleColor.Green;
            BookWriter bookWriter = new BookWriter(name, surname, birthdate, phonenumber, adress, books);
            await _repository.AddAsync(bookWriter);
            return "Successfully craeted";
        }
        public async Task<string> DeleteAsync(int id)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            BookWriter bookWriter = await _repository.GetAsync(book => book.Id == id);
            if (bookWriter == null)
                return "There is no such book writer";

            await _repository.RemoveAsync(bookWriter);

            Console.ForegroundColor = ConsoleColor.Green;

            return "Deleted";
        }
        public async Task<string> UpdateAsync(int id, string name, string surname, string adress, int books,string phonenumber)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(name))
                return "There is no such Name";

            if (string.IsNullOrWhiteSpace(surname))
                return "There is no such Surname";

            if (string.IsNullOrWhiteSpace(adress))
                return "the address is not correct";


            Regex regex1 = new Regex(@"^(\+994)?(994)?(51|55|77|70|60|90|99|050|051|055|077|070|060|090|099)\d{7}$");
            bool result1 = regex1.IsMatch(phonenumber);
            if (!result1)
                return "The phone number is not correct";

            BookWriter bookwriter = await _repository.GetAsync(s => s.Id == id);
            if (bookwriter == null)
                return "there is no book";

            bookwriter.Name = name;
            bookwriter.Surname = surname;
            bookwriter.Adress = adress;
            bookwriter.Books = books;
            bookwriter.Phonenumber = phonenumber;

            Console.ForegroundColor = ConsoleColor.Green;
            return "Updated";
        }
        public async Task GetAllAsync()
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in await _repository.GetAllAsync())
            {
                Console.WriteLine(item);
            }
        }
        public async Task<BookWriter> GetAsync(int id)
        {
            BookWriter bookWriter = await _repository.GetAsync(book => book.Id == id);

            if (bookWriter == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such book writer was found");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return bookWriter;
        }
        public async Task<List<Book>> GetAllBooksAsync(int id)
        {
            BookWriter bookWriter = await _repository.GetAsync(book => book.Id == id);
            if (bookWriter == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" No such book writer was found");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return bookWriter.Bookss;

        }

       
    }
}

