using Microsoft.EntityFrameworkCore;
using UnitOfWorkAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkAPI.DataAccess.Context
{
    public class UowDbContext : DbContext
    {
        public UowDbContext(DbContextOptions<UowDbContext> options) : base(options) { }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(ab => ab.Brand).WithMany().HasForeignKey(ab => ab.BrandId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
