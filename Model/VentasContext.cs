using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Api_Ventas.Model
{
    public partial class VentasContext : DbContext
    {
        public VentasContext()
        {
        }

        public VentasContext(DbContextOptions<VentasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Caja> Cajas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleTicket> DetalleTickets { get; set; }
        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Sucursal> Sucursals { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;database=Ventas;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Caja>(entity =>
            {
                entity.HasKey(e => e.IdCaja)
                    .HasName("PK_ID_caj");

                entity.ToTable("Caja");

                entity.Property(e => e.IdCaja).HasColumnName("id_caja");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("estatus");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.Property(e => e.NombreCaja)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_caja");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Cajas)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_caja_sucu");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("pk_id_cli");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.ApellidoM)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("apellidoM");

                entity.Property(e => e.ApellidoP)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("apellidoP");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.FechayhoraAlta)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fechayhora_alta");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("segundo_nombre");
            });

            modelBuilder.Entity<DetalleTicket>(entity =>
            {
                entity.HasKey(e => e.IdDetalleTicket)
                    .HasName("PK__Detalle___E0FF4B0E1B9EE50F");

                entity.ToTable("Detalle_ticket");

                entity.Property(e => e.IdDetalleTicket).HasColumnName("id_detalle_ticket");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdTicket).HasColumnName("id_ticket");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleTickets)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_det_tick_pro");

                entity.HasOne(d => d.IdTicketNavigation)
                    .WithMany(p => p.DetalleTickets)
                    .HasForeignKey(d => d.IdTicket)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_det_tic_ticket");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PK_ID_INV");

                entity.ToTable("Inventario");

                entity.Property(e => e.IdInventario).HasColumnName("ID_INVENTARIO");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");

                entity.Property(e => e.PzDisponibles).HasColumnName("PZ_DISPONIBLES");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_INV_PRODU");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_INV_SUCU");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("pk_id_pro");

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.CostoPz).HasColumnName("costo_pz");

                entity.Property(e => e.CostoPzMayoreo).HasColumnName("costo_pz_mayoreo");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("estatus");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_producto");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK_ID_SUC");

                entity.ToTable("Sucursal");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("estatus");

                entity.Property(e => e.NombreSucursal)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nombre_sucursal");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket)
                    .HasName("pk_id_tick");

                entity.ToTable("Ticket");

                entity.Property(e => e.IdTicket).HasColumnName("id_ticket");

                entity.Property(e => e.Fechayhora)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fechayhora");

                entity.Property(e => e.IdCaja).HasColumnName("id_caja");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.MontoTotal).HasColumnName("monto_total");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tick_caja");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ticket_clie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
