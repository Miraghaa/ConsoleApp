

using ConsoleApp.Core.Enums;
using ConsoleApp.Core.Models;
using ConsoleApp.Core.Models.Base;
using ConsoleApp.Services.Services.Interfaces;
using System.Reflection.Metadata;

namespace ConsoleApp.Services.Services.Implementations
{
    public class ConsoleAppService
    {
        public bool IsAdmin = false;

        private User[] Users = { new User { UserName = "Miri", Password = "Miriss" } };

        private  BookWriterService _bookWriterService = new BookWriterService();
        private  BookService _bookService = new BookService();
        
        public async Task <bool> Login()
        {
            Console.WriteLine("Add username");
            string username = Console.ReadLine();
            Console.WriteLine("Add password");
            string password = Console.ReadLine();

            if (Users.Any(x => x.UserName == username && x.Password == password))
            {
                IsAdmin = true;
            }
            else
            {
                Console.WriteLine("Username or password in correct");
                IsAdmin = false;
            }
            return IsAdmin;

           
        }

             public async Task ShowAdmin()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string sentence = "Welcome to my first mini project";

            foreach (var item in sentence)
            {
                Thread.Sleep(100);
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine("0. Close app");
            Console.WriteLine("1. Create book writer");
            Console.WriteLine("2. Show book writer");
            Console.WriteLine("3. Show book writer by Id");
            Console.WriteLine("4. Show book writer books");
            Console.WriteLine("5. Update book writer ");
            Console.WriteLine("6. Remove book writer");
            Console.WriteLine("7. Create book");
            Console.WriteLine("8. Update book");
            Console.WriteLine("9.  Remove book");
            Console.WriteLine("10. GetBook by book writer");
            Console.WriteLine("11. Buy book");


            string Requeest = Console.ReadLine();

            while (Requeest != "0")
            {
                switch (Requeest)
                {

                    case "1":
                        Console.Clear();
                        await CreateBookWriter();
                        break;
                    case "2":
                        Console.Clear();
                        await ShowBookWriter();
                        break;
                    case "3":
                        Console.Clear();
                        await ShowBookWriterById();
                        break;
                    case "4":
                        Console.Clear();
                        await ShowBookWriterBooks();
                        break;
                    case "5":
                        Console.Clear();
                        await UpdateBookWriter();
                        break;
                    case "6":
                        Console.Clear();
                        await RemoveBookWriter();
                        break;

                    case "7":
                        Console.Clear();
                        await CreateBook();
                        break;
                    case "8":
                        Console.Clear();
                        await UpdateBook();
                        break;
                    case "9":
                        Console.Clear();
                        await RemoveBook();
                        break;
                    case "10":
                        Console.Clear();
                        await GetBookByBookWriter();
                        break;
                    case "11":
                        Console.Clear();
                        await BuyBook();
                        break;
                        default: Console.WriteLine("csd");
                        break;


                }

                Console.WriteLine();
                Console.WriteLine("0. Close app");
                Console.WriteLine("1. Create book writer");
                Console.WriteLine("2. Show book writer");
                Console.WriteLine("3. Show book writer by Id");
                Console.WriteLine("4. Show book writers books");
                Console.WriteLine("5. Update book writer ");
                Console.WriteLine("6. Remove book writer");
                Console.WriteLine("7. Create book");
                Console.WriteLine("8. Update book");
                Console.WriteLine("9.  Remove book");
                Console.WriteLine("10. GetBook by book writer");
                Console.WriteLine("11. Buy book");


                Requeest = Console.ReadLine();
            }

        }
             public async Task ShowUser()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string sentence = "Welcome to my first mini project";

            foreach (var item in sentence)
            {
                Thread.Sleep(200);
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine("0. Close app");
            Console.WriteLine("1. Show book writer");
            Console.WriteLine("2. Show book writer by Id");
            Console.WriteLine("3. Show book writers books");
            Console.WriteLine("4. GetBook by book writer");
            Console.WriteLine("5. Buy book");


            string Requeest = Console.ReadLine();

            while (Requeest != "0")
            {
                switch (Requeest)
                {  
                    case "1":
                        Console.Clear();
                        await ShowBookWriter();
                        break;
                    case "2":
                        Console.Clear();
                        await ShowBookWriterById();
                        break;
                    case "3":
                        Console.Clear();
                        await ShowBookWriterBooks();
                        break;
                    case "4":
                        Console.Clear();
                        await GetBookByBookWriter();
                        break;
                    case "5":
                        Console.Clear();
                        await BuyBook();
                        break;
                    default:
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("There is no such book and writer");
                        break;


                }

                Console.WriteLine();
                Console.WriteLine("0. Close app");
                Console.WriteLine("1. Show book writer");
                Console.WriteLine("2. Show book writer by Id");
                Console.WriteLine("3. Show book writers books");
                Console.WriteLine("4. GetBook by book writer");
                Console.WriteLine("5. Buy book");


                Requeest = Console.ReadLine();
            }
        }
            private async Task CreateBookWriter()
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Add name");
                string name = Console.ReadLine();
                Console.WriteLine("Add surname");
                string surname = Console.ReadLine();
                Console.WriteLine("Add adress");
                string adress = Console.ReadLine();
                Console.WriteLine("Add phone");
                string phonenumber = Console.ReadLine();
                Console.WriteLine("Add birthdate");
                string birthdate = Console.ReadLine();
                Console.WriteLine("Add books");
                int.TryParse(Console.ReadLine(), out int books);


                string message = await _bookWriterService.CreateAsync(name, surname, birthdate, phonenumber, adress, books);
                Console.WriteLine(message);
            }

            private async Task ShowBookWriter()
            {
                await _bookWriterService.GetAllAsync();
            }

            private async Task ShowBookWriterById()
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Add BookWriter id");
                int.TryParse(Console.ReadLine(), out int id);

                BookWriter bookWriter = await _bookWriterService.GetAsync(id);
                if (bookWriter != null)
                {
                    Console.WriteLine(bookWriter);
                }
            }

            private async Task ShowBookWriterBooks()
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Add BookWriter id");
                int.TryParse(Console.ReadLine(), out int id);

                List<Book> books = await _bookWriterService.GetAllBooksAsync(id);
                if (books != null)
                {
                    foreach (Book book in books)
                    {
                        Console.WriteLine(book);
                        Console.WriteLine("---------");
                    }
                }
            }
            private async Task UpdateBookWriter()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Add BookWriter id");
                int.TryParse(Console.ReadLine(), out int Id);
                Console.WriteLine("Add name");
                string name = Console.ReadLine();
                Console.WriteLine("Add surname");
                string surname = Console.ReadLine();
                Console.WriteLine("Add adress");
                string adress = Console.ReadLine();
                Console.WriteLine("Add phone");
                string phonenumber = Console.ReadLine();
                Console.WriteLine("Add birthdate");
                string birthdate = Console.ReadLine();
                Console.WriteLine("Add books");
                int.TryParse(Console.ReadLine(), out int books);


                string message = await _bookWriterService.CreateAsync(name, surname, birthdate, phonenumber, adress, books);
                Console.WriteLine(message);
            }

            private async Task RemoveBookWriter()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Add Book writer id");
                int.TryParse(Console.ReadLine(), out int Id);

                string message = await _bookWriterService.DeleteAsync(Id);
                Console.WriteLine(message);
            }

            private async Task CreateBook()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Add Book Writer id");
                int.TryParse(Console.ReadLine(), out int id);
                Console.WriteLine("Book name");
                string name = Console.ReadLine();
                Console.WriteLine("Note the number of the book");
                int.TryParse(Console.ReadLine(), out int numberofthebook);
                Console.WriteLine("Record information about the book");
                string information = Console.ReadLine();
                Console.WriteLine("Book price");
                int.TryParse(Console.ReadLine(), out int price);
                Console.WriteLine("Book discount price");
                int.TryParse(Console.ReadLine(), out int discountprice);
                BookLanguage language;
                Console.WriteLine("Choose book language");
                foreach (var item in Enum.GetValues(typeof(BookLanguage)))
                {
                    Console.WriteLine((int)item + " " + item);
                }
                int.TryParse(Console.ReadLine(), out int languageindex);
                var result = Enum.GetName(typeof(BookLanguage), languageindex);

                while (result == null)
                {
                    Console.WriteLine("Select the language of the book");
                    int.TryParse(Console.ReadLine(), out languageindex);
                    result = Enum.GetName(typeof(BookLanguage), languageindex);
                }
                language = (BookLanguage)languageindex;

                BookCategory category;
                Console.WriteLine("Choose category");
                foreach (var item in Enum.GetValues(typeof(BookCategory)))
                {
                    Console.WriteLine((int)item + " " + item);
                }
                int.TryParse(Console.ReadLine(), out int categoryindex);
                result = Enum.GetName(typeof(BookCategory), categoryindex);

                while (result == null)
                {
                    Console.WriteLine("Select the category of the book");
                    int.TryParse(Console.ReadLine(), out categoryindex);
                    result = Enum.GetName(typeof(BookCategory), categoryindex);
                }
                category = (BookCategory)categoryindex;

                string message = await _bookService.CreateAsync(id, name, numberofthebook, information, price, discountprice, language, category);
                Console.WriteLine(message);
            }

            private async Task UpdateBook()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Add Book Writer id");
                int.TryParse(Console.ReadLine(), out int bookwriterId);
                Console.WriteLine("Add book id");
                int.TryParse(Console.ReadLine(), out int bookId);
                Console.WriteLine("Add name");
                string name = Console.ReadLine();
                Console.WriteLine("Note the number of the book");
                int.TryParse(Console.ReadLine(), out int numberofthebook);
                Console.WriteLine("Record information about the book");
                string information = Console.ReadLine();
                Console.WriteLine("Add price");
                int.TryParse(Console.ReadLine(), out int price);
                Console.WriteLine("Add discount price");
                int.TryParse(Console.ReadLine(), out int discountprice);


                string message2 = await _bookService.UpdateAsync(bookwriterId, bookId, name, numberofthebook, price, discountprice, information);
                Console.WriteLine(message2);
            }
            private async Task GetBookByBookWriter()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Add book writer id");
                int.TryParse(Console.ReadLine(), out int bookwriterId);
                Console.WriteLine("Add book  id");
                int.TryParse(Console.ReadLine(), out int bookId);

                Book book = await _bookService.GetAsync(bookwriterId, bookId);

                if (book != null)
                {
                    Console.WriteLine(book);
                }

            }
            private async Task RemoveBook()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Add book writer id");
                int.TryParse(Console.ReadLine(), out int bookwriterId);
                Console.WriteLine("Add book  id");
                int.TryParse(Console.ReadLine(), out int bookId);

                string message = await _bookService.DeleteAsync(bookwriterId, bookId);
                Console.WriteLine(message);
            }
            private async Task BuyBook()
            {
            
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Add book writer id");
                int.TryParse(Console.ReadLine(), out int bookwriterId);
                Console.WriteLine("Add book  id");
                int.TryParse(Console.ReadLine(), out int bookId);

                string message = await _bookService.BuyBook(bookwriterId, bookId);
                Console.WriteLine(message);
            }


        

    }
}



