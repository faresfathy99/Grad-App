using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MizanGraduationProject.Data.Models.OTP;

namespace MizanGraduationProject.Data.Models.ModelsConfigurations
{
    public class VerifyOTPConfigurations : IEntityTypeConfiguration<VerifyOTP>
    {
        public void Configure(EntityTypeBuilder<VerifyOTP> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.UserID).IsRequired();
            builder.HasIndex(e => e.UserID).IsUnique();
            builder.Property(e => e.Code).IsRequired();
            builder.HasOne(e => e.User).WithMany(e => e.VerifyOTPs).HasForeignKey(e => e.UserID);
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("getdate()");
            builder.Property(e => e.ExpiredAt).HasDefaultValueSql("DATEADD(minute, 10, GETDATE())");
        }
    }
}
