using Microsoft.EntityFrameworkCore;
using MoleculeOSSite.Entities;

namespace MoleculeOSSite
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var connectionString = $"Host={dbHost};Database={dbName};Username={dbUser};Password={dbPassword}";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
