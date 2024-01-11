//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Emit;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Configurations
//{
//    internal class InstrumentConfiguration : IEntityTypeConfiguration<Instrument>
//    {
//        public void Configure(EntityTypeBuilder<Instrument> builder)
//        {
//            builder.HasKey(x => x.Id);

//            builder.HasMany(t => t.Transactions);

//        }
//    }
//}
