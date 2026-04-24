using cs_mvc_sprint.Model.Repositories;
using cs_mvc_sprint.Models;

namespace cs_mvc_sprint.Model.Services
{
    public interface IAuthorsService
    {
        public List<Author> GetAllAuthors();
        public Author GetAuthorById(int id);
        public bool AddAuthor(Author author);
    }
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorRepository;

        public AuthorsService(IAuthorsRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.FetchAllAuthors() ?? new List<Author>();
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.FetchAuthorById(id);
        }

        public bool AddAuthor(Author author)
        {
            _authorRepository.PostAuthor(author);
            return true;
        }
    }
}
