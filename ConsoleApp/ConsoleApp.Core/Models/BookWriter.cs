
using ConsoleApp.Core.Models.Base;

namespace ConsoleApp.Core.Models
{
    public class BookWriter:Basemodel
    {
        private static int _id;
        public string Surname { get; set; }
        public int Birthdate {get; set;}
        public string Phonenumber { get; set;}
        public string Adress { get; set; }
        public int Books { get; set; }

        public List<Book> Bookss;


        public BookWriter(string name,string surname,int birthdate,string phonenumber,string adress,int books)
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
    }
}
