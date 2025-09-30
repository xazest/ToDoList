using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain;

namespace TodoList.Persistence.EntityTypeConfigurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles");
            builder.HasKey(up => up.UserId);
            builder.HasIndex(up => up.Id).IsUnique();//индекс или property? уникальный = ссылка на профиль
            builder.Property(up => up.Nickname).IsRequired().HasMaxLength(24);
        }
    }
}
