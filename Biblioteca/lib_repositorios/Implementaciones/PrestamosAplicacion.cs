using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PrestamosAplicacion : IPrestamosAplicacion
    {
        private IConexion? IConexion = null;

        public PrestamosAplicacion(IConexion iConexion) => this.IConexion = iConexion;

        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Prestamos? Guardar(Prestamos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            this.IConexion!.Prestamos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Prestamos? Modificar(Prestamos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Entry(entidad).State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Prestamos? Borrar(Prestamos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Prestamos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Prestamos> Listar() => this.IConexion!.Prestamos!.Take(20).ToList();

        public List<Prestamos> Buscar(Prestamos? entidad) =>
            this.IConexion!.Prestamos!
            .Where(x => x.IdLibro == entidad!.IdLibro
                     || x.IdMiembro == entidad!.IdMiembro)
            .ToList();
    }
}
