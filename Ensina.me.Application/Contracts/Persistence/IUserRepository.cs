using Ensina.me.Domain.Entities;

namespace Ensina.me.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}