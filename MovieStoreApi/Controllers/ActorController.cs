using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Application.ActorOperations.Commands.CreateActor;
using MovieStoreApi.Application.ActorOperations.Commands.DeleteActor;
using MovieStoreApi.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreApi.Application.ActorOperations.Queries.GetActorDetail;
using MovieStoreApi.Application.ActorOperations.Queries.GetActors;
using MovieStoreApi.DbOperations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    public class ActorController : Controller
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ActorController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET All Actor
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetActorQuery query = new(_context, _mapper);
            var result = await query.Handle();
            return Ok(result);
        }

        // GET Actor by id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ActorDetailQuery query = new(_context, _mapper);
            query.ActorId = id;

            ActorDetailQueryValidator validator = new ActorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = await query.Handle();
            return Ok(result);
        }

        // create actor
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateActorModel newActor)
        {
            CreateActorCommand command = new(_context, _mapper);
            command.Model = newActor;
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(command);

            await command.Handle();
            return Ok();
        }

        // update actor
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateActorModel updateActor)
        {
            UpdateActorCommand command = new(_context);
            command.ActorId = id;
            command.Model = updateActor;
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);

            await command.Handle();
            return Ok();
        }

        // DELETE actor
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteActorCommand command = new(_context);
            command.ActorId = id;
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.ValidateAndThrow(command);

            await command.Handle();
            return Ok();
        }
    }
}

