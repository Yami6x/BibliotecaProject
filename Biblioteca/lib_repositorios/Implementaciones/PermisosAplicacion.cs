using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace lib_repositorios.Implementaciones
{
    public class PermisosAplicacion : IPermisosAplicacion
    {
        private IConexion? IConexion = null;

        public PermisosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Permisos? Guardar(Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.PermisoId != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Permisos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Permisos? Modificar(Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.PermisoId == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Permisos? Borrar(Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.PermisoId == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Permisos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Permisos> Listar()
        {
            return this.IConexion!.Permisos!
                .Include(p => p.Nombre)
                .Take(20)
                .ToList();
        }

        public List<Permisos> PorNombre(Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (string.IsNullOrEmpty(entidad.Nombre) && string.IsNullOrEmpty(entidad.Descripcion))
            {
                return this.IConexion!.Permisos!.ToList();
            }

            return this.IConexion!.Permisos!
                .Where(x =>
                    (entidad.Nombre != null && x.Nombre!.Contains(entidad.Nombre)) ||
                    (entidad.Descripcion != null && x.Descripcion!.Contains(entidad.Descripcion))
                )
                .ToList();
        }
    }
    }

