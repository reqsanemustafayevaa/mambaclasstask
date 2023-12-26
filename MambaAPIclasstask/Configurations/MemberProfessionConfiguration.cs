using MambaAPIclasstask.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MambaAPIclasstask.Configurations
{
    public class MemberProfessionConfiguration : IEntityTypeConfiguration<Memberprofession>
    {
        public void Configure(EntityTypeBuilder<Memberprofession> builder)
        {
            builder.HasOne(x => x.Member).WithMany(x => x.Memberprofessions);
            builder.HasOne(x => x.profession).WithMany(x => x.Memberprofessions);
        }
    }
}
