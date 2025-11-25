using lib_dominio.Entidades;


namespace lib_presentaciones.Interfaces
{
    public interface IIdiomasPresentacion
    {
        Task<List<Idiomas>> Listar();
        Task<List<Idiomas>> PorCodigo(Idiomas? entidad);
        Task<Idiomas?> Guardar(Idiomas? entidad);
        Task<Idiomas?> Modificar(Idiomas? entidad);
        Task<Idiomas?> Borrar(Idiomas? entidad);
    }
}