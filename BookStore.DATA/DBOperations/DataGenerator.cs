using BookStore.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.DATA.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre
                    {
                        Id = 1,
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Id = 2,
                        Name = "Novel"
                    },
                    new Genre
                    {
                        Id = 3,
                        Name = "Mystery"
                    });

                context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "The Fall",
                        AuthorId = 1,
                        GenreId = 2,
                        PageCount = 147,
                        PublishDate = new DateTime(1956, 10, 23),
                        Stock = 50,
                        Price = 10
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Notes from Underground",
                        AuthorId = 2,
                        GenreId = 2,
                        PageCount = 146,
                        PublishDate = new DateTime(1864, 10, 23),
                        Stock = 40,
                        Price = 10
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Do Android's Dream of Electric Sheep",
                        AuthorId = 3,
                        GenreId = 1,
                        PageCount = 210,
                        PublishDate = new DateTime(1968, 10, 23),
                        Stock = 50,
                        Price = 10
                    },
                    new Book
                    {
                        Id = 4,
                        Title = "Rebecca",
                        AuthorId = 4,
                        GenreId = 3,
                        PageCount = 416,
                        PublishDate = new DateTime(1938, 10, 23),
                        Stock = 30,
                        Price = 10
                    });

                context.Authors.AddRange(
                    new Author
                    {
                        Id = 1,
                        Fullname = "Albert Camus",
                        BirthYear = 1913
                    },
                    new Author
                    {
                        Id = 2,
                        Fullname = "Fyodor Dostoyevski",
                        BirthYear = 1821
                    },
                    new Author
                    {
                        Id = 3,
                        Fullname = "Philipp K. Dick",
                        BirthYear = 1928
                    },
                    new Author
                    {
                        Id = 4,
                        Fullname = "Daphne Maurier",
                        BirthYear = 1907
                    });

                context.SaveChanges();
            }
        }
    }
}
