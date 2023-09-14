// Ignore Spelling: App Jameel

using JameelApp.Domain;
using JameelApp.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JameelApp.EntityFramework.SQLServer
{
    public class JameelDatabaseContext : DbContext
    {

        public JameelDatabaseContext(DbContextOptions<JameelDatabaseContext> dbContextOptions)
                    : base(dbContextOptions)
        {

        }

        public DbSet<JameelUser> JameelUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JameelUser>(options =>
            {
                options.ToTable(nameof(JameelUsers), JameelAppConstants.DbScheme);
                options.Property(x => x.FirstName).IsRequired().HasMaxLength(JameelAppConstants.DbNamesStringLength);
                options.Property(x => x.LastName).HasMaxLength(JameelAppConstants.DbNamesStringLength);
                options.Property(x => x.DateOfBirth).IsRequired();
                options.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(JameelAppConstants.DbPhoneNumberStringLength);
                options.Property(x => x.Address).IsRequired().HasMaxLength(JameelAppConstants.DbAddressStringLength);
            });
        }

    }
}