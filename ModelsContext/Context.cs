namespace ModelsContext
{
    using ModelsContext.Models;
    using System.Data.Entity;

    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        { }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<UserLogins> UserLogins { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}