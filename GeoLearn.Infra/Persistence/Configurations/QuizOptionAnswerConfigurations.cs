using GeoLearn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoLearn.Infra.Persistence;

public class QuizOptionAnswerConfigurations : IEntityTypeConfiguration<QuizOptionAnswer>
{
    public void Configure(EntityTypeBuilder<QuizOptionAnswer> builder)
    {
        builder.HasKey(qoa => qoa.Id);

        builder.HasOne(qoa => qoa.QuizAnswer)  // Relacionamento explícito
            .WithMany(qa => qa.QuizOptionAnswers)
            .HasForeignKey(qoa => qoa.QuizAnswerId)
            .OnDelete(DeleteBehavior.Cascade);  // Comportamento ao deletar
        
        builder.HasOne(qoa => qoa.QuizOption)  // Relacionamento explícito
            .WithMany(qo => qo.QuizOptionAnswers)
            .HasForeignKey(qoa => qoa.QuizOptionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}