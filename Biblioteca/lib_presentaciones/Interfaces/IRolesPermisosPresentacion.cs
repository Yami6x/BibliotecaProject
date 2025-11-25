using lib_dominio.Entidades;


namespace lib_presentaciones.Interfaces
{
    public interface IRolesPermisosPresentacion
    {
        Task<List<RolesPermisos>> Listar();
        Task<List<RolesPermisos>> PorRolID(RolesPermisos? entidad);
        Task<RolesPermisos?> Guardar(RolesPermisos? entidad);
        Task<RolesPermisos?> Modificar(RolesPermisos? entidad);
        Task<RolesPermisos?> Borrar(RolesPermisos? entidad);
    }
}