using Synergetic.Exercise.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Data.Maps
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(1000);
            Property(p => p.Description).HasMaxLength(4000);
        }
    }
}
