using CQRSExample.Data;
using MediatR;
using System.Threading.Tasks;

namespace CQRSExample.Features.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);

            if (user == null) return false;

            user.FullName = request.FullName;
            user.Email = request.Email;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
