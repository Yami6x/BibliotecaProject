using lib_dominio.Entidades;

public interface IProveedoresAplicacion
{
    void Configurar(string StringConexion);
    List<Proveedores> Listar();
    List<Proveedores> Buscar(Proveedores? entidad);
    Proveedores? Guardar(Proveedores? entidad);
    Proveedores? Modificar(Proveedores? entidad);
    Proveedores? Borrar(Proveedores? entidad);
}
