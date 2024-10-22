using MediatR;
using MongoDB.Entities;
using USP.Application.Common.Dto;
using USP.Application.Common.Mappers;
using USP.Domain.Entities;
using USP.Domain.Enums;

namespace USP.Application.Products.Commands;

public record CreateProductCommand(ProductCreateDto Product): IRequest<ProductDetailsDto?>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var userEntity = new Domain.Entities.User
        {
            Email = "Nedeljko.simeunovic.21@singimail.rs",
            FirstName = "Nedeljko",
            LastName = "Simeunovic",
        };
        
        var userEntity2= new Domain.Entities.User
        {
            Email = "Nedeljko2.simeunovic.21@singimail.rs",
            FirstName = "Nedeljko2",
            LastName = "Simeunovic2",
        };
        
        
        await userEntity.SaveAsync(cancellation: cancellationToken);
        await userEntity2.SaveAsync(cancellation: cancellationToken);
        
        
        var entity = request.Product.ToEntityFromCreateDto(userEntity, new One<Domain.Entities.User>(userEntity));
        
        await entity.SaveAsync(cancellation: cancellationToken);
        entity.ReferencedOneToManyUser.AddAsync([userEntity2, userEntity], cancellation: cancellationToken);
        entity.ReferencedManyToManyUser.AddAsync([userEntity2, userEntity], cancellation: cancellationToken);
        
        var dto = await entity.ToDtoAsync();
        
        return dto;
    }
}