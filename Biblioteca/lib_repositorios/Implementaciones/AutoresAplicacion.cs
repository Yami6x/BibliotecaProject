using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class AutoresAplicacion : IAutoresAplicacion
    {
        private IConexion? IConexion = null;

        public AutoresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Autores? Guardar(Autores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Autores!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Autores? Modificar(Autores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Autores? Borrar(Autores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Autores!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Autores> Listar()
        {
            return this.IConexion!.Autores!.Take(50).ToList();
        }

        public List<Autores> PorNombre(Autores? entidad)
        {
            return this.IConexion!.Autores!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }
    }
}
