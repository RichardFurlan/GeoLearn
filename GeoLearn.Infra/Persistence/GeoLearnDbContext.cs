using System.Reflection;
using GeoLearn.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoLearn.Infrastructure.Persistence;

public class GeoLearnDbContext : DbContext
{
    public GeoLearnDbContext(DbContextOptions<GeoLearnDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}