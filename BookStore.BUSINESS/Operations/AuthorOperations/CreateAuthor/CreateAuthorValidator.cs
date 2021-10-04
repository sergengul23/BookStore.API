using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.AuthorOperations.CreateAuthor
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthor>
    {
        public CreateAuthorValidator()
        {
            RuleFor(command => command.Model.FullName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.BirthYear).NotEmpty();
        }
    }
}
