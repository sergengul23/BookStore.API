using BookStore.DATA.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.BookOperations.UpdateBook
{
    public class UpdateBook
    {
        private readonly BookStoreDbContext _context;
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }

        public UpdateBook(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Book couldn't be found.");

            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.AuthorId = Model.AuthorId != default ? Model.AuthorId : book.AuthorId;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.Stock = Model.Stock != default ? Model.Stock : book.Stock;
            book.Price = Model.Price != default ? Model.Price : book.Price;

            _context.SaveChanges();
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
