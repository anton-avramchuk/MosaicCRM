using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MosaicCRM.Core.DependencyInjection;

namespace MosaicCRM.Authorization.Abstractions;

public interface ICrmAuthorizationService : IAuthorizationService, IServiceProviderAccessor
{
    ClaimsPrincipal? CurrentPrincipal { get; }
}