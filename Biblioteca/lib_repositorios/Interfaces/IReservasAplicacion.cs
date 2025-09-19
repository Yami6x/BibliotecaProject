using lib_dominio.Entidades;

public interface IReservasAplicacion
{
    void Configurar(string StringConexion);
    List<Reservas> Listar();
    List<Reservas> Buscar(Reservas? entidad);
    Reservas? Guardar(Reservas? entidad);
    Reservas? Modificar(Reservas? entidad);
    Reservas? Borrar(Reservas? entidad);
}
