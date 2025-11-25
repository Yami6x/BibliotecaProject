using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IRolesPermisosAplicacion
    {
        void Configurar(string StringConexion);
        List<RolesPermisos> Listar();
        List<RolesPermisos> PorRolID(RolesPermisos? entidad);
        RolesPermisos? Guardar(RolesPermisos? entidad);
        RolesPermisos? Modificar(RolesPermisos? entidad);
        RolesPermisos? Borrar(RolesPermisos? entidad);
    }
}