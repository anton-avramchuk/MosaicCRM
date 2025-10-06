namespace MosaicCRM.Modules.Identity.Auth;

public enum SignInResult
{
    Success,
    InvalidCredentials,
    LockedOut,
    RequiresTwoFactor,
    NotAllowed
}