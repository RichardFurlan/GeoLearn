using GeoLearn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoLearn.Infra.Persistence;

public class QuizQuestionConfigurations : IEntityTypeConfiguration<QuizQuestion>
{
    public void Configure(EntityTypeBuilder<QuizQuestion> builder)
    {
        builder.HasKey(qq => qq.Id);

        builder.Property(qq => qq.QuestionText)
            .IsRequired()
            .HasMaxLength(1000); 

        builder.HasOne(qq => qq.Quiz)
            .WithMany(q => q.Questions)
            .HasForeignKey(qq => qq.QuizId);
    }
}