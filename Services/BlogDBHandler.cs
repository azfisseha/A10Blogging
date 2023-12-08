using A10BLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10BLogging.Services
{
    public class BlogDBHandler : IBlogDBHandler
    {
        public void DisplayBlogs()
        {

            using (var db = new BlogContext())
            {
                foreach (var b in db.Blogs)
                {
                    Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
                }
            }
        }

        public void AddBlog()
        {

            Console.Write("Enter a name for a new Blog: ");
            var blogName = Console.ReadLine();

            if (blogName == null || blogName == "")
            {
                Console.WriteLine("Blog name cannot be null");
                return;
            }

            var blog = new Blog();
            blog.Name = blogName;

            using (var db = new BlogContext())
            {
                db.Add(blog);
                db.SaveChanges();
                Console.WriteLine($"Blog \"{blog.Name}\" added");
            }

        }

        public void DisplayPosts()
        {
            Console.WriteLine("Select the Blog whose posts you want to view:");

            using (var db = new BlogContext())
            {
                var blog = SelectBlogByID(db);
                if (blog != null)
                {
                    Console.WriteLine($"{blog.Posts.Count} Posts found under Blog {blog.Name}");

                    foreach (var post in blog.Posts)
                    {
                        Console.WriteLine($"\tBlog {blog.Name}: Post {post.Title} - {post.Content}");
                    }
                }
            }
        }

        public void CreatePost()
        {
            Console.WriteLine("Select the Blog to post to:");

            using (var db = new BlogContext())
            {
                var blog = SelectBlogByID(db);
                if (blog != null)
                {
                    Console.Write("Enter your Post title:  ");
                    var postTitle = Console.ReadLine();
                    if (postTitle == null || postTitle == "")
                    {
                        Console.WriteLine("Post Title cannot be null");
                        return;
                    }

                    Console.Write("Enter your Post content:  ");
                    var postContent = Console.ReadLine();

                    var post = new Post();
                    post.Title = postTitle;
                    post.Content = postContent;
                    post.BlogId = blog.BlogId;

                    db.Posts.Add(post);
                    db.SaveChanges();
                }
            }
        }

        //in-elegant solution, didn't want to copy this code but didn't find a way to reuse this logic without
        //referencing Blog and BlogContext concretely.
        private Blog SelectBlogByID(BlogContext db)
        {
            DisplayBlogs();
            Console.Write("Blog ID: ");
            string input;
            int id = -1;
            do
            {
                input = Console.ReadLine();
                try
                {
                    id = Int32.Parse(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Blog ID");
                }
            } while (id < 0);

            var blog = db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
            if (blog == null)
            {
                Console.WriteLine($"There are no blogs found with that ID {id}");
            }
            return blog;
        }
    }
}
