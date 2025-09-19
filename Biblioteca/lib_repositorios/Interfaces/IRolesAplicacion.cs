using lib_dominio.Entidades;

public interface IRolesAplicacion
{
    void Configurar(string StringConexion);
    List<Roles> Listar();
    List<Roles> Buscar(Roles? entidad);
    Roles? Guardar(Roles? entidad);
    Roles? Modificar(Roles? entidad);
    Roles? Borrar(Roles? entidad);
}
