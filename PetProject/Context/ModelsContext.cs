using PetProject.Models;
using System.Data.Entity;

namespace PetProject.Context
{
    public class ModelsContext : DbContext
    {
        public ModelsContext()
           : base("DefaultConnection")
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public static ModelsContext Create()
        {
            return new ModelsContext();
        }
    }
}