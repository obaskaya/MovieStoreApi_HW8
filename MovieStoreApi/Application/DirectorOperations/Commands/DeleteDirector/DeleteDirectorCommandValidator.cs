using System;
using FluentValidation;

namespace MovieStoreApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(c => c.DirectorId).GreaterThan(0);
        }
    }
}

