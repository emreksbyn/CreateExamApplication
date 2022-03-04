using CreateExam.Core.Entities.Concrete;
using CreateExam.Infrastructure.Configuration.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreateExam.Infrastructure.Configuration.Concrete
{
    public class ArticleMap : BaseMap<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.ArticleId);
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Content).IsRequired(true);

            builder.HasMany(x => x.Questions)
                    .WithOne(x => x.Article)
                    .HasForeignKey(x => x.ArticleId)
                    .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}