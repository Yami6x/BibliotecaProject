using Azure;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Autores>? Autores { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Idiomas>? Idiomas { get; set; }
        public DbSet<Libros>? Libros { get; set; }
        public DbSet<Miembros>? Miembros { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Empleados_Roles>? Empleados_Roles { get; set; }
        public DbSet<Prestamos>? Prestamos { get; set; }
        public DbSet<Reservas>? Reservas { get; set; }
        public DbSet<Multas>? Multas { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Consumos>? Consumos { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Permisos>? Permisos { get; set; }
    }
}
