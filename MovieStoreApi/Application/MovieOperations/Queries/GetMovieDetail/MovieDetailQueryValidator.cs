using System;
using FluentValidation;

namespace MovieStoreApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class MovieDetailQueryValidator : AbstractValidator<MovieDetailQuery>
    {
        public MovieDetailQueryValidator()
        {
            RuleFor(c => c.MovieId).GreaterThan(0);
        }
    }
}

