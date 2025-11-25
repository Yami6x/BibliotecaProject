using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lib_repositorios.Implementaciones
{
    public class RolesPermisosAplicacion : IRolesPermisosAplicacion
    {
      
        private readonly IConexion IConexion;

        public RolesPermisosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion.StringConexion = StringConexion;
        }

        public RolesPermisos? Guardar(RolesPermisos? entidad)
        {
          
            if (entidad == null || entidad.RolID == 0 || entidad.PermisoID == 0)
                throw new Exception("lbFaltaInformacion: Se requiere RolID y PermisoID.");

            var existe = this.IConexion.RolesPermisos!
                .Any(x => x.RolID == entidad.RolID && x.PermisoID == entidad.PermisoID);

            if (existe)
                throw new Exception("lbYaSeGuardo: La relación Rol-Permiso ya existe.");

            this.IConexion.RolesPermisos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public RolesPermisos? Modificar(RolesPermisos? entidad)
        {        
            if (entidad == null || entidad.RolID == 0 || entidad.PermisoID == 0)
                throw new Exception("lbFaltaInformacion: Se requiere RolID y PermisoID para modificar.");

            
            var entry = this.IConexion.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public RolesPermisos? Borrar(RolesPermisos? entidad)
        {
            if (entidad == null || entidad.RolID == 0 || entidad.PermisoID == 0)
                throw new Exception("lbFaltaInformacion: Se requiere RolID y PermisoID para borrar.");

            this.IConexion.RolesPermisos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<RolesPermisos> Listar()
        {
            return this.IConexion.RolesPermisos!.ToList();
        }

        public List<RolesPermisos> PorRolID(RolesPermisos? entidad)
        {
            if (entidad == null)
                return new List<RolesPermisos>();

            if (entidad.RolID == 0)
            {
                return this.IConexion.RolesPermisos!.ToList();
            }

            return this.IConexion.RolesPermisos!
                .Where(x => x.RolID == entidad.RolID || x.PermisoID == entidad.PermisoID)
                .ToList();
        }
    }
}