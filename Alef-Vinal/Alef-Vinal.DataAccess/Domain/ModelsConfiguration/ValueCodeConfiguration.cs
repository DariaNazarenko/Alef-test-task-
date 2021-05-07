using Alef_Vinal.DataAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alef_Vinal.DataAccess.Domain.ModelsConfiguration
{
    class ValueCodeConfiguration : IEntityTypeConfiguration<ValueCode>
    {
        public void Configure(EntityTypeBuilder<ValueCode> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Code).IsRequired();
            builder.Property(c => c.Value).IsRequired();
        }
    }
}
