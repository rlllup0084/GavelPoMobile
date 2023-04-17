using GavelPoMobile.Domain.Aggregates;

namespace GavelPoMobile.Application.Common.Interfaces.Persistence; 
public interface IUserRepository {
    User GetUserByEmail(string email);
}
