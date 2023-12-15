using Lilya.Models;
using Microsoft.EntityFrameworkCore;

    public class MainDbContext : DbContext
    {
    public MainDbContext(DbContextOptions<MainDbContext> options)
    : base(options)
    {
    }
    public DbSet<Author> Authors { get; set; }
        public DbSet<Process> Processes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Db/my.db");
    }
