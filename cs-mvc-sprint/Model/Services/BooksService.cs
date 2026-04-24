using cs_mvc_sprint.Model.Repositories;
using cs_mvc_sprint.Models;

namespace cs_mvc_sprint.Model.Services
{
    public interface IBooksService
    {
        public List<Book> GetAllBooks();
        public Book GetBookById(int id);
        public void AddBook(Book book);
        public bool DeleteBook(int id);
    }
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public List<Book> GetAllBooks()
        {
            return _booksRepository.FetchAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _booksRepository.FetchBookById(id);
        }
        public void AddBook(Book book)
        {
            _booksRepository.PostBook(book);
        }

        public bool DeleteBook(int id)
        {
            return _booksRepository.RemoveBook(id);
        }
    }
}
