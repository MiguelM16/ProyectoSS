using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SoftwareSolutions.Core.Domain;

namespace SoftwareSolutions.Core
{
    public partial class SoftwareSolutionsDbContext : DbContext
    {
        public SoftwareSolutionsDbContext()
        {
        }

        public SoftwareSolutionsDbContext(DbContextOptions<SoftwareSolutionsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Domicilios> Domicilios { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<EstadoDomicilio> EstadoDomicilio { get; set; }
        public virtual DbSet<EstadoReserva> EstadoReserva { get; set; }
        public virtual DbSet<Fidelizacion> Fidelizacion { get; set; }
        public virtual DbSet<IdentityuserString> IdentityuserString { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Reservas> Reservas { get; set; }
        public virtual DbSet<TipoProductos> TipoProductos { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("database=SoftwareSolutions;server=localhost;port=3306;user id=root;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClaimValue).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(127);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(127);

                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClaimValue).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(127);

                entity.Property(e => e.ProviderKey).HasMaxLength(127);

                entity.Property(e => e.ProviderDisplayName).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).HasMaxLength(127);

                entity.Property(e => e.RoleId).HasMaxLength(127);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PasswordHash).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SecurityStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId).HasMaxLength(127);

                entity.Property(e => e.LoginProvider).HasMaxLength(127);

                entity.Property(e => e.Name).HasMaxLength(127);

                entity.Property(e => e.Value).HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Domicilios>(entity =>
            {
                entity.HasKey(e => new { e.IdDomicilio, e.IdUsuario, e.IdVenta })
                    .HasName("PRIMARY");

                entity.ToTable("domicilios");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_Domicilios_Usuario1_idx");

                entity.HasIndex(e => e.IdVenta)
                    .HasName("fk_Domicilios_Venta1_idx");

                entity.Property(e => e.IdDomicilio)
                    .HasColumnName("Id_domicilio")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVenta)
                    .HasColumnName("Id_venta")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Domicilios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Domicilios_Usuario1");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<EstadoDomicilio>(entity =>
            {
                entity.HasKey(e => new { e.IdEstadoDomicilio, e.IdDomicilio, e.IdUsuario, e.IdVenta })
                    .HasName("PRIMARY");

                entity.ToTable("estado_domicilio");

                entity.HasIndex(e => new { e.IdDomicilio, e.IdUsuario, e.IdVenta })
                    .HasName("fk_Estado_domicilio_Domicilios1_idx");

                entity.Property(e => e.IdEstadoDomicilio)
                    .HasColumnName("Id_estado_domicilio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdDomicilio)
                    .HasColumnName("Id_domicilio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVenta)
                    .HasColumnName("Id_venta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EstadoDomicilio1)
                    .IsRequired()
                    .HasColumnName("Estado_domicilio")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.EstadoDomicilio)
                    .HasForeignKey(d => new { d.IdDomicilio, d.IdUsuario, d.IdVenta })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Estado_domicilio_Domicilios1");
            });

            modelBuilder.Entity<EstadoReserva>(entity =>
            {
                entity.HasKey(e => new { e.IdEstadoReserva, e.IdReserva, e.IdUsuario })
                    .HasName("PRIMARY");

                entity.ToTable("estado_reserva");

                entity.HasIndex(e => new { e.IdReserva, e.IdUsuario })
                    .HasName("fk_Estado_reserva_Reservas1_idx");

                entity.Property(e => e.IdEstadoReserva)
                    .HasColumnName("Id_estado_reserva")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdReserva)
                    .HasColumnName("Id_reserva")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EstadoReserva1)
                    .IsRequired()
                    .HasColumnName("Estado_reserva")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.EstadoReserva)
                    .HasForeignKey(d => new { d.IdReserva, d.IdUsuario })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Estado_reserva_Reservas1");
            });

            modelBuilder.Entity<Fidelizacion>(entity =>
            {
                entity.HasKey(e => new { e.IdFidelizacion, e.IdUsuario })
                    .HasName("PRIMARY");

                entity.ToTable("fidelizacion");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_Fidelizacion_Usuario1_idx");

                entity.Property(e => e.IdFidelizacion)
                    .HasColumnName("Id_fidelizacion")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CalidadServicio)
                    .HasColumnName("Calidad_servicio")
                    .HasColumnType("int(1)");

                entity.Property(e => e.NumVisitas)
                    .HasColumnName("Num_visitas")
                    .HasColumnType("int(4)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Fidelizacion)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Fidelizacion_Usuario1");
            });

            modelBuilder.Entity<IdentityuserString>(entity =>
            {
                entity.ToTable("identityuser<string>");

                entity.Property(e => e.Id).HasMaxLength(127);

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedEmail).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedUserName).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PasswordHash).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SecurityStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserName).HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.HasKey(e => new { e.IdMetodoPago, e.IdVenta, e.IdUsuario })
                    .HasName("PRIMARY");

                entity.ToTable("metodo_pago");

                entity.HasIndex(e => new { e.IdVenta, e.IdUsuario })
                    .HasName("fk_Metodo_pago_Venta1_idx");

                entity.Property(e => e.IdMetodoPago)
                    .HasColumnName("Id_metodo_pago")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdVenta)
                    .HasColumnName("Id_venta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MetodoPago1)
                    .IsRequired()
                    .HasColumnName("Metodo_pago")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.MetodoPagoNavigation)
                    .HasForeignKey(d => new { d.IdVenta, d.IdUsuario })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Metodo_pago_Venta1");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => new { e.IdProductos, e.IdVenta, e.IdUsuario, e.IdDomicilio })
                    .HasName("PRIMARY");

                entity.ToTable("productos");

                entity.HasIndex(e => new { e.IdVenta, e.IdUsuario })
                    .HasName("fk_Productos_Venta1_idx");

                entity.HasIndex(e => new { e.IdDomicilio, e.IdUsuario, e.IdVenta })
                    .HasName("fk_Productos_Domicilios1_idx");

                entity.Property(e => e.IdProductos)
                    .HasColumnName("Id_productos")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdVenta)
                    .HasColumnName("Id_venta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdDomicilio)
                    .HasColumnName("Id_domicilio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasColumnName("Nombre_producto")
                    .HasMaxLength(10);

                entity.Property(e => e.TipoProducto)
                    .HasColumnName("Tipo_producto")
                    .HasColumnType("int(2)");

                entity.Property(e => e.ValorUnitario)
                    .IsRequired()
                    .HasColumnName("Valor_unitario")
                    .HasMaxLength(9);

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => new { d.IdVenta, d.IdUsuario })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Productos_Venta1");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => new { d.IdDomicilio, d.IdUsuario, d.IdVenta })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Productos_Domicilios1");
            });

            modelBuilder.Entity<Reservas>(entity =>
            {
                entity.HasKey(e => new { e.IdReserva, e.IdUsuario })
                    .HasName("PRIMARY");

                entity.ToTable("reservas");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_Reservas_Usuario1_idx");

                entity.Property(e => e.IdReserva)
                    .HasColumnName("Id_reserva")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumMesa)
                    .IsRequired()
                    .HasColumnName("Num_mesa")
                    .HasMaxLength(2);

                entity.Property(e => e.NumPersonas)
                    .HasColumnName("Num_personas")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reservas_Usuario1");
            });

            modelBuilder.Entity<TipoProductos>(entity =>
            {
                entity.HasKey(e => new { e.IdTipoProducto, e.IdProductos })
                    .HasName("PRIMARY");

                entity.ToTable("tipo_productos");

                entity.HasIndex(e => e.IdProductos)
                    .HasName("fk_Tipo_productos_Productos1_idx");

                entity.Property(e => e.IdTipoProducto)
                    .HasColumnName("Id_tipo_producto")
                    .HasColumnType("int(2)");

                entity.Property(e => e.IdProductos)
                    .HasColumnName("Id_productos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreTipoProducto)
                    .IsRequired()
                    .HasColumnName("Nombre_tipo_producto")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.AspnetusersId)
                    .HasName("Aspnetusers_Id");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AspnetusersId)
                    .HasColumnName("Aspnetusers_Id")
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("Fecha_nacimiento")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("Primer_apellido")
                    .HasMaxLength(15);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasColumnName("Primer_nombre")
                    .HasMaxLength(10);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("Segundo_apellido")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("Segundo_nombre")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Aspnetusers)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.AspnetusersId)
                    .HasConstraintName("usuario_ibfk_1");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => new { e.IdVenta, e.IdUsuario })
                    .HasName("PRIMARY");

                entity.ToTable("venta");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_Venta_Usuario1_idx");

                entity.Property(e => e.IdVenta)
                    .HasColumnName("Id_venta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("int(2)");

                entity.Property(e => e.MetodoPago)
                    .IsRequired()
                    .HasColumnName("Metodo_pago")
                    .HasMaxLength(10);

                entity.Property(e => e.ValorVenta)
                    .IsRequired()
                    .HasColumnName("Valor_venta")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Venta_Usuario1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
