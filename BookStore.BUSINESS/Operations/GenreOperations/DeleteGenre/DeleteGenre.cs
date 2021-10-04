using BookStore.DATA.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.GenreOperations.DeleteGenre
{
    public class DeleteGenre
    {
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteGenre(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
                throw new InvalidOperationException("Genre couldn't be found.");

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
