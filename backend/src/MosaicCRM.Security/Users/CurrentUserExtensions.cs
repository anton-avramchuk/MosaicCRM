using System.Diagnostics;
using MosaicCRM.Core.Extensions.Common;
using MosaicCRM.Security.Users.Abstractions;

namespace MosaicCRM.Security.Users;

public static class CurrentUserExtensions
{
    public static string? FindClaimValue(this ICurrentUser currentUser, string claimType)
    {
        return currentUser.FindClaim(claimType)?.Value;
    }

    public static T FindClaimValue<T>(this ICurrentUser currentUser, string claimType)
        where T : struct
    {
        var value = currentUser.FindClaimValue(claimType);
        if (value == null)
        {
            return default;
        }

        return value.To<T>();
    }

    public static Guid GetId(this ICurrentUser currentUser)
    {
        Debug.Assert(currentUser.Id != null, "currentUser.Id != null");

        return currentUser.Id.Value;
    }


}