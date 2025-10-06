namespace MosaicCRM.Modules.Identity.Auth.Services.Abstractions;

public interface IAuthService
{
    Task<SignInResult> SignIn(string userName, string password);
}

