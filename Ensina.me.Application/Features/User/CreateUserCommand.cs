using MediatR;

namespace Ensina.me.Application.Features.User
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
