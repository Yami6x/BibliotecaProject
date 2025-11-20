using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEmpleados_RolesPresentacion
    {
        Task<List<Empleados_Roles>> Listar();
        Task<List<Empleados_Roles>> PorEmpleadoId(Empleados_Roles? entidad);
        Task<Empleados_Roles?> Guardar(Empleados_Roles? entidad);
        Task<Empleados_Roles?> Modificar(Empleados_Roles? entidad);
        Task<Empleados_Roles?> Borrar(Empleados_Roles? entidad);
    }
}