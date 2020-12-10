using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system
{
    public class Magazine : LibraryItem
    {
        public Magazine()
        {

        }

        public Magazine(string title, string publisher, string dateOfPublication, string category) : base(title, "", publisher, dateOfPublication, category)
        {
            //Add to categories list so we can easily count how many we have
            int count = CategoriesCount(); //Using LINQ Count the number of existing books of this category
            ID = "M-" + category.Substring(0, 4) + count.ToString("00");
        }

        public override void Display()
        {
            Console.WriteLine(ID + ", " + Title + ", " + Publisher + ", " + DateOfPublication);
        }

        //Removal of Update fixes the Liskov Substitution Principle violation, as Book can now be treated the exact same as any other
        //IUserInterfaceElement without crashing
    }
}
