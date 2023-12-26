using MambaAPIclasstask.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MambaAPIclasstask.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(20);
            builder.Property(x => x.ImageUrl).IsRequired();


           

        }
    }
}
