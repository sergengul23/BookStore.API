using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthor>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.Fullname).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.BirthYear).NotEmpty();
        }
    }
}
