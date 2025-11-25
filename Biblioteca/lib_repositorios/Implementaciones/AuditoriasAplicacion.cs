using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class AuditoriasAplicacion : IAuditoriasAplicacion
    {
        private IConexion? IConexion = null;

        public AuditoriasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

       
        public Auditorias? Guardar(Auditorias? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            if (entidad.AuditoriaID != 0) throw new Exception("lbYaSeGuardo");

            this.IConexion!.Auditorias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        
        public List<Auditorias> Listar()
        {
            return this.IConexion!.Auditorias!
                .OrderByDescending(a => a.FechaHora)
                .Take(100)
                .ToList();
        }

        public List<Auditorias> Buscar(Auditorias? entidad)
        {
            if (entidad == null) return Listar();

            var consulta = this.IConexion!.Auditorias!.AsQueryable();

            if (!string.IsNullOrEmpty(entidad.TipoAccion))
                consulta = consulta.Where(x => x.TipoAccion!.Contains(entidad.TipoAccion));

            if (!string.IsNullOrEmpty(entidad.NombreTabla))
                consulta = consulta.Where(x => x.NombreTabla!.Contains(entidad.NombreTabla));

            if (!string.IsNullOrEmpty(entidad.UsuarioEmail))
                consulta = consulta.Where(x => x.UsuarioEmail!.Contains(entidad.UsuarioEmail));

            if (entidad.RegistroID.HasValue && entidad.RegistroID.Value > 0)
                consulta = consulta.Where(x => x.RegistroID == entidad.RegistroID.Value);

            return consulta.OrderByDescending(a => a.FechaHora).ToList();
        }

        
        public Auditorias? Modificar(Auditorias? entidad)
        {
            throw new NotSupportedException("Operación no permitida: No se pueden modificar registros de Auditoría.");
        }

        public Auditorias? Borrar(Auditorias? entidad)
        {
            throw new NotSupportedException("Operación no permitida: No se pueden borrar registros de Auditoría.");
        }
    }
}