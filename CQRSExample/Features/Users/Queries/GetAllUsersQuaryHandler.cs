using CQRSExample.Data;
using CQRSExample.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.Features.Users.Queries
{
    public class GetAllUsersQuaryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly AppDbContext _context;
        public GetAllUsersQuaryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Simulate delay to test cancellation
                //await Task.Delay(6000, cancellationToken);

                return await _context.Users
                    .Select(user => new UserDto
                    {
                        Id = user.Id,
                        FullName = user.FullName,
                    })
                    .ToListAsync(cancellationToken);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("Task was cancelled: " + ex.Message);
                return new List<UserDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<UserDto>();
            }
        }
    }
}
