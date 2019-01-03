using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASPForum_.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        public List<Topic> Topics { get; set; }
        public List<Comment> Comments { get; set; }
    }
    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Entities Tables Naming
            modelBuilder.Entity<Topic>().ToTable("Topics");
            modelBuilder.Entity<Comment>().ToTable("Coments");
            #endregion Entities Tables Naming

            #region Setting Entities DateTime2 ColumnType
            modelBuilder.Entity<Topic>().Property(e => e.CreationDate).HasColumnType("datetime2");
            modelBuilder.Entity<Comment>().Property(e => e.CreatedDate).HasColumnType("datetime2");
            #endregion Setting Entities DateTime2 ColumnType

            #region Creating Entities Relationships
            modelBuilder.Entity<Topic>().HasMany(e => e.Comments).WithRequired(e => e.Topic).WillCascadeOnDelete(true);
            modelBuilder.Entity<ApplicationUser>().HasMany(e => e.Topics).WithRequired(e => e.User).WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>().HasMany(e => e.Comments).WithRequired(e => e.User).WillCascadeOnDelete(false);
            #endregion Creating Entities Relationships
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}