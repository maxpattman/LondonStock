using LondonStock.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Persistance.Configurations.Entities
{
    public class StockTypeConfiguration : IEntityTypeConfiguration<StockType>
    {
        public void Configure(EntityTypeBuilder<StockType> builder)
        {
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Ticker).IsRequired();
            builder.Property(t => t.Price).IsRequired();
        }
    }
}
