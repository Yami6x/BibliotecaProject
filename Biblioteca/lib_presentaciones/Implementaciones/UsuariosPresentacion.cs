using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using System.Diagnostics.Metrics;


namespace lib_presentaciones.Implementaciones
{
    public class UsuariosPresentacion : IUsuariosPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<Dictionary<string, object>> Login(Usuarios? entidad)
        {
            var respuesta = new Dictionary<string, object>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/Login");
            respuesta = await comunicaciones!.Ejecutar(datos);

            return respuesta;
        }
        public async Task<Usuarios?> ValidarUsuario(Usuarios? entidad)
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/ValidarUsuario");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                return null;
            }

            var usuario = JsonConversor.ConvertirAObjeto<Usuarios>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return usuario;
        }
        public async Task<List<Usuarios>> Listar()
        {
            var lista = new List<Usuarios>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Usuarios>>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return lista;
        }


        public async Task<List<Usuarios>> PorTipoUsuario(Usuarios? entidad)
        {
            var lista = new List<Usuarios>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/PorTipoUsuario");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Usuarios>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }


        public async Task<Usuarios?> Guardar(Usuarios? entidad)
        {
            if (entidad!.UsuarioID != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Usuarios>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }


        public async Task<Usuarios?> Modificar(Usuarios? entidad)
        {
            if (entidad!.UsuarioID == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/Modificar");

            var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Usuarios>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }


        public async Task<Usuarios?> Borrar(Usuarios? entidad)
        {
            if (entidad!.UsuarioID == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Usuarios>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}