using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

//COMMENT ALL CHANGES TO REACH MEETING OF SOLID PRINCIPLES
namespace library_system
{
    class App
    {
        private string filetype = "JSON";
        private LibraryHelper libraryHelper = new LibraryHelper();
        private List<Book> books;
        private Dictionary<string, IFileType> fileManagers = new Dictionary<string, IFileType>() {
            {"JSON", new JSONBookFormat()},
            {"XML", new XMLBookFormat()}
        };

        public App()
        {

        }

        public void Run()
        {
            CurrentTime time = new CurrentTime();
            while (true)
            {
                Console.Clear();
                time.Update();
                time.Display();
                //Single Responsibility Principle - Instead of doing all the reading in the same file, we relegate it to IFileTypes
                books = fileManagers[filetype].Read("library." + filetype.ToLower());
                
                bool done = false;

                string another = Input("Add a book y/n");
                if (another == "n")
                {
                    done = true;
                }

                while (!done)
                {
                    Console.Clear();
                    Console.WriteLine("Select a category:");
                    for (int i = 0; i < libraryHelper.Categories.Count; i++)
                    {
                        Console.WriteLine(i + ": " + libraryHelper.Categories[i]);
                    }

                    int selectedCategoryID = 0;
                    bool validID = false;
                    do
                    {
                        try
                        {
                            selectedCategoryID = Convert.ToInt32(Console.ReadLine());
                            if (selectedCategoryID >= 0 && selectedCategoryID < libraryHelper.Categories.Count)
                            {
                                validID = true;
                            }
                            else
                            {
                                Console.WriteLine("Option not available. Please try again");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("Please try again");
                        }
                    } while (!validID);

                    string selectedCategory = libraryHelper.Categories[selectedCategoryID];
                    Console.WriteLine("You have selected {0}", selectedCategory);

                    string title = Input("Title");
                    string author = Input("Author");
                    string publisher = Input("Publisher");
                    string dateOfPublication = Input("Date of publication");

                    books.Add(new Book(title, author, publisher, dateOfPublication, selectedCategory));

                    another = Input("Add another? y/n");
                    if (another == "n")
                    {
                        done = true;
                    }

                };

                Console.Clear();
                Console.WriteLine("All books in library\n");
                foreach (var book in books)
                {
                    book.Display();
                }

                //ADDITIONAL FUNCTIONALITY: Choosing file format
                Console.WriteLine("Which format do you wish to save in?");
                List<string> formats = new List<string>();

                foreach (string format in fileManagers.Keys)
                {
                    formats.Add(format);
                    Console.WriteLine(format);
                }

                string userInput = Console.ReadLine().ToUpper();
                
                if (formats.Contains(userInput))
                {
                    filetype = userInput;
                }
                else
                {
                    filetype = "JSON";
                }

                //Single Responsibility - Insted of writing to file in the App, we relegate it to IFileTypes
                fileManagers[filetype].Write("library." + filetype.ToLower(), books);

                //Console.WriteLine(itemsSerialized);
                Console.ReadKey(true);
            }
        }
        public static string Input(string prompt)
        {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }
    }
}

