using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using USP.Application.Common.Dto;
using USP.Application.Users.Commands;
using Usp.Base;
using Usp.BaseTests.Builders.Commands;
using Usp.BaseTests.Builders.Dto;
using Xunit.Sdk;

namespace USP.UnitTests.Users.Commands;

public class CreateUserTests : Base
{
    [Fact]
    public async Task CreateUserCommand_User_UserCreated()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder().
            WithFirstName("Nedeljko").
            WithlastName("Simeunovic").
            Withemail("nedeljko.simeunovic.21@singimail.rs").
            Build();
        //var dto = new EditUserDto("Nedeljko", "Simeunovicmalosire", "nedeljko.simeunovic.21@singimail.rs", null);
        var command = new EditUserCommandBuilder().
            WithDto(dto).
            Build();
        
        var json = JsonSerializer.Serialize(command);
        var conntent =new StringContent(json, Encoding.UTF8, "application/json");
        
        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/user/Edit", conntent);
        
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();
        
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact]
    public async Task CreateUserCommand_InvalidFirstName_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder().
            WithlastName("Simeunovic").
            Withemail("nedeljko.simeunovic.21@singimail.rs").
            Build();
        
        var command = new EditUserCommandBuilder().
            WithDto(dto).
            Build();
        
        var json = JsonSerializer.Serialize(command);
        var conntent =new StringContent(json, Encoding.UTF8, "application/json");
        
        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/user/Edit", conntent);
        
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();
        
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        
    }
    
    [Fact]
    public async Task CreateUserCommand_InvalidLastName_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder().
            WithFirstName("Nedeljko").
            Withemail("nedeljko.simeunovic.21@singimail.rs").
            Build();
        
        var command = new EditUserCommandBuilder().
            WithDto(dto).
            Build();
        
        var json = JsonSerializer.Serialize(command);
        var conntent =new StringContent(json, Encoding.UTF8, "application/json");
        
        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/user/Edit", conntent);
        
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();
        
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        
    }
    [Fact]
    public async Task CreateUserCommand_InvalidEmail_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder().
            WithFirstName("Nedeljko").
            WithlastName("Simeunovic").
            Build();
        
        var command = new EditUserCommandBuilder().
            WithDto(dto).
            Build();
        
        var json = JsonSerializer.Serialize(command);
        var conntent =new StringContent(json, Encoding.UTF8, "application/json");
        
        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/user/Edit", conntent);
        
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();
        
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        
    }
}