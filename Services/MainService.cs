using Castle.Core.Internal;
using A10BLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10BLogging.Services
{
    public class MainService : IMainService
    {
        private readonly IMenuService _menuService;
        private readonly IBlogDBHandler _blogDBHandler;

        public MainService(IMenuService menuService, IBlogDBHandler blogDBHandler)
        {
            _menuService = menuService;
            _blogDBHandler = blogDBHandler;
        }

        public void Invoke()
        {
            MenuOptions selection;
            do
            {
                selection = _menuService.runMenu();
                {
                    switch (selection)
                    {
                        case MenuOptions.DisplayBlogs:
                            _blogDBHandler.DisplayBlogs();
                            break;
                        case MenuOptions.AddBlog:
                            _blogDBHandler.AddBlog();
                            break;
                        case MenuOptions.AddPost:
                            _blogDBHandler.CreatePost();
                            break;
                        case MenuOptions.DisplayPosts:
                            _blogDBHandler.DisplayPosts();
                            break;
                    }
                }
            } while (selection != MenuOptions.Exit);
        }
    }
}
