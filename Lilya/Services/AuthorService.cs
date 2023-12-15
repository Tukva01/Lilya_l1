using Lilya.Models;
using Lilya.Repositories;

namespace Lilya.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        void AddAuthor(Author author);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        public void AddAuthor(Author author)
        {
            _authorRepository.AddAuthor(author);
        }
    }

}
