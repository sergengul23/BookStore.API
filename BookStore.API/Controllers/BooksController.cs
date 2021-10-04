using AutoMapper;
using BookStore.BUSINESS.Operations.BookOperations.CreateBook;
using BookStore.BUSINESS.Operations.BookOperations.DeleteBook;
using BookStore.BUSINESS.Operations.BookOperations.GetBookDetail;
using BookStore.BUSINESS.Operations.BookOperations.GetBooks;
using BookStore.BUSINESS.Operations.BookOperations.UpdateBook;
using BookStore.DATA.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            GetBooks query = new GetBooks(_context, _mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetDetail(int id)
        {
            BookDetailViewModel result;

            GetBookDetail query = new GetBookDetail(_context, _mapper);
            query.BookId = id;

            GetBookDetailValidator validator = new GetBookDetailValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateBookModel newBook)
        {
            CreateBook command = new CreateBook(_context, _mapper);
            command.Model = newBook;

            CreateBookValidator validator = new CreateBookValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("id")]
        public IActionResult Update(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBook command = new UpdateBook(_context);

            command.BookId = id;
            command.Model = updatedBook;

            UpdateBookValidator validator = new UpdateBookValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            DeleteBook command = new DeleteBook(_context);

            command.BookId = id;

            DeleteBookValidator validator = new DeleteBookValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
