using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Components.Users.Commands
{
    internal class DeleteUser : IRequest
    {
        public DeleteUser(int Id)
        {
            this.Id = Id;
        }

        public int Id { get; }

        public class Handler : IRequestHandler<DeleteUser>
        {
            public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
            {
                return new Unit();
            }
        }
    }
}
