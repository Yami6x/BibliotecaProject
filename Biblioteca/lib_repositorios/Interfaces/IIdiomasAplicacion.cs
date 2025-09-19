using lib_dominio.Entidades;

public interface IIdiomasAplicacion
{
    void Configurar(string StringConexion);
    List<Idiomas> Listar();
    List<Idiomas> Buscar(Idiomas? entidad);
    Idiomas? Guardar(Idiomas? entidad);
    Idiomas? Modificar(Idiomas? entidad);
    Idiomas? Borrar(Idiomas? entidad);
}
