using GeoLearn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoLearn.Infra.Persistence;

public class QuizConfigurations : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Description)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(q => q.Title)
            .IsRequired()
            .HasMaxLength(100);
    }
}