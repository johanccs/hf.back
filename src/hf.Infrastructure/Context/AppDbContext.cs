using hf.Application.Exceptions;
using hf.Domain.Abstractions;
using hf.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace hf.Infrastructure.Context
{
    public class AppDbContext:DbContext, IUnitOfWork
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }

        DbSet<User>Users { get; set; }
        DbSet<Product>Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int>SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);

                //Send domain events if implemented

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("Concurrency exception occurred", ex);
            }
        }
    }
}
