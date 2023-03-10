using System;
using AutoMapper;
using MovieStoreApi.DbOperations;

namespace MovieStoreApi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId { get; set; }
        private readonly MovieStoreDbContext _context;
        private IMovieStoreDbContext context;

        public DeleteActorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }

        public async Task Handle()
        {
            var actor = _context.Actors.FirstOrDefault(c => c.Id == ActorId);
            if (actor == null)
                throw new InvalidOperationException("Actor doesn't exist in database");

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }
    }
}

