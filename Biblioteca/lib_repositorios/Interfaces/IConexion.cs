using Azure;
using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
    
        DbSet<Autores>? Autores { get; set; }
        DbSet<Auditorias>? Auditorias { get; set; }
        DbSet<Categorias>? Categorias { get; set; }
        DbSet<Idiomas>? Idiomas { get; set; }
        DbSet<Libros>? Libros { get; set; }
        DbSet<Miembros>? Miembros { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Empleados_Roles>? Empleados_Roles { get; set; }
        DbSet<Prestamos>? Prestamos { get; set; }
        DbSet<Reservas>? Reservas { get; set; }
        DbSet<Multas>? Multas { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Consumos>? Consumos { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Permisos>? Permisos { get; set; }
        DbSet<RolesPermisos>? RolesPermisos { get; set; }


      
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}