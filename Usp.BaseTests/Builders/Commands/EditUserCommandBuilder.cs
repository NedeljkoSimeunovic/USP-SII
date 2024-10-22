using USP.Application.Common.Dto;
using USP.Application.Users.Commands;
using Usp.BaseTests.Builders.Dto;

namespace Usp.BaseTests.Builders.Commands;

public class EditUserCommandBuilder
{
    private EditUserDto _dto = new EditUserDtoBuilder().Build();
    public EditUserCommand Build() => new (_dto);
    
    public EditUserCommandBuilder WithDto(EditUserDto dto)
    {
        _dto = dto;
        return this;
    }
}