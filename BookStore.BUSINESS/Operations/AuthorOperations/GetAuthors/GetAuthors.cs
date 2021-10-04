using AutoMapper;
using BookStore.CORE.Models;
using BookStore.DATA.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.AuthorOperations.GetAuthors
{
    public class GetAuthors
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthors(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authorList = _context.Authors.OrderBy(x => x.Id).Select(x => new AuthorsViewModel()
            {
                Fullname = x.Fullname,
                BirthYear = x.BirthYear,
                BookTitles = x.Books.Select(x => x.Title).ToList()
            }).ToList();

            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(authorList);

            return vm;
        }
    }

    public class AuthorsViewModel
    {
        public string Fullname { get; set; }
        public int BirthYear { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
