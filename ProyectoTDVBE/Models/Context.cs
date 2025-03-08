using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoTDVBE.Models;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<DetalleTrabajador> DetalleTrabajadors { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Trabajador> Trabajadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Idarea);

            entity.ToTable("Area");

            entity.Property(e => e.Idarea).HasColumnName("idarea");
            entity.Property(e => e.Nombrearea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombrearea");
        });

        modelBuilder.Entity<DetalleTrabajador>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Detalle_Trabajador");

            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("area");
            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("codigo");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DNI");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.Idarea).HasColumnName("idarea");
            entity.Property(e => e.Idtrabajador).HasColumnName("idtrabajador");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("puesto");
            entity.Property(e => e.Sueldo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sueldo");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin);

            entity.ToTable("Login");

            entity.Property(e => e.IdLogin).HasColumnName("idLogin");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.Idpuesto);

            entity.ToTable("puesto");

            entity.Property(e => e.Idpuesto).HasColumnName("idpuesto");
            entity.Property(e => e.Idarea).HasColumnName("idarea");
            entity.Property(e => e.Nombrepuesto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombrepuesto");

            entity.HasOne(d => d.IdareaNavigation).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.Idarea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_puesto_Area");
        });

        modelBuilder.Entity<Trabajador>(entity =>
        {
            entity.HasKey(e => e.Idtrabajador);

            entity.ToTable("Trabajador");

            entity.Property(e => e.Idtrabajador).HasColumnName("idtrabajador");
            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("codigo");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DNI");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Puesto).HasColumnName("puesto");
            entity.Property(e => e.Sueldo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sueldo");

            entity.HasOne(d => d.PuestoNavigation).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.Puesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_puesto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
