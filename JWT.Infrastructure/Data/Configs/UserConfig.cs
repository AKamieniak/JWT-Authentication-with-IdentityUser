using JWT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWT.Infrastructure.Data.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Ignore(i => i.AccessFailedCount);
            builder.Ignore(i => i.NormalizedUserName);
            builder.Ignore(i => i.NormalizedEmail);
            builder.Ignore(i => i.ConcurrencyStamp);
        }
    }
}
