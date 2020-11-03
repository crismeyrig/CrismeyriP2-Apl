﻿// <auto-generated />
using System;
using CrismeyriP2_Apl.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrismeyriP2_Apl.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20201103002624_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("CrismeyriP2_Apl.Entidades.Proyectos", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("TiempoTotal")
                        .HasColumnType("REAL");

                    b.HasKey("ProyectoId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("CrismeyriP2_Apl.Entidades.ProyectosDetalle", b =>
                {
                    b.Property<int>("ProyectosDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Requerimiento")
                        .HasColumnType("TEXT");

                    b.Property<int>("TareaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Tiempo")
                        .HasColumnType("REAL");

                    b.HasKey("ProyectosDetalleId");

                    b.HasIndex("ProyectoId");

                    b.HasIndex("TareaId");

                    b.ToTable("ProyectosDetalle");
                });

            modelBuilder.Entity("CrismeyriP2_Apl.Entidades.Tareas", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoTarea")
                        .HasColumnType("TEXT");

                    b.HasKey("TareaId");

                    b.ToTable("Tareas");

                    b.HasData(
                        new
                        {
                            TareaId = 1,
                            TipoTarea = "Analisis"
                        },
                        new
                        {
                            TareaId = 2,
                            TipoTarea = "Diseño"
                        },
                        new
                        {
                            TareaId = 3,
                            TipoTarea = "Programación"
                        },
                        new
                        {
                            TareaId = 4,
                            TipoTarea = "Prueba"
                        });
                });

            modelBuilder.Entity("CrismeyriP2_Apl.Entidades.ProyectosDetalle", b =>
                {
                    b.HasOne("CrismeyriP2_Apl.Entidades.Proyectos", null)
                        .WithMany("Detalle")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrismeyriP2_Apl.Entidades.Tareas", "tareas")
                        .WithMany()
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}