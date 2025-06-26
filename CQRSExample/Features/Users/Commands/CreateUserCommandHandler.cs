using CQRSExample.Data;
using CQRSExample.Models;
using MediatR;

namespace CQRSExample.Features.Users.Commands
{
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
