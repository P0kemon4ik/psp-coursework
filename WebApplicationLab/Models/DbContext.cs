using System.Data.Entity;

namespace WebApplicationLab.Models
{
    public class HelpDeskContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<Battery> Batterys { get; set; }
        public DbSet<Display> Displays { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<OS> Os { get; set; }
        public DbSet<ScreenTechnology> ScreenTechnologys { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Color> Colors { get; set; }

    }
}