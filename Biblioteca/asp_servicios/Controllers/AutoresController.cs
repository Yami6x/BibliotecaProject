using Microsoft.AspNetCore.Mvc;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using lib_repositorios.Implementaciones;
using asp_servicios.Nucleo;
using lib_dominio.Nucleo;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresAplicacion _autoresAplicacion;

        public AutoresController(IAutoresAplicacion autoresAplicacion)
        {
            _autoresAplicacion = autoresAplicacion;
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
                _autoresAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
                var lista = _autoresAplicacion.Listar();

                respuesta["Entidades"] = lista;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                respuesta["Respuesta"] = "Error";
                respuesta["Error"] = ex.Message;
            }
            return JsonConversor.ConvertirAString(respuesta);
        }

        
        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                var entidad = JsonConversor.ConvertirAObjeto<Autores>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                _autoresAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
                var nuevoAutor = _autoresAplicacion.Guardar(entidad);

                respuesta["Entidad"] = nuevoAutor;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                respuesta["Respuesta"] = "Error";
                respuesta["Error"] = ex.Message;
            }
            return JsonConversor.ConvertirAString(respuesta);
        }

     
        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                var entidad = JsonConversor.ConvertirAObjeto<Autores>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                _autoresAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
                var actualizado = _autoresAplicacion.Modificar(entidad);

                respuesta["Entidad"] = actualizado;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                respuesta["Respuesta"] = "Error";
                respuesta["Error"] = ex.Message;
            }
            return JsonConversor.ConvertirAString(respuesta);
        }

        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                var entidad = JsonConversor.ConvertirAObjeto<Autores>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                _autoresAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
                var eliminado = _autoresAplicacion.Borrar(entidad);

                respuesta["Entidad"] = eliminado;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                respuesta["Respuesta"] = "Error";
                respuesta["Error"] = ex.Message;
            }
            return JsonConversor.ConvertirAString(respuesta);
        }
    }
}
