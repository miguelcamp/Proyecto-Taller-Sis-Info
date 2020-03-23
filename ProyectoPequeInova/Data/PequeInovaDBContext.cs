using AutoMapper;
using ProyectoPequeInova.Models;
using ProyectoPequeInova.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPequeInova.Data
{
    public class PequeInovaDBContext : DbContext
    {
        public PequeInovaDBContext(DbContextOptions<PequeInovaDBContext> wind)
             : base(wind)

        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AreaEntity>().ToTable("Areas");
            modelBuilder.Entity<AreaEntity>().HasMany(a => a.Cursos).WithOne(b => b.Area);
            modelBuilder.Entity<AreaEntity>().Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CursoEntity>().ToTable("Cursos");
            modelBuilder.Entity<CursoEntity>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CursoEntity>().HasOne(b => b.Area).WithMany(a => a.Cursos);
        }

        public DbSet<AreaEntity> Areas { get; set; }
        public DbSet<CursoEntity> Cursos { get; set; }
    }
}
