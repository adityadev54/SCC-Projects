using GoldenMenu.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace GoldenMenu.Data.DBContext
{
    public class GMDbContext : DbContext
    {
        public GMDbContext(DbContextOptions<GMDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
    }
}
