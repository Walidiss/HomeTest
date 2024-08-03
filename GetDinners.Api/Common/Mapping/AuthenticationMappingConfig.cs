using GetDinner.Contracts.Authentication;
using GetDinners.Application.Authentication.Common;
using Mapster;

namespace GetDinners.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                 .Map(dest => dest, src => src.user)
                 .Map(dest => dest.Token, src => src.token);
        }
    }
}
