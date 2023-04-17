using ErrorOr;
using GavelPoMobile.Application.Authentication.Common;
using MediatR;

namespace GavelPoMobile.Application.Authentication.Queries.Login;
public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
