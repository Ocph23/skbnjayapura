using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using skbnjayapura.Shared;

namespace skbnjayapura.Server.Datas
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Permohoan> Permohoans { get; set; }
        public DbSet<Persyaratan> Persyaratans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SKBN>().HasIndex(p => p.Nomor).IsUnique();
            base.OnModelCreating(builder);
        }
    }
}
