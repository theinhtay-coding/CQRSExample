using CQRSExample.DTOs;
using MediatR;

namespace CQRSExample.Features.Users.Queries
{
    public class GetAllUsersQuery: IRequest<List<UserDto>>
    {

    }
}
