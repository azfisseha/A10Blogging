using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10BLogging.Services
{
    public interface IBlogDBHandler
    {
        void AddBlog();
        void DisplayBlogs();
        void DisplayPosts();
        void CreatePost();

    }
}
