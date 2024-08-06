using GeoLearn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoLearn.Infra.Persistence;

public class QuizOptionAnswerConfigurations : IEntityTypeConfiguration<QuizOptionAnswer>
{
    public void Configure(EntityTypeBuilder<QuizOptionAnswer> builder)
    {
        builder.HasKey(qoa => qoa.Id);

        builder.HasOne<QuizAnswer>()
            .WithMany(qa => qa.QuizOptionAnswers)
            .HasForeignKey(qoa => qoa.QuizAnswerId);
        
        builder.HasOne<QuizOption>()
            .WithMany(qa => qa.QuizOptionAnswers)
            .HasForeignKey(qoa => qoa.QuizOptionId);
    }
}