using FluentValidation;
using USP.Application.Common.Dto;
using USP.Domain.Enums;
using USP.Domain.Extensions;

namespace USP.Aplication.Common.Validators;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3);
        RuleFor(x => x.Name).MaximumLength(15);
        RuleFor(x => x.Description).MinimumLength(10);
        RuleFor(x => x.Description).MaximumLength(150);
        RuleFor(x => x.Price).NotNull();
        RuleFor(x => x.Price).LessThanOrEqualTo(50000m);
        RuleFor(x => x.Category).NotNull();
        
        RuleFor(x => x.Category).Must(t =>Category.TryFromValue(t, out _)).WithName("Category").
            WithMessage($"Category must be in list of: {EnumeExtension.ValidCategoryLisst}");
    }
}