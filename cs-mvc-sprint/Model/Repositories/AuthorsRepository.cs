using System.Text.Json;
using cs_mvc_sprint.Models;
using cs_mvc_sprint.Utils;

namespace cs_mvc_sprint.Model.Repositories
{
    public interface IAuthorsRepository
    {
        public List<Author> FetchAllAuthors();
        public Author FetchAuthorById(int id);
        public bool PostAuthor(Author author);
    }
    public class AuthorsRepository : IAuthorsRepository
    {
        public List<Author> FetchAllAuthors()
        {
            var path = Environment.GetEnvironmentVariable("MYPATH");
            Console.WriteLine(path);
            var authors = JsonSerializer.Deserialize<List<Author>>(
                JsonReader.ReadFile(
                    path + "authors"
                    )
                ) ?? new List<Author>();
            return authors;
        }
        public Author FetchAuthorById(int id)
        {
            var path = Environment.GetEnvironmentVariable("MYPATH");
            Console.WriteLine(path);
            var author = JsonSerializer.Deserialize<List<Author>>(
                JsonReader.ReadFile(
                    path + "authors"
                    )
                );
            return author[id - 1];
        }

        public bool PostAuthor(Author author)
        {
            var path = Environment.GetEnvironmentVariable("MYPATH");
            Console.WriteLine(path);
            var authorList = JsonSerializer.Deserialize<List<Author>>(
                JsonReader.ReadFile(
                    path + "authors"
                    )
                );
            author.Id = authorList.Count+1;
            authorList.Add(author);
            JsonReader.WriteFile(path + "authors", authorList);
            return true;

        }
    }
}
