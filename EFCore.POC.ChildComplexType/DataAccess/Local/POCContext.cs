using EFCore.POC.ChildComplexType.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.POC.ChildComplexType.DataAccess.Local
{
    public class POCContext : DbContext
    {
        public DbSet<RefundType> RefundType { get; set; }

        public DbSet<RefundUnit> RefundUnit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=POC.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefundUnit>()
               .Property(ru => ru.RefundUnitId)
               .ValueGeneratedNever();

            modelBuilder.Entity<RefundType>()
                .HasOne(rt => rt.RefundUnit)
                .WithMany()
                .HasForeignKey(rt => rt.RefundUnitId);

            modelBuilder.Entity<RefundType>()
                .Property(rt => rt.RefundTypeId)
                .ValueGeneratedNever();
        }
    }
}
