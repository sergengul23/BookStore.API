using AutoMapper;
using BookStore.BUSINESS.Operations.AuthorOperations.CreateAuthor;
using BookStore.BUSINESS.Operations.AuthorOperations.DeleteAuthor;
using BookStore.BUSINESS.Operations.AuthorOperations.GetAuthorDetail;
using BookStore.BUSINESS.Operations.AuthorOperations.GetAuthors;
using BookStore.BUSINESS.Operations.AuthorOperations.UpdateAuthor;
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
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetAuthors query = new GetAuthors(_context, _mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            AuthorDetailViewModel result;

            GetAuthorDetail query = new GetAuthorDetail(_context, _mapper);
            query.AuthorId = id;

            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthor command = new CreateAuthor(_context, _mapper);
            command.Model = newAuthor;

            CreateAuthorValidator validator = new CreateAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("id")]
        public IActionResult Update(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {
            UpdateAuthor command = new UpdateAuthor(_context);

            command.AuthorId = id;
            command.Model = updatedAuthor;

            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            DeleteAuthor command = new DeleteAuthor(_context);

            command.AuthorId = id;

            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
