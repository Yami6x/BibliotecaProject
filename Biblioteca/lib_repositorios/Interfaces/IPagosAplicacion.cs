using lib_dominio.Entidades;

public interface IPagosAplicacion
{
    void Configurar(string StringConexion);
    List<Pagos> Listar();
    List<Pagos> Buscar(Pagos? entidad);
    Pagos? Guardar(Pagos? entidad);
    Pagos? Modificar(Pagos? entidad);
    Pagos? Borrar(Pagos? entidad);
}
