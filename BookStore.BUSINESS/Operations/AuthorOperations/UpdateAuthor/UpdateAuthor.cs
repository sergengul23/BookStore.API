using BookStore.CORE.Models;
using BookStore.DATA.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthor
    {
        private readonly BookStoreDbContext _context;

        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }

        public UpdateAuthor(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Author couldn't be found.");

            author.Fullname = Model.Fullname != default ? Model.Fullname : author.Fullname;
            author.BirthYear = Model.BirthYear != default ? Model.BirthYear : author.BirthYear;

            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Fullname { get; set; }
        public int BirthYear { get; set; }
    }
}
