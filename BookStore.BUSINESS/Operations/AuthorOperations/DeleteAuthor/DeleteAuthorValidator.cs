using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthor>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}
