using GeoLearn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoLearn.Infra.Persistence;

public class QuizOptionConfigurations: IEntityTypeConfiguration<QuizOption>
{

    public void Configure(EntityTypeBuilder<QuizOption> builder)
    {
        builder.HasKey(qo => qo.Id);

        builder.Property(qo => qo.OptionText)
            .IsRequired()
            .HasMaxLength(500); 

        builder.Property(qo => qo.IsCorrect)
            .IsRequired();

        builder.HasOne(qo => qo.QuizQuestion)
            .WithMany(qq => qq.Options)
            .HasForeignKey(qo => qo.QuizQuestionId);
    }
}