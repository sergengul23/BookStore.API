using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.GenreOperations.CreateGenre
{
    public class CreateGenreValidator : AbstractValidator<CreateGenre>
    {
        public CreateGenreValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
        }
    }
}
