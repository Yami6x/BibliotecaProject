using asp_servicios.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using lib_repositorios.Implementaciones; 
namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private IRolesAplicacion? iAplicacion = null;

        public RolesController(IRolesAplicacion? iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";
            return JsonConversor.ConvertirAObjeto(datos);
        }

        
        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                respuesta["Entidades"] = this.iAplicacion!.Listar();
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

       
        [HttpPost]
        public string Buscar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                               var entidad = JsonConversor.ConvertirAObjeto<Roles>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                respuesta["Entidades"] = this.iAplicacion!.Buscar(entidad);
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        
        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                var entidad = JsonConversor.ConvertirAObjeto<Roles>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this.iAplicacion!.Guardar(entidad);

                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        
        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                var entidad = JsonConversor.ConvertirAObjeto<Roles>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this.iAplicacion!.Modificar(entidad);

                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

       
        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                var entidad = JsonConversor.ConvertirAObjeto<Roles>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this.iAplicacion!.Borrar(entidad);

                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}