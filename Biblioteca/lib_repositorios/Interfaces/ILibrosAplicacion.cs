using lib_dominio.Entidades;

public interface ILibrosAplicacion
{
    void Configurar(string StringConexion);
    List<Libros> Listar();
    List<Libros> Buscar(Libros? entidad);
    Libros? Guardar(Libros? entidad);
    Libros? Modificar(Libros? entidad);
    Libros? Borrar(Libros? entidad);
}

