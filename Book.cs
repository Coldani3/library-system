using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system
{
    public class Book : LibraryItem
    {
        public Book()
        {

        }

        public Book(string title, string author, string publisher, string dateOfPublication, string category) : base(title, author, publisher, dateOfPublication, category)
        {

        }

        public override void Display()
        {
            Console.WriteLine(ID + ", " + Author + ", " + Title + ", " + Publisher + ", " + DateOfPublication);
        }

        //Removal of Update fixes the Liskov Substitution Principle violation, as Book can now be treated the exact same as any other
        //IUserInterfaceElement without crashing
    }
}
