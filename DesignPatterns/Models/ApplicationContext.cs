using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    public class ApplicationContext:DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        { }
        public virtual DbSet<Person> Pesons { get; set; }
        public virtual DbSet<Category> Categories{ get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category configs
            modelBuilder.Entity<Category>()
                .HasKey(x => x.Id)
                .HasName("Id_Category");
            modelBuilder.Entity<Category>()
                .Property(x => x.Id).
                UseSqlServerIdentityColumn()
                .HasColumnName("Id");
            modelBuilder.Entity<Category>()
                .Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Category>()
                .Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Category>()
                .HasMany(x => x.Jobs)
                .WithOne(x => x.Category);

            //Person configs

            modelBuilder.Entity<Person>()
                .HasKey(x => x.Id)
                .HasName("Id_Person");
            modelBuilder.Entity<Person>()
                .Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Person>()
                .Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<Person>()
                .HasOne(x => x.Job)
                .WithMany(x => x.Persons)
                .HasForeignKey(x=>x.IdJob);

            //Job config

            modelBuilder.Entity<Job>()
                .HasKey(x => x.Id)
                .HasName("Id_Job");
            modelBuilder.Entity<Job>()
                .HasMany(x => x.Persons)
                .WithOne(x => x.Job);
            modelBuilder.Entity<Job>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Jobs)
                .HasForeignKey(x=>x.IdCategory);
        }


    }
}
