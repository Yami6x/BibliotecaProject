using lib_dominio.Entidades;


namespace lib_presentaciones.Interfaces
{
    public interface IUsuariosPresentacion
    {
        Task<Usuarios?> ValidarUsuario(Usuarios? entidad);
        Task<Dictionary<string, object>> Login(Usuarios? entidad);
        Task<List<Usuarios>> Listar();
        Task<List<Usuarios>> PorTipoUsuario(Usuarios? entidad);
        Task<Usuarios?> Guardar(Usuarios? entidad);
        Task<Usuarios?> Modificar(Usuarios? entidad);
        Task<Usuarios?> Borrar(Usuarios? entidad);
    }
}