using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ReservasAplicacion : IReservasAplicacion
    {
        private IConexion? IConexion = null;

        public ReservasAplicacion(IConexion iConexion) => this.IConexion = iConexion;

        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Reservas? Guardar(Reservas? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            this.IConexion!.Reservas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Reservas? Modificar(Reservas? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Entry(entidad).State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Reservas? Borrar(Reservas? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Reservas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Reservas> Listar() => this.IConexion!.Reservas!.Take(20).ToList();

        public List<Reservas> PorIdLibro(Reservas? entidad)
        {
            if (entidad!.IdLibro == 0)
            {
                return this.IConexion!.Reservas!.ToList();
            }

            return this.IConexion!.Reservas!
                .Where(x => x.IdLibro == entidad!.IdLibro)
                .ToList();
        }
    }
}
