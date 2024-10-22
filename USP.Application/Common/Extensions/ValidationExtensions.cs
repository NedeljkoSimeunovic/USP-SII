
using FluentValidation.Results;

namespace USP.Aplication.Common.Extensions;

public static class ValidationExtensions
{
    public static IDictionary<string, string[]> ToGroup(this List<ValidationFailure> validationFailures)
    {
        return validationFailures.GroupBy(e => e.PropertyName,
            e => e.ErrorMessage)
            .ToDictionary(failuerGroup => failuerGroup.Key,
                failuerGroup => failuerGroup.ToArray());
    }
}