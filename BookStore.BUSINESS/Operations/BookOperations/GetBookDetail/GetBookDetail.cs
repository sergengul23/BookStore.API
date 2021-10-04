using AutoMapper;
using BookStore.DATA.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.BookOperations.GetBookDetail
{
    public class GetBookDetail
    {
        public int BookId { get; set; }

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetail(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Include(x => x.Author).Include(x => x.Genre).Where
                (book => book.Id == BookId).SingleOrDefault();

            if (book is null)
                throw new InvalidOperationException("Book couldn't be found.");

            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);

            return vm;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
