using lib_dominio.Entidades;

public interface IRolesAplicacion
{
    void Configurar(string StringConexion);
    List<Roles> Listar();
    List<Roles> PorNombre(Roles? entidad);
    Roles? Guardar(Roles? entidad);
    Roles? Modificar(Roles? entidad);
    Roles? Borrar(Roles? entidad);
}
