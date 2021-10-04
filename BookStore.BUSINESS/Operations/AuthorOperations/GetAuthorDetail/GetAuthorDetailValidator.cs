using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailValidator : AbstractValidator<GetAuthorDetail>
    {
        public GetAuthorDetailValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}
