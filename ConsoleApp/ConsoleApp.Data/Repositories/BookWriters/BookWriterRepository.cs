

using ConsoleApp.Core.Models;
using ConsoleApp.Core.Repositories.BookWriters;

namespace ConsoleApp.Data.Repositories.BookWriters
{
    public class BookWriterRepository:Repository<BookWriter>,IBookWriterRepository
    {
    }
}
