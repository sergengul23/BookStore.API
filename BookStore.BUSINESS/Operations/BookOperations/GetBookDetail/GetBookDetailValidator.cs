using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.BookOperations.GetBookDetail
{
    public class GetBookDetailValidator : AbstractValidator<GetBookDetail>
    {
        public GetBookDetailValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}
