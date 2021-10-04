using AutoMapper;
using BookStore.CORE.Models;
using BookStore.DATA.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetail
    {
        public int AuthorId { get; set; }

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetail(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Where(x => x.Id == AuthorId).Select(x => new AuthorDetailViewModel()
            {
                Fullname = x.Fullname,
                BirthYear = x.BirthYear,
                BookTitles = x.Books.Select(x => x.Title).ToList()
            }).FirstOrDefault();

            if (author is null)
                throw new InvalidOperationException("Author couldn't be found.");

            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);

            return vm;
        }
    }

    public class AuthorDetailViewModel
    {
        public string Fullname { get; set; }
        public int BirthYear { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
