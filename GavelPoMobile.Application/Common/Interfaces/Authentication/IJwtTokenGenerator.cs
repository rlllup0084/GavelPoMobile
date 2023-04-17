using GavelPoMobile.Domain.Aggregates;

namespace GavelPoMobile.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator {
    string GenerateToken(User user);
}
