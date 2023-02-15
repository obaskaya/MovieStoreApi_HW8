using System;
using FluentValidation;

namespace MovieStoreApi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class DirectorDetailQueryValidator : AbstractValidator<DirectorDetailQuery>
    {
        public DirectorDetailQueryValidator()
        {
            RuleFor(c => c.DirectorId).GreaterThan(0);
        }
    }
}

