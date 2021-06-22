using DATA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Context
{
   public class ERPContext : DbContext
    {
        public ERPContext(DbContextOptions<ERPContext> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Car> Cars { get; set; }  
        public virtual DbSet<AccessCard> AccessCards { get; set; }
        public virtual DbSet<HistoryTransit> HistoryTransits { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 1, Name = "SkyWay" });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 1, Name = "ccdVideoCamera",BrandId =1  });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 1, Name = "Mohamed", Position = "Dev",Age=21});           
            modelBuilder.Entity<Car>().HasData(new Car { Id = 1, PlateNumber = "أدد", ModelId = 1, OwnerId = 1 });



            modelBuilder.Entity<Employee>().HasKey(s => s.EmployeeId);
            
            modelBuilder.Entity<Car>().HasKey(s => s.Id);
            modelBuilder.Entity<Car>().HasOne(s => s.Owner).WithMany().HasForeignKey(s => s.OwnerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Car>().HasOne(s => s.ModelBrand).WithMany().HasForeignKey(s => s.ModelId).OnDelete(DeleteBehavior.NoAction);
           
            modelBuilder.Entity<Model>().HasKey(s => s.Id);
            modelBuilder.Entity<Model>().HasOne(s => s.Brand).WithMany().HasForeignKey(s => s.BrandId).OnDelete(DeleteBehavior.NoAction);
           
            modelBuilder.Entity<Brand>().HasKey(s => s.Id);
            modelBuilder.Entity<Brand>().HasMany(s => s.BrandModels).WithOne(s => s.Brand).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccessCard>().HasKey(s => s.Id);
            modelBuilder.Entity<AccessCard>().HasOne(s => s.Car).WithMany().HasForeignKey(s => s.CarId).OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);

        }

    }
    }
