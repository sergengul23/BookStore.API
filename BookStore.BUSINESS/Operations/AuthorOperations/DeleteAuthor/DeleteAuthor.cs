using BookStore.DATA.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthor
    {
        private readonly BookStoreDbContext _context;
        public int AuthorId { get; set; }

        public DeleteAuthor(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("The author couldn't be found.");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
