using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BUSINESS.Operations.BookOperations.CreateBook
{
    public class CreateBookValidator : AbstractValidator<CreateBook>
    {
        public CreateBookValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.PageCount).NotEmpty();
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(command => command.Model.Stock).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(command => command.Model.Price).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
