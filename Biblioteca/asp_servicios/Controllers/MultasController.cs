using asp_servicios.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using lib_repositorios.Implementaciones; // Asegúrate de que esta ruta sea correcta para MultasAplicacion

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MultasController : ControllerBase
    {
        private IMultasAplicacion? iAplicacion = null;

        public MultasController(IMultasAplicacion? iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            // Lee el cuerpo de la petición HTTP
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";
            return JsonConversor.ConvertirAObjeto(datos);
        }

        // -------------------------------------------------------------------
        // 1. READ (Listar)
        // -------------------------------------------------------------------
        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                // Llama al método Listar
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

        // -------------------------------------------------------------------
        // 2. READ (Buscar)
        // -------------------------------------------------------------------
        [HttpPost]
        public string Buscar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                // Extrae la entidad Multas del JSON para usarla como filtro
                var entidad = JsonConversor.ConvertirAObjeto<Multas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                // Llama al método Buscar. El filtro en Aplicación es por Estado.
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

        // -------------------------------------------------------------------
        // 3. CREATE (Guardar)
        // -------------------------------------------------------------------
        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                // Extrae la entidad Multas
                var entidad = JsonConversor.ConvertirAObjeto<Multas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                // Llama a Guardar. La aplicación espera Id = 0.
                entidad = this.iAplicacion!.Guardar(entidad);

                // Devuelve la entidad con el nuevo Id generado por la DB.
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

        // -------------------------------------------------------------------
        // 4. UPDATE (Modificar)
        // -------------------------------------------------------------------
        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                // Extrae la entidad Multas
                var entidad = JsonConversor.ConvertirAObjeto<Multas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                // Llama a Modificar. La aplicación espera Id != 0.
                entidad = this.iAplicacion!.Modificar(entidad);

                // Devuelve la entidad modificada.
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

        // -------------------------------------------------------------------
        // 5. DELETE (Borrar)
        // -------------------------------------------------------------------
        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                // Extrae la entidad Multas
                var entidad = JsonConversor.ConvertirAObjeto<Multas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                // Llama a Borrar. La aplicación espera Id != 0.
                entidad = this.iAplicacion!.Borrar(entidad);

                // Devuelve la entidad borrada.
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