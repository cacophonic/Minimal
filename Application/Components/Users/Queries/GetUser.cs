using Application.Components.Users.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Components.Users.Queries
{
    internal class GetUser : IRequest<User>
    {
        public GetUser(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public class Handler : IRequestHandler<GetUser, User>
        {
            public async Task<User> Handle(GetUser request, CancellationToken cancellationToken)
            {
                return new User { 
                    Id = request.Id,
                    Name = "Bob"
                };
            }
        }
    }
}
