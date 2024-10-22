using FluentValidation;
using USP.Aplication.Common.Validators;
using USP.Domain.Enums;
using USP.Domain.Extensions;

namespace USP.Application.Products.Commands;

public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product).NotNull();
        RuleFor(x => x.Product).SetValidator(new ProductCreateDtoValidator());
    }
}