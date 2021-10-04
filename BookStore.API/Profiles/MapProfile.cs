using AutoMapper;
using BookStore.BUSINESS.Operations.AuthorOperations.CreateAuthor;
using BookStore.BUSINESS.Operations.AuthorOperations.GetAuthorDetail;
using BookStore.BUSINESS.Operations.AuthorOperations.GetAuthors;
using BookStore.BUSINESS.Operations.BookOperations.CreateBook;
using BookStore.BUSINESS.Operations.BookOperations.GetBookDetail;
using BookStore.BUSINESS.Operations.BookOperations.GetBooks;
using BookStore.BUSINESS.Operations.GenreOperations.CreateGenre;
using BookStore.BUSINESS.Operations.GenreOperations.GetGenreDetail;
using BookStore.BUSINESS.Operations.GenreOperations.GetGenres;
using BookStore.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateBookModel, Book>();

            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre,
                opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.
                ToString("dd\\/MM\\/yyyy"))).ForMember(dest => dest.Author,
                opt => opt.MapFrom(src => src.Author.Fullname));

            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre,
                opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.
                ToString("dd\\/MM\\/yyyy"))).ForMember(dest => dest.Author,
                opt => opt.MapFrom(src => src.Author.Fullname));

            CreateMap<CreateGenreModel, Genre>();

            CreateMap<Genre, GenresViewModel>();

            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<CreateAuthorModel, Author>();

            CreateMap<Author, AuthorsViewModel>();

            CreateMap<Author, AuthorDetailViewModel>();
        }
    }
}
