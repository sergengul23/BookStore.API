using AutoMapper;
using BookStore.CORE.Models;
using BookStore.DATA.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.AuthorOperations.CreateAuthor
{
    public class CreateAuthor
    {
        public CreateAuthorModel Model { get; set; }

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthor(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Fullname == Model.FullName);

            if (author != null)
                throw new InvalidOperationException("The author already exists.");

            author = _mapper.Map<Author>(Model);

            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string FullName { get; set; }
        public int BirthYear { get; set; }
    }
}
