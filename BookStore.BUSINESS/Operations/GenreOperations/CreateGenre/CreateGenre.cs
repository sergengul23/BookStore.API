using BookStore.CORE.Models;
using BookStore.DATA.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.GenreOperations.CreateGenre
{
    public class CreateGenre
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _context;

        public CreateGenre(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);

            if (genre != null)
                throw new InvalidOperationException("The genre already exists.");

            genre = new Genre();
            genre.Name = Model.Name;

            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
