using lib_dominio.Entidades;

public interface IEmpleadosAplicacion
{
    void Configurar(string StringConexion);
    List<Empleados> Listar();
    List<Empleados> Buscar(Empleados? entidad);
    Empleados? Guardar(Empleados? entidad);
    Empleados? Modificar(Empleados? entidad);
    Empleados? Borrar(Empleados? entidad);
}
