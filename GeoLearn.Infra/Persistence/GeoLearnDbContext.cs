using System.Reflection;
using GeoLearn.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoLearn.Infra.Persistence;

public class GeoLearnDbContext : DbContext
{
    public GeoLearnDbContext(DbContextOptions<GeoLearnDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes{ get; set; }
    public DbSet<QuizOption> QuizOptions {get; set;}
    public DbSet<QuizQuestion> QuizQuestions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}