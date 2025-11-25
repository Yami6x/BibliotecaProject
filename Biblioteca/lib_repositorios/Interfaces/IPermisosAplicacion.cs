using lib_dominio.Entidades;
using System.Collections.Generic;

namespace lib_repositorios.Interfaces
{
    public interface IPermisosAplicacion
    {
        void Configurar(string StringConexion);
        List<Permisos> Listar();
        List<Permisos> PorNombre(Permisos? entidad);
        Permisos? Guardar(Permisos? entidad);
        Permisos? Modificar(Permisos? entidad);
        Permisos? Borrar(Permisos? entidad);
    }
}
