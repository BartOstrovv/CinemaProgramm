using DLL.Model;
using Microsoft.EntityFrameworkCore;

namespace DLL.Context
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.Entity<Employee>().HasOne(e => e.UserInfo).WithOne(l => l.Employee).HasForeignKey<Employee>(e=>e.LoginDataID).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Film>().HasMany(f => f.Sessions).WithOne(s => s.Film).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Hall>().HasMany(h => h.Places).WithOne(p => p.Hall).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Ticket>().HasOne(t => t.Place).WithOne(p => p.Ticket).HasForeignKey<Ticket>(t=>t.PlaceID).IsRequired();
            builder.Entity<Ticket>().HasOne(t => t.Session).WithMany(s => s.Tickets);
            builder.Entity<Ticket>().HasOne(t => t.Employee).WithMany(e => e.Tickets);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<LoginData> Logins { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
