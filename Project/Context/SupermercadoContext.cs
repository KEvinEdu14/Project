using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace Project.Context;

public partial class SupermercadoContext : DbContext
{
    public SupermercadoContext()
    {
    }

    public SupermercadoContext(DbContextOptions<SupermercadoContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ATHENEA\\SQLEXPRESS;Initial Catalog=Supermercado;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<ProyectoFinal.Models.Cliente> Cliente { get; set; } = default!;

    public DbSet<ProyectoFinal.Models.Compra> Compra { get; set; } = default!;

    public DbSet<ProyectoFinal.Models.DetalleCompra> DetalleCompra { get; set; } = default!;

    public DbSet<ProyectoFinal.Models.DetalleVenta> DetalleVenta { get; set; } = default!;

    public DbSet<ProyectoFinal.Models.Empleado> Empleado { get; set; } = default!;

    public DbSet<ProyectoFinal.Models.Producto> Producto { get; set; } = default!;

    public DbSet<ProyectoFinal.Models.Proveedor> Proveedor { get; set; } = default!;

    public DbSet<ProyectoFinal.Models.Venta> Venta { get; set; } = default!;
}
