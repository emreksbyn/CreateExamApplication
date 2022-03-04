using CreateExam.Core.Entities.Concrete;
using CreateExam.Infrastructure.Configuration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreateExam.Infrastructure.Configuration.Concrete
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.NormalizedUserName).IsRequired(false);

            //builder.HasOne(x => x.Exam)
            //    .WithMany(x => x.AppUsers)
            //    .HasForeignKey(x => x.ExamId);

            base.Configure(builder);
        }
    }
}