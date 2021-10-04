using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailValidator : AbstractValidator<GetGenreDetail>
    {
        public GetGenreDetailValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}
