using Microsoft.Extensions.Options;
using MosaicCRM.Core.DependencyInjection;
using MosaicCRM.Modules.Identity.AspNetCore.Jwt.Options;
using MosaicCRM.Modules.Identity.AspNetCore.Jwt.Services.Abstractions;

namespace MosaicCRM.Modules.Identity.AspNetCore.Jwt.Services;


[Export(LifetimeType.Singleton,typeof(IJwtConfigurationProvider))]
public class JwtConfigurationProvider(IOptions<JwtConfiguration> options) : IJwtConfigurationProvider
{
    public JwtConfiguration Configuration { get; } = options.Value;
}