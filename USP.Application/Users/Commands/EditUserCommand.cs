using MediatR;
using MongoDB.Entities;
using USP.Application.Common.Dto;
using USP.Application.Common.Mappers;

namespace USP.Application.Users.Commands;

public record EditUserCommand(EditUserDto User): IRequest;

public class EditUserCommandVHandler : IRequestHandler<EditUserCommand>
{
    public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var entity = request.User.ToDEntity();

        await entity.SaveAsync(cancellation: cancellationToken);
    }
}

