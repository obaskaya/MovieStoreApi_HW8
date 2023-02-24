using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly MovieStoreDbContext _context;
        public DeleteDirectorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public async Task Handle()
        {
            var director = _context.Directors.Include(c => c.Movies).FirstOrDefault(c => c.Id == DirectorId);
            if (director == null)
                throw new InvalidOperationException("Director doesn't exists in database");

            if (director.Movies.Any())
                throw new InvalidOperationException("Director has a movie ");

            _context.Remove(director);
            await _context.SaveChangesAsync();
        }
    }
}

