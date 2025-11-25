using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ConsumosAplicacion : IConsumosAplicacion
    {
        private IConexion? IConexion = null;

        public ConsumosAplicacion(IConexion iConexion) => this.IConexion = iConexion;

        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Consumos? Guardar(Consumos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            this.IConexion!.Consumos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Consumos? Modificar(Consumos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Entry(entidad).State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Consumos? Borrar(Consumos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Consumos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Consumos> Listar() => this.IConexion!.Consumos!.Take(20).ToList();

        public List<Consumos> PorIdProducto(Consumos? entidad)
        {
            if (entidad!.IdProducto == 0)
            {
                return this.IConexion!.Consumos!.ToList();
            }

            return this.IConexion!.Consumos!
                .Where(x => x.IdProducto == entidad!.IdProducto)
                .ToList();
        }
    }
}
