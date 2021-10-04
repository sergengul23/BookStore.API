using BookStore.DATA.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.BookOperations.DeleteBook
{
    public class DeleteBook
    {
        private readonly BookStoreDbContext _context;

        public int BookId { get; set; }

        public DeleteBook(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);

            if (book == null)
                throw new InvalidOperationException("Book couldn't be found.");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
