using IdentityServer4.EntityFramework.Options;
using Majestics.Models;
using Majestics.Models.Contest.dto;
using Majestics.Models.Data;
using Majestics.Models.Post;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Majestics.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<User>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Criteria> Criterias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.ChangedByUser)
                .WithMany(b => b.ChangedPosts)
                .HasForeignKey(x => x.ChangedByUserId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.CreatedByUser)
                .WithMany(p => p.CreatedPosts)
                .HasForeignKey(x => x.CreatedByUserId);

            modelBuilder.Entity<Work>()
                .HasOne(x => x.User)
                .WithMany(x => x.Works)
                .HasForeignKey(x => x.UserId);
            
            modelBuilder.Entity<Work>()
                .HasOne(x => x.Contest)
                .WithMany(x => x.Works)
                .HasForeignKey(x => x.ContestId);

            modelBuilder.Entity<UserContest>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.Contests)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserContest>()
                .HasOne(bc => bc.Contest)
                .WithMany(c => c.Users)
                .HasForeignKey(bc => bc.ContestId);

            modelBuilder.Entity<Work>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.Works)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<Mark>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.Marks)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<Mark>()
                .HasOne(bc => bc.Work)
                .WithMany(b => b.Marks)
                .HasForeignKey(c => c.WorkId);

            modelBuilder.Entity<Criteria>()
                .HasOne(bc => bc.Contest)
                .WithMany(b => b.Criterias)
                .HasForeignKey(c => c.ContestId);
        }
    }
}
