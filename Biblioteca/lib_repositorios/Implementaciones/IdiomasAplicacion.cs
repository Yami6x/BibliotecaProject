using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class IdiomasAplicacion : IIdiomasAplicacion
    {
        private IConexion? IConexion = null;

        public IdiomasAplicacion(IConexion iConexion) => this.IConexion = iConexion;

        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Idiomas? Guardar(Idiomas? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            this.IConexion!.Idiomas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Idiomas? Modificar(Idiomas? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Entry(entidad).State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Idiomas? Borrar(Idiomas? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Idiomas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Idiomas> Listar() => this.IConexion!.Idiomas!.Take(20).ToList();

        public List<Idiomas> Buscar(Idiomas? entidad) =>
            this.IConexion!.Idiomas!
            .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
            .ToList();
    }
}
