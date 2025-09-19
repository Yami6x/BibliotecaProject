using lib_dominio.Entidades;

public interface IPrestamosAplicacion
{
    void Configurar(string StringConexion);
    List<Prestamos> Listar();
    List<Prestamos> Buscar(Prestamos? entidad);
    Prestamos? Guardar(Prestamos? entidad);
    Prestamos? Modificar(Prestamos? entidad);
    Prestamos? Borrar(Prestamos? entidad);
}
