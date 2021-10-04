using AutoMapper;
using BookStore.DATA.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.BUSINESS.Operations.GenreOperations.GetGenres
{
    public class GetGenres
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenres(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id).ToList();
            List<GenresViewModel> vm = _mapper.Map<List<GenresViewModel>>(genres);

            return vm;
        }
    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
