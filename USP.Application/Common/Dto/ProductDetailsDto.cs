namespace USP.Application.Common.Dto;

public record ProductDetailsDto(
    string Name,
    string Description,
    decimal Price,
    UserDetailsDto ReferemceOneUser,
    ListUserDetailsDto ReferenceOneToManyUser,
    ListUserDetailsDto ReferenceManyToManyUser);