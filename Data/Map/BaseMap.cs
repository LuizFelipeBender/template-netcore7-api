using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity;

namespace Data.Map
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : Template
    {
        private readonly string _tableName;

        public BaseMap(string tableName)
        {
            _tableName= tableName;
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (!string.IsNullOrEmpty(_tableName)) builder.ToTable(_tableName);

            builder.HasKey(x => x.Id);
            builder.Property(x =>x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
        }
    }
}