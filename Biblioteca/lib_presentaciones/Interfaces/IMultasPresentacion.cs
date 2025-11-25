using lib_dominio.Entidades;


namespace lib_presentaciones.Interfaces
{
    public interface IMultasPresentacion
    {
        Task<List<Multas>> Listar();
        Task<List<Multas>> PorIdPrestamo(Multas? entidad);
        Task<Multas?> Guardar(Multas? entidad);
        Task<Multas?> Modificar(Multas? entidad);
        Task<Multas?> Borrar(Multas? entidad);
    }
}