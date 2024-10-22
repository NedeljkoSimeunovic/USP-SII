﻿using FluentValidation;
using MediatR;
using USP.Aplication.Common.Exceptions;
using USP.Aplication.Common.Extensions;

namespace USP.Aplication.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }
        
        var context = new ValidationContext<TRequest>(request);
        
        var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, 
            cancellationToken)));
        
        var failures = validationResults.Where(r => r.Errors.Count != 0)
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Count != 0)
            throw new UspValidationException(failures.ToGroup());
        
        return await next();
    }
}