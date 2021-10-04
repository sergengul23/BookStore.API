using AutoMapper;
using BookStore.CORE.Models;
using BookStore.DATA.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.BookOperations.CreateBook
{
    public class CreateBook
    {
        public CreateBookModel Model { get; set; }

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBook(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book != null)
                throw new InvalidOperationException("The book already exists.");

            book = _mapper.Map<Book>(Model);

            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }

    public class CreateBookModel
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
