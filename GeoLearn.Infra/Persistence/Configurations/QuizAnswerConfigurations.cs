using GeoLearn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoLearn.Infra.Persistence;

public class QuizAnswerConfigurations : IEntityTypeConfiguration<QuizAnswer>
{
    public void Configure(EntityTypeBuilder<QuizAnswer> builder)
    {
        builder.HasKey(q => q.Id);

        builder.HasMany<QuizOptionAnswer>()
            .WithOne(qoa => qoa.QuizAnswer)
            .HasForeignKey(qoa => qoa.QuizAnswerId);
    }
}