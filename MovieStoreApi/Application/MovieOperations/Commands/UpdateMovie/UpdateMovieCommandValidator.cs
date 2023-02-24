using System;
using FluentValidation;

namespace MovieStoreApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(c => c.MovieId).GreaterThan(0);
            RuleFor(c => c.Model.Name).NotEmpty();
            RuleFor(c => c.Model.DirectorId).GreaterThan(0);
            RuleFor(c => c.Model.GenreId).GreaterThan(0);
            RuleFor(c => c.Model.Year).GreaterThan(0);
            RuleFor(c => c.Model.Price).GreaterThan(0);
        }
    }
}

