using System;
using System.Collections.Generic;
using Api.Crud.Hcc.Models.ApiCrudModels;
using Microsoft.EntityFrameworkCore;

namespace Api.Crud.Hcc.Models.Context;

public partial class ApiCrudContext : DbContext
{
    public ApiCrudContext(DbContextOptions<ApiCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbHccAlmacen> TbHccAlmacen { get; set; }

    public virtual DbSet<TbHccCatEstatusOrden> TbHccCatEstatusOrden { get; set; }

    public virtual DbSet<TbHccMesas> TbHccMesas { get; set; }

    public virtual DbSet<TbHccOrdenes> TbHccOrdenes { get; set; }

    public virtual DbSet<TbHccOrdenesDetalle> TbHccOrdenesDetalle { get; set; }

    public virtual DbSet<TbHccProductos> TbHccProductos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbHccAlmacen>(entity =>
        {
            entity.HasKey(e => e.AlmId).HasName("Pk_Tb_HccAlmacen_alm_id");

            entity.ToTable("Tb_HccAlmacen");

            entity.Property(e => e.AlmId).HasColumnName("alm_id");
            entity.Property(e => e.AlmCantidad).HasColumnName("alm_cantidad");
            entity.Property(e => e.AlmEstatus).HasColumnName("alm_estatus");
            entity.Property(e => e.AlmFechaActualizacion)
                .HasColumnType("date")
                .HasColumnName("alm_fecha_actualizacion");
        });

        modelBuilder.Entity<TbHccCatEstatusOrden>(entity =>
        {
            entity.HasKey(e => e.CatordId).HasName("Pk_Tb_HccCatEstatusOrden_catord_id");

            entity.ToTable("Tb_HccCatEstatusOrden");

            entity.Property(e => e.CatordId)
                .ValueGeneratedNever()
                .HasColumnName("catord_id");
            entity.Property(e => e.CatordEstatus).HasColumnName("catord_estatus");
            entity.Property(e => e.CatordNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("catord_nombre");
        });

        modelBuilder.Entity<TbHccMesas>(entity =>
        {
            entity.HasKey(e => e.MesId).HasName("Pk_Tb_HccMesas_mes_id");

            entity.ToTable("Tb_HccMesas");

            entity.Property(e => e.MesId)
                .ValueGeneratedNever()
                .HasColumnName("mes_id");
            entity.Property(e => e.MesDisponible).HasColumnName("mes_disponible");
            entity.Property(e => e.MesEstatus).HasColumnName("mes_estatus");
            entity.Property(e => e.MesLugares).HasColumnName("mes_lugares");
        });

        modelBuilder.Entity<TbHccOrdenes>(entity =>
        {
            entity.HasKey(e => e.OrdId).HasName("Pk_Tb_HccOrdenes_ord_id");

            entity.ToTable("Tb_HccOrdenes");

            entity.Property(e => e.OrdId).HasColumnName("ord_id");
            entity.Property(e => e.CatordId).HasColumnName("catord_id");
            entity.Property(e => e.MesId).HasColumnName("mes_id");
            entity.Property(e => e.OrdEstatus).HasColumnName("ord_estatus");
            entity.Property(e => e.OrdFechaInicio)
                .HasColumnType("date")
                .HasColumnName("ord_fecha_inicio");

            entity.HasOne(d => d.Catord).WithMany(p => p.TbHccOrdenes)
                .HasForeignKey(d => d.CatordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Tb_HccOrdenes_Tb_HccCatEstatusOrden");

            entity.HasOne(d => d.Mes).WithMany(p => p.TbHccOrdenes)
                .HasForeignKey(d => d.MesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Tb_HccOrdenes_Tb_HccMesas");
        });

        modelBuilder.Entity<TbHccOrdenesDetalle>(entity =>
        {
            entity.HasKey(e => e.OrddetId).HasName("Pk_Tb_HccOrdenesDetalle_orddet_id");

            entity.ToTable("Tb_HccOrdenesDetalle");

            entity.Property(e => e.OrddetId).HasColumnName("orddet_id");
            entity.Property(e => e.OrdId).HasColumnName("ord_id");
            entity.Property(e => e.OrddetCantidad)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("orddet_cantidad");
            entity.Property(e => e.OrddetEstatus).HasColumnName("orddet_estatus");
            entity.Property(e => e.ProId).HasColumnName("pro_id");

            entity.HasOne(d => d.Ord).WithMany(p => p.TbHccOrdenesDetalle)
                .HasForeignKey(d => d.OrdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Tb_HccOrdenesDetalle_Tb_HccOrdenes");

            entity.HasOne(d => d.Pro).WithMany(p => p.TbHccOrdenesDetalle)
                .HasForeignKey(d => d.ProId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Tb_HccOrdenesDetalle_Tb_HccProductos");
        });

        modelBuilder.Entity<TbHccProductos>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("Pk_Tb_HccProductos_pro_id");

            entity.ToTable("Tb_HccProductos");

            entity.Property(e => e.ProId).HasColumnName("pro_id");
            entity.Property(e => e.AlmId).HasColumnName("alm_id");
            entity.Property(e => e.ProDescripcion)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("pro_descripcion");
            entity.Property(e => e.ProEstatus).HasColumnName("pro_estatus");
            entity.Property(e => e.ProNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pro_nombre");
            entity.Property(e => e.ProPrecio)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("pro_precio");

            entity.HasOne(d => d.Alm).WithMany(p => p.TbHccProductos)
                .HasForeignKey(d => d.AlmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Tb_HccProductos_Tb_HccAlmacen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
