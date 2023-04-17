using GavelPoMobile.Application.Authentication.Common;
using GavelPoMobile.Application.Authentication.Queries.Login;
using GavelPoMobile.Contract.Authentication;
using Mapster;

namespace GavelPoMobile.Api.Common.Mapping;
public class AuthenticationMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
