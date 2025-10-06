using MosaicCRM.AspNetCore.Jwt.Models;

namespace MosaicCRM.Modules.Identity.AspNetCore.Jwt;

public record LoginModel : ILoginModel
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}