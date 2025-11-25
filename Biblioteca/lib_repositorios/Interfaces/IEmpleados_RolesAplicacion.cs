using lib_dominio.Entidades;

public interface IEmpleados_RolesAplicacion
{
    void Configurar(string StringConexion);
    List<Empleados_Roles> Listar();
    List<Empleados_Roles> PorEmpleadoId(Empleados_Roles? entidad);
    Empleados_Roles? Guardar(Empleados_Roles? entidad);
    Empleados_Roles? Modificar(Empleados_Roles? entidad);
    Empleados_Roles? Borrar(Empleados_Roles? entidad);
}
