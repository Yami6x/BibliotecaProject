using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class MiembrosAplicacion : IMiembrosAplicacion
    {
        private IConexion? IConexion = null;

        public MiembrosAplicacion(IConexion iConexion) => this.IConexion = iConexion;

        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Miembros? Guardar(Miembros? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            this.IConexion!.Miembros!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Miembros? Modificar(Miembros? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Entry(entidad).State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Miembros? Borrar(Miembros? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Miembros!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Miembros> Listar() => this.IConexion!.Miembros!.Take(20).ToList();

        public List<Miembros> Buscar(Miembros? entidad) =>
            this.IConexion!.Miembros!
            .Where(x => x.Nombre!.Contains(entidad!.Nombre!)
                     || x.Apellido!.Contains(entidad!.Apellido!))
            .ToList();
    }
}
