using System;
using FluentValidation;

namespace MovieStoreApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(c => c.MovieId).GreaterThan(0);
        }
    }
}

