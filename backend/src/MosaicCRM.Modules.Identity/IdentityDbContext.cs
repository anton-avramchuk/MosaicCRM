using Microsoft.EntityFrameworkCore;
using MosaicCRM.EntityFramework;
using MosaicCRM.Modules.Identity.Domain;

namespace MosaicCRM.Modules.Identity;

public abstract class IdentityDbContext<TDbContext, TIdentityUser, TIdentityRole> : CrmDbContext<TDbContext>, IIdentityDbContext
    where TIdentityUser : CrmIdentityUser<TIdentityRole> where TIdentityRole : CrmIdentityRole where TDbContext : DbContext
{
    protected IdentityDbContext(DbContextOptions<TDbContext> options) : base(options)
    {
    }


}