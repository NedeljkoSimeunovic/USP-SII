using MediatR;
using MongoDB.Entities;
using USP.Application.Common.Dto;
using USP.Application.Common.Interfaces;
using USP.Application.Common.Mappers;
using USP.Domain.Entities;

namespace USP.Application.Products.Queries;

public class GetAllProductQuery : IRequest<List<ProductDetailsDto>>;

public class GetAllProductQueryHandler(IProductService productService) : IRequestHandler<GetAllProductQuery, List<ProductDetailsDto>>
{

    public async Task<List<ProductDetailsDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var results = await productService.GetAllProductsAsync(cancellationToken);

        var listDto = new List<ProductDetailsDto>();

        foreach (var item in results)
        {
            var result = await item.ToDtoAsync();
            listDto.Add(result);
        }

        return listDto;
    }
}