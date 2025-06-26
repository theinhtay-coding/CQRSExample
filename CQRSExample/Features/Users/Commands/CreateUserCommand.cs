namespace CQRSExample.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
