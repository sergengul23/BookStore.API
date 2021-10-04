using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.BookOperations.DeleteBook
{
    public class DeleteBookValidator : AbstractValidator<DeleteBook>
    {
        public DeleteBookValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
