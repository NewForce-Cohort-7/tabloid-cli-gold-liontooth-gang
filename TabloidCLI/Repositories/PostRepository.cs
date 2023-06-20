using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.UserInterfaceManagers;

namespace TabloidCLI.Repositories
{
    public class PostRepository : DatabaseConnector, IRepository<Post>
    {
        public PostRepository(string connectionString) : base(connectionString) { }

        public List<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetByAuthor(int authorId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT p.id,
                                               p.Title As PostTitle,
                                               p.URL AS PostUrl,
                                               p.PublishDateTime,
                                               p.AuthorId,
                                               p.BlogId,
                                               a.FirstName,
                                               a.LastName,
                                               a.Bio,
                                               b.Title AS BlogTitle,
                                               b.URL AS BlogUrl
                                          FROM Post p 
                                               LEFT JOIN Author a on p.AuthorId = a.Id
                                               LEFT JOIN Blog b on p.BlogId = b.Id 
                                         WHERE p.AuthorId = @authorId";
                    cmd.Parameters.AddWithValue("@authorId", authorId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Post> posts = new List<Post>();
                    while (reader.Read())
                    {
                        Post post = new Post()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("PostTitle")),
                            Url = reader.GetString(reader.GetOrdinal("PostUrl")),
                            PublishDateTime = reader.GetDateTime(reader.GetOrdinal("PublishDateTime")),
                            Author = new Author()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("AuthorId")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Bio = reader.GetString(reader.GetOrdinal("Bio")),
                            },
                            //Blog = new BlogRepository()
                            //{
                            //    Id = reader.GetInt32(reader.GetOrdinal("BlogId")),
                            //    Title = reader.GetString(reader.GetOrdinal("BlogTitle")),
                            //    Url = reader.GetString(reader.GetOrdinal("BlogUrl")),
                            //}
                        };
                        posts.Add(post);
                    }

                    reader.Close();

                    return posts;
                }
            }
        }

        public void Insert(Post post)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Post (Title, Url, PublishDateTime, AuthorId, BlogId)
                                             VALUES (@title, @url, @publishDateTime, @authorId, @blogId)";
                    cmd.Parameters.AddWithValue("@title", post.Title);
                    cmd.Parameters.AddWithValue("@url", post.Url);
                    cmd.Parameters.AddWithValue("@publishDateTime", post.PublishDateTime);
                    cmd.Parameters.AddWithValue("@authorId", post.Author.Id);
                    cmd.Parameters.AddWithValue("@blogId", post.Blog.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Post post)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

// DAVID: This code was written by me when I didn't realize main menu was already done and I was building a bas
// Feel free to use any of it that you see fit
// -Tim

//namespace TabloidCLI
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {


//            IUserInterfaceManager ui = new MainMenuManager();
//            while (ui != null)
//            {
//                PrintMainMenu();
//                string selection = GetMenuSelection();

//                switch (selection)
//                {
//                    case ("List Posts"):
//                        Console.Write("Press any key to continue");
//                        Console.ReadKey();
//                        break;

//                    case ("Add Post"):
//                        Console.Write("Press any key to continue");
//                        Console.ReadKey();
//                        break;

//                    case ("Edit Post"):
//                        Console.Write("Press any key to continue");
//                        Console.ReadKey();
//                        break;

//                    case ("Remove Post"):
//                        Console.Write("Press any key to continue");
//                        Console.ReadKey();
//                        break;

//                    case ("Note Management"):
//                        Console.Write("Press any key to continue");
//                        Console.ReadKey();
//                        break;

//                    case ("Return to Main Menu"):
//                        Console.Write("Press any key to continue");
//                        Console.ReadKey();
//                        break;

//                    default:
//                        Console.WriteLine("Invalid selection. Please try again.");
//                        break;
//                }
//            }
//        }

//        static void PrintMainMenu()
//        {
//            Console.WriteLine("Main Menu:");
//            Console.WriteLine("1) My Journal Management");
//            Console.WriteLine("2) Blog Management");
//            Console.WriteLine("3) Author Management");
//            Console.WriteLine("4) Post Management");
//            Console.WriteLine("5) Tag Management");
//            Console.WriteLine("6) Search by Tag");
//            Console.WriteLine("7) Exit");
//            Console.WriteLine();
//        }

//        static string GetMenuSelection()
//        {
//            Console.Clear();

//            Console.Write("Menu Selection: ");
//            Console.WriteLine("");
//            List<string> options = new List<string>()
//            {
//                 "List Posts",
//                 "Add Post",
//                 "Edit Post",
//                 "Remove Post",
//                 "Note Management",
//                 "Return to Main Menu",
//            };

//            for (int i = 0; i < options.Count; i++)
//            {
//                Console.WriteLine($"{i + 1}. {options[i]}");
//            }

//            while (true)
//            {
//                try
//                {
//                    Console.WriteLine();
//                    Console.Write("Select an option > ");

//                    string input = Console.ReadLine();
//                    int index = int.Parse(input) - 1;
//                    return options[index];
//                }
//                catch (Exception)
//                {

//                    continue;
//                }
//            }
//        }
//    }
//}