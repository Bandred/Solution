using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DBContext : DbContext, IDBContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DBContext()
        {
        }

        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PropertyEntity> Properties { get; set; }
        public DbSet<PropertyImageEntity> PropertyImages { get; set; }
        public DbSet<PropertyTraceEntity> PropertyTraces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OwnerConfig.SetEntityBuilder(modelBuilder.Entity<OwnerEntity>());
            PropertyConfig.SetEntityBuilder(modelBuilder.Entity<PropertyEntity>());
            PropertyImageConfig.SetEntityBuilder(modelBuilder.Entity<PropertyImageEntity>());
            PropertyTraceConfig.SetEntityBuilder(modelBuilder.Entity<PropertyTraceEntity>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
