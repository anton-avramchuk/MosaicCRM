using MosaicCRM.Modules.Identity.AspNetCore.Jwt.Options;

namespace MosaicCRM.Modules.Identity.AspNetCore.Jwt.Services.Abstractions;

public interface IJwtConfigurationProvider
{
    JwtConfiguration Configuration { get; }
}