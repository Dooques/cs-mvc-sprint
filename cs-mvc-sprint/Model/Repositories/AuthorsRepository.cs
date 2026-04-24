using System.Text.Json;
using cs_mvc_sprint.Models;
using cs_mvc_sprint.Utils;

namespace cs_mvc_sprint.Model.Repositories
{
    public interface IAuthorsRepository
    {
        public List<Author> FetchAllAuthors();
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
    }
}
