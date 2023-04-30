
using ConsoleApp.Core.Models.Base;

namespace ConsoleApp.Core.Models
{
    public class BookWriter:Basemodel
    {
        private static int _id;
        public string Surname { get; set; }
        public string  Birthdate {get; set;}
        public string Phonenumber { get; set;}
        public string Adress { get; set; }
        public int Books { get; set; }

        public List<Book> Bookss;


        public BookWriter(string name,string surname,string birthdate,string phonenumber,string adress,int books)
        {
            _id++;
            Id = _id;
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Phonenumber = phonenumber;
            Adress = adress;
            Books = books ;
            Bookss = new List<Book>();
            CreatedDate = DateTime.UtcNow.AddHours(4);
            UpdatedDate = DateTime.UtcNow.AddHours(4);
            
        }
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname} , Birthdate: {Birthdate}, Phone: {Phonenumber}, Adress: {Adress}, Books:{Books} , CreateDate: {CreatedDate}, UpdateDate: {UpdatedDate}";

        }
    }
}
