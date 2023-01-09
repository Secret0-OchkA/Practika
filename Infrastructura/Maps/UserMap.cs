using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Domain;
using Newtonsoft.Json;

namespace Infrastructura.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.services).HasConversion(
            p => JsonConvert.SerializeObject(p, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            p => JsonConvert.DeserializeObject<List<int>>(p, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
            );
        }
    }
}
