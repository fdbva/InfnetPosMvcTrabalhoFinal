using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.EntitiesConfiguration
{
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}