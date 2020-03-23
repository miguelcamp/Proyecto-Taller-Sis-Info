﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoPequeInova.Data;

namespace ProyectoPequeInova.Data.Migrations
{
    [DbContext(typeof(PequeInovaDBContext))]
    [Migration("20200323172431_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoPequeInova.Data.Entity.AreaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("nombre")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("ProyectoPequeInova.Data.Entity.CursoEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaId");

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("ProyectoPequeInova.Data.Entity.CursoEntity", b =>
                {
                    b.HasOne("ProyectoPequeInova.Data.Entity.AreaEntity", "Area")
                        .WithMany("Cursos")
                        .HasForeignKey("AreaId");
                });
#pragma warning restore 612, 618
        }
    }
}
