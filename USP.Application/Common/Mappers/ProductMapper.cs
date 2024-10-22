using MongoDB.Entities;
using Riok.Mapperly.Abstractions;
using USP.Application.Common.Dto;
using USP.Domain.Entities;



namespace USP.Application.Common.Mappers;

[Mapper]
public static partial class ProductMapper
{
   public static async Task<ProductDetailsDto> ToDtoAsync(this Domain.Entities.Product entity)
   {
      var userDetails = await entity.ReferencedOneToOneUser.ToEntityAsync();
      var userDetailsDto = userDetails.ToDto();

      return new ProductDetailsDto(entity.Name, entity.Description, entity.Price, userDetailsDto,
         entity.ReferencedOneToManyUser.ToListDto(), entity.ReferencedManyToManyUser.ToListDto());
   }

   public static ProductCustomDetailsDto ToCustomDto(this Domain.Entities.Product entity)
   {
      return new ProductCustomDetailsDto(entity.Name + "- " + entity.Price);
   }

   public static Domain.Entities.Product ToEntityFromCreateDto
      (this ProductCreateDto dto, Domain.Entities.User user, 
         One<Domain.Entities.User> referencedOneToOneUser)
   {
      var entity = new Domain.Entities.Product
      {
         Name = dto.Name,
         Description = dto.Description,
         Price = dto.Price,
         // Category = Category.FromValue(dto.Category),
         User = user,
         ReferencedOneToOneUser = referencedOneToOneUser
      };
      
      return entity;
   }

   public static async Task<ProductEmbedded> ToEmbedded(this Product entity)
   {
      return new ProductEmbedded()
      {
         Name = entity.Name,
         Description = entity.Description,
         Price = entity.Price,
         User = entity.User,
         ReferencedOneToOneUser = await entity.ReferencedOneToOneUser.ToEntityAsync(),
         ReferencedOneToManyUser = entity.ReferencedOneToManyUser.ToListEntity(),
         ReferencedManyToManyUser = entity.ReferencedManyToManyUser.ToListEntity()
      };
   }
}