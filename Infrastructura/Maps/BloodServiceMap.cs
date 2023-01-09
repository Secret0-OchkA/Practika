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
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructura.Maps
{
    public class BloodServiceMap : IEntityTypeConfiguration<BloodService>
    {
        public void Configure(EntityTypeBuilder<BloodService> builder)
        {
            builder.HasNoKey();
            builder.Property(c => c.status)
                .HasConversion(new EnumToStringConverter<CompliteStatus>());
            builder.Property(c => c.analyzer)
                .HasConversion(new EnumToStringConverter<analyzerType>());
        }
    }
}
