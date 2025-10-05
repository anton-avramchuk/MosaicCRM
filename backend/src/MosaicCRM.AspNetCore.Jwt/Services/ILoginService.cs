using MosaicCRM.AspNetCore.Jwt.Models;

namespace MosaicCRM.AspNetCore.Jwt.Services;

public interface ILoginService<in TLoginModel> where TLoginModel : ILoginModel
{
    Task<LoginResult?> LoginAsync(TLoginModel loginModel);
}