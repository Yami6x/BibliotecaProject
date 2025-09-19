using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class LibrosAplicacion : ILibrosAplicacion
    {
        private IConexion? IConexion = null;

        public LibrosAplicacion(IConexion iConexion) => this.IConexion = iConexion;

        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Libros? Guardar(Libros? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            this.IConexion!.Libros!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Libros? Modificar(Libros? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Entry(entidad).State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Libros? Borrar(Libros? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Libros!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Libros> Listar() => this.IConexion!.Libros!.Take(20).ToList();

        public List<Libros> Buscar(Libros? entidad) =>
            this.IConexion!.Libros!
            .Where(x => x.Titulo!.Contains(entidad!.Titulo!))
            .ToList();
    }
}
