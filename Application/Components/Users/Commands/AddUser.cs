using Application.Components.Users.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Components.Users.Commands
{
    internal class AddUser : IRequest<User>
    {
        public AddUser(User user)
        {
            User = user;
        }

        public User User { get; }

        public class Handler : IRequestHandler<AddUser, User>
        {
            public async Task<User> Handle(AddUser request, CancellationToken cancellationToken)
            {
                var result = request.User;

                result.Id = 100;

                return result;
            }
        }
    }
}