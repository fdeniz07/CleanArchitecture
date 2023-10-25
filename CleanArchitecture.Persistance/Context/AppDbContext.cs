using CleanArchitecture.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Context
{
    public sealed class AppDbContext : DbContext
    {

        // I. Yol
        //AppDbContext context = new();
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        //private readonly AppDbContext _context;

        //public AppDbContext(AppDbContext context)
        //{
        //    _context = context;
        //}

        // II. Yol - Connection Bilgisini AppSettings.json dosyasinda tutmamizi sagliyor (Best Practice)
        public AppDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);


        //Kayit isleminde (ekleme ve güncellemede ilgili alanlari otomatik ekleme)
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(p => p.CreatedDate).CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdatedDate).CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
