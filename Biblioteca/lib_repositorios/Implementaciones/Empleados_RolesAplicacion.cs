using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Empleados_RolesAplicacion : IEmpleados_RolesAplicacion
    {
        private IConexion? IConexion = null;

        public Empleados_RolesAplicacion(IConexion iConexion) => this.IConexion = iConexion;

        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Empleados_Roles? Guardar(Empleados_Roles? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            this.IConexion!.Empleados_Roles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados_Roles? Modificar(Empleados_Roles? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Entry(entidad).State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados_Roles? Borrar(Empleados_Roles? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Empleados_Roles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Empleados_Roles> Listar() => this.IConexion!.Empleados_Roles!.Take(20).ToList();

        public List<Empleados_Roles> PorEmpleadoId(Empleados_Roles? entidad)
        {
            
            if (entidad!.EmpleadoId == 0)
            {
                return this.IConexion!.Empleados_Roles!.ToList();
            }

            
            return this.IConexion!.Empleados_Roles!
                .Where(x => x.EmpleadoId == entidad!.EmpleadoId)                        
                .ToList();
        }
    }
}

