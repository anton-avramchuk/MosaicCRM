namespace MosaicCRM.AspNetCore.Jwt.Models;

public class LoginResult(string token, string userName, string userFullName, string[] roles, string[] claims)
{
    public string Token { get; } = token ?? throw new ArgumentNullException(nameof(token));

    public string UserName { get; } = userName ?? throw new ArgumentNullException(nameof(userName));
    public string UserFullName { get; } = userFullName ?? throw new ArgumentNullException(nameof(userFullName));

    public string[] Roles { get; } = roles ?? throw new ArgumentNullException(nameof(roles));

    public string[] Claims { get; } = claims ?? throw new ArgumentNullException(nameof(claims));
}