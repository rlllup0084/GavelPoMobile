using GavelPoMobile.Domain.Aggregates;

namespace GavelPoMobile.Application.Authentication.Common;
public record AuthenticationResult(
    User User,
    string Token
    );
