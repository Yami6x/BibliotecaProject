using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class MultasAplicacion : IMultasAplicacion
    {
        private IConexion? IConexion = null;

        public MultasAplicacion(IConexion iConexion) => this.IConexion = iConexion;

        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Multas? Guardar(Multas? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            this.IConexion!.Multas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Multas? Modificar(Multas? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Entry(entidad).State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Multas? Borrar(Multas? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Multas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Multas> Listar() => this.IConexion!.Multas!.Take(20).ToList();

        public List<Multas> PorIdPrestamo(Multas? entidad)
        {
            if (string.IsNullOrEmpty(entidad!.Estado))
            {
                return this.IConexion!.Multas!.ToList();
            }

            return this.IConexion!.Multas!
                .Where(x => x.Estado!.Contains(entidad!.Estado!))
                .ToList();
        }
    }
}
