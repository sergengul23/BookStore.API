using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.GenreOperations.UpdateGenre
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenre>
    {
        public UpdateGenreValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.Name).MinimumLength(3).When(x => x.Model.Name != string.Empty);
        }
    }
}
