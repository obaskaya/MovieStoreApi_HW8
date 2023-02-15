
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreApi.Application.MovieOperations.Commands.DeleteMovie;
using MovieStoreApi.Application.MovieOperations.Commands.UpdateMovie;
using MovieStoreApi.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStoreApi.Application.MovieOperations.Queries.GetMovies;
using MovieStoreApi.DbOperations;



namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public MovieController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: All Movies
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            GetMovieQuery query = new (_context, _mapper);
            var result = await query.Handle();

            return Ok(result);
        }

        // GET Movie Detail
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            MovieDetailQuery query = new(_context, _mapper);
            query.MovieId = id;
            MovieDetailQueryValidator validator = new MovieDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = await query.Handle();
            return Ok(result);
        }

        // POST Movie
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new(_context, _mapper);
            command.Model = newMovie;
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            await command.Handle();

            return Ok();
        }

        // PUT Movie
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateMovieModel updateMovie)
        {
            UpdateMovieCommand update = new(_context);
            update.Model = updateMovie;
            update.MovieId = id;
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            validator.ValidateAndThrow(update);
            await update.Handle();

            return Ok();
        }

        // DELETE Movie
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteMovieCommand command = new(_context);
            command.MovieId = id;
            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            validator.ValidateAndThrow(command);
            await command.Handle();
            return Ok();
        }
    }
}

