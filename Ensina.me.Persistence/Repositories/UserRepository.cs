using Ensina.me.Application.Contracts.Persistence;
using Ensina.me.Domain.Entities;
using GlobalTicket.TicketManagement.Persistence.Repositories;

namespace Ensina.me.Persistence.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(EnsinameDbContext dbContext) : base(dbContext)
        {

        }
    }
}
