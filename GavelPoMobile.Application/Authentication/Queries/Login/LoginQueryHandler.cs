using ErrorOr;
using GavelPoMobile.Application.Authentication.Common;
using GavelPoMobile.Application.Common.Interfaces.Authentication;
using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Domain.Aggregates;
using GavelPoMobile.Domain.Common.Errors;
using MediatR;

namespace GavelPoMobile.Application.Authentication.Queries.Login;
public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>> {

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken) {
        await Task.CompletedTask;

        // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user) {
            return new[] { Errors.Authentication.InvalidCredentials };
        }

        // 2. Validate the password is correct
        if (user.Popassword != query.Password) {
            return new[] { Errors.Authentication.InvalidCredentials };
        }

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
