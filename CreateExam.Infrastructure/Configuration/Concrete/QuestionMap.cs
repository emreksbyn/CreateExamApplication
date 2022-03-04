using CreateExam.Core.Entities.Concrete;
using CreateExam.Infrastructure.Configuration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreateExam.Infrastructure.Configuration.Concrete
{
    public class QuestionMap : BaseMap<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.QuesitonId);
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.AOption).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.BOption).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.COption).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.DOption).HasMaxLength(100).IsRequired(true);
            //builder.Property(x => x.Answer).IsRequired(true);
            builder.Property(x => x.CorrectAnswer).IsRequired(true);

            builder.HasOne(x => x.Article)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.ArticleId);

            //builder.HasOne(x => x.Exam)
            //    .WithMany(x => x.Questions)
            //    .HasForeignKey(x => x.ExamId);

            base.Configure(builder);
        }
    }
}