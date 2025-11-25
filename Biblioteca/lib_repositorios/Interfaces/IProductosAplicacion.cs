using lib_dominio.Entidades;

public interface IProductosAplicacion
{
    void Configurar(string StringConexion);
    List<Productos> Listar();
    List<Productos> PorNombre(Productos? entidad);
    Productos? Guardar(Productos? entidad);
    Productos? Modificar(Productos? entidad);
    Productos? Borrar(Productos? entidad);
}
