using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Domain.Aggregates;

namespace GavelPoMobile.Infrastructure.Pesistence.Repositories;
public class UserRepository : IUserRepository {

    private readonly GavelPoMobileDbContext _dbContext;

    public UserRepository(GavelPoMobileDbContext dbContext) {
        _dbContext = dbContext;
    }

    public User GetUserByEmail(string email) {
        return _dbContext.Users.SingleOrDefault(x => x.Email == email);
    }
}
