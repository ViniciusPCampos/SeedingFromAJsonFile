using System.Data.Entity.ModelConfiguration;
using TesteCarga.Model;

namespace TesteCarga.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(x => x.ID);
            Property(x => x.Name).IsRequired().HasMaxLength(80);
        }
    }
}
