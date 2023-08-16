using CheckList.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckList.Infrastructure.Data
{
    public class CheckListDbContext : DbContext
    {
        public CheckListDbContext()
        {

        }
        public CheckListDbContext(DbContextOptions<CheckListDbContext> options) : base(options)
        {

        }
        public DbSet<Date> Dates { get; set; } = null!;
        public DbSet<GoalItem> GoalItems { get; set; } = null!;
        public DbSet<Motivation> Motivations { get; set; } = null!;
        public DbSet<ScheduleItem> ScheduleItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;Database=CheckList;User Id=sa;Password=big!1@StrongPwd;TrustServerCertificate=true";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}