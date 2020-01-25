using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db= new BloggingContext())
            {
                Console.WriteLine("Adding a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                Console.WriteLine("Reading");
                var blog = db.Blogs.OrderBy(a => a.BlogId).First();

                Console.WriteLine("Updating");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(new Post
                {
                    Title="Hello worlds",
                    Content="EF core practice"
                });
                db.SaveChanges();
            }
        }
    }
}
