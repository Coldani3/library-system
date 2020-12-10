using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace library_system
{
    public abstract class LibraryItem : IUserInterfaceElement
    {
        [XmlIgnore]
        protected List<string> categories = new List<string>();
        
        public string Category { get; set; }
        public string Title { get; set; }
        //Assuming it's fine if an Author is saved as empty for Magazines
        //Also adding multiple authors option
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string DateOfPublication { get; set; }
        public string ID { get; set; }

        //Not sure why you'd want to call this but it's there in Book and Magazine so there's got to be a reason
        public LibraryItem()
        {

        }

        public LibraryItem(string title, string author, string publisher, string dateOfPublication, string category)
        {
            Title = title;
            Author = author;            
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
            Category = category;
            categories.Add(category); //Add to categories list so we can easily count how many we have
            int count = CategoriesCount(); //Using LINQ Count the number of existing books of this category
            //Magazine and others can redefine ID in their constructor so this shouldn't cause any problems
            ID = category.Substring(0, 4) + count.ToString("00");
        }

        public int CategoriesCount()
        {
            return categories.Where(x => x.Equals(Category)).Count();
        }

        public abstract void Display();
    }
}