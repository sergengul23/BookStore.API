using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.GenreOperations.DeleteGenre
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenre>
    {
        public DeleteGenreValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}
