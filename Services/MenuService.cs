using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10BLogging.Services
{
    public class MenuService : IMenuService
    {
        /// <summary>
        /// Prompts the user with the menu options for the program.
        /// </summary>
        /// <returns>The <see cref="MenuOptions"/> choice selected by the user.</returns>
        public MenuOptions runMenu()
        {
            string input;
            printMenu();
            input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "1": return MenuOptions.DisplayBlogs;
                case "2": return MenuOptions.AddBlog;
                case "3": return MenuOptions.AddPost;
                case "4": return MenuOptions.DisplayPosts;
                case "q": return MenuOptions.Exit;
                default: return MenuOptions.Invalid;
            }
        }

        private void printMenu()
        {
            Console.WriteLine("1) Display All Blogs");
            Console.WriteLine("2) Add Blog");
            Console.WriteLine("3) Create Post");
            Console.WriteLine("4) Display Posts");
            Console.WriteLine("Enter q to quit");
        }
    }
}
