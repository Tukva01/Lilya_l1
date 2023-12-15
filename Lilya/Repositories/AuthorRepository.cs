using Lilya.Models;

namespace Lilya.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        void AddAuthor(Author author);
    }

    public class AuthorRepository : IAuthorRepository
    {
        private readonly MainDbContext _context;

        public AuthorRepository(MainDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }

}
