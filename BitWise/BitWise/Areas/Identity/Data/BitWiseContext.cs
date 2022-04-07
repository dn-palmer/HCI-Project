using BitWise.Areas.Identity.Data;
using BitWise.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BitWise.Data;

public class BitWiseContext : IdentityDbContext<BitWiseUser>
{
    public BitWiseContext(DbContextOptions<BitWiseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Trophy> Trophies { get; set; }

}
