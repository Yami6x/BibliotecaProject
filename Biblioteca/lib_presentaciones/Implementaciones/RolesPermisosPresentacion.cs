using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using System.Diagnostics.Metrics;


namespace lib_presentaciones.Implementaciones
{
    public class RolesPermisosPresentacion : IRolesPermisosPresentacion
    {
        private Comunicaciones? comunicaciones = null;


        public async Task<List<RolesPermisos>> Listar()
        {
            var lista = new List<RolesPermisos>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "RolesPermisos/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<RolesPermisos>>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return lista;
        }


        public async Task<List<RolesPermisos>> PorRolID(RolesPermisos? entidad)
        {
            var lista = new List<RolesPermisos>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "RolesPermisos/PorRolID");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<RolesPermisos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }


        public async Task<RolesPermisos?> Guardar(RolesPermisos? entidad)
        {
            if (entidad!.RolID != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "RolesPermisos/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<RolesPermisos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }


        public async Task<RolesPermisos?> Modificar(RolesPermisos? entidad)
        {
            if (entidad!.RolID == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "RolesPermisos/Modificar");

            var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<RolesPermisos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }


        public async Task<RolesPermisos?> Borrar(RolesPermisos? entidad)
        {
            if (entidad!.RolID == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "RolesPermisos/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<RolesPermisos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}