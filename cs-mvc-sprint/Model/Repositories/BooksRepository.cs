using System.Text.Json;
using cs_mvc_sprint.Models;
using cs_mvc_sprint.Utils;

namespace cs_mvc_sprint.Model.Repositories
{
    public interface IBooksRepository
    {
        public List<Book> FetchAllBooks();
        public Book FetchBookById(int id);
        public void PostBook(Book book);
        public bool RemoveBook(int id);
    }

    public class BooksRepository : IBooksRepository
    {
        public List<Book> FetchAllBooks()
        {
            var path = Environment.GetEnvironmentVariable("MYPATH");
            Console.WriteLine(path);
            var books = JsonSerializer.Deserialize<List<Book>>(
                JsonReader.ReadFile(path + "books")
                ) ?? new List<Book>();
            return books;
        }

        public Book FetchBookById(int id)
        {
            var path = Environment.GetEnvironmentVariable("MYPATH");
            Console.WriteLine(path);
            var books = JsonSerializer.Deserialize<List<Book>>(
                JsonReader.ReadFile(path + "books")
                );
            return books[id - 1];
        }

        public void PostBook(Book book) 
        {
            var path = Environment.GetEnvironmentVariable("MYPATH");
            Console.WriteLine(path);
            var booksList = JsonSerializer.Deserialize<List<Book>>(
                JsonReader.ReadFile(
                    path + "books"
                    )
                );
            book.Id = booksList.Count;
            booksList.Add(book);
            JsonReader.WriteFile(path + "books", booksList);
        }

        public bool RemoveBook(int id)
        {
            var path = Environment.GetEnvironmentVariable("MYPATH");
            Console.WriteLine(path);
            var booksList = JsonSerializer.Deserialize<List<Book>>(
                JsonReader.ReadFile(
                    path + "books"
                    )
                );
            Book? bookRemoval = booksList.Find(b => b.Id == id);
            if(bookRemoval != null)
            {
                booksList.Remove(bookRemoval);
                JsonReader.WriteFile(path + "books", booksList);
                return true;
            }
            return false;
        }
    }
}
