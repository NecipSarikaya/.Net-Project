using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Configuration
{
    public class UniversityDepartmentConfiguration : IEntityTypeConfiguration<UniversityDepartment>
    {
        public void Configure(EntityTypeBuilder<UniversityDepartment> builder)
        {
            builder.HasKey( l => new {l .DepartmentId,l.UniversityId});
        }

    }
}