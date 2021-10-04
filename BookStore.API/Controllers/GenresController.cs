using AutoMapper;
using BookStore.BUSINESS.Operations.GenreOperations.CreateGenre;
using BookStore.BUSINESS.Operations.GenreOperations.DeleteGenre;
using BookStore.BUSINESS.Operations.GenreOperations.GetGenreDetail;
using BookStore.BUSINESS.Operations.GenreOperations.GetGenres;
using BookStore.BUSINESS.Operations.GenreOperations.UpdateGenre;
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
    public class GenresController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            GetGenres query = new GetGenres(_context, _mapper);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetDetail(int id)
        {
            GetGenreDetail query = new GetGenreDetail(_context, _mapper);
            query.GenreId = id;

            GetGenreDetailValidator validator = new GetGenreDetailValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateGenreModel newGenre)
        {
            CreateGenre command = new CreateGenre(_context);
            command.Model = newGenre;

            CreateGenreValidator validator = new CreateGenreValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("id")]
        public IActionResult Update(int id, [FromBody] UpdateGenreModel updatedGenre)
        {
            UpdateGenre command = new UpdateGenre(_context);
            command.GenreId = id;
            command.Model = updatedGenre;

            UpdateGenreValidator validator = new UpdateGenreValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            DeleteGenre command = new DeleteGenre(_context);
            command.GenreId = id;

            DeleteGenreValidator validator = new DeleteGenreValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
