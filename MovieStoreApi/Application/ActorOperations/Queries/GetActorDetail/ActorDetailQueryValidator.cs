using System;
using FluentValidation;

namespace MovieStoreApi.Application.ActorOperations.Queries.GetActorDetail
{
    public class ActorDetailQueryValidator : AbstractValidator<ActorDetailQuery>
    {
        public ActorDetailQueryValidator()
        {
            RuleFor(c => c.ActorId).GreaterThan(0);
        }
    }
}

