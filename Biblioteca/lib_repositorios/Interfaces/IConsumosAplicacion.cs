using lib_dominio.Entidades;

public interface IConsumosAplicacion
{
    void Configurar(string StringConexion);
    List<Consumos> Listar();
    List<Consumos> PorIdProducto(Consumos? entidad);
    Consumos? Guardar(Consumos? entidad);
    Consumos? Modificar(Consumos? entidad);
    Consumos? Borrar(Consumos? entidad);
}
