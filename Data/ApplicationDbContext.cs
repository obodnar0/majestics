using IdentityServer4.EntityFramework.Options;
using Majestics.Models;
using Majestics.Models.Post;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Majestics.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.ChangedByUser)
                .WithMany(b => b.ChangedPosts);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.CreatedByUser)
                .WithMany(p => p.CreatedPosts);
        }

        public DbSet<Post> Posts { get; set; }
    }
}
