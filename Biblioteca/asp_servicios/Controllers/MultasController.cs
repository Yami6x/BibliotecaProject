using asp_servicios.Nucleo;
using lib_repositorios.Interfaces;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using lib_repositorios.Implementaciones;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MultasController : ControllerBase
    {
        private IMultasAplicacion? iAplicacion = null;
        //private TokenAplicacion? iAplicacionToken = null;
        private IMultasAplicacion? iMultasAplicacion = null;
        public MultasController(IMultasAplicacion? iAplicacion /*IAuditoriasAplicacion? iMultasAplicacion/*, TokenAplicacion iAplicacionToken*/)
        {
            this.iAplicacion = iAplicacion;
            /* this.iMultasAplicacion = iMultasAplicacion;*/
            //this.iAplicacionToken = iAplicacionToken;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            // Nota: Esta forma de leer el cuerpo del Request de manera síncrona puede
            // tener implicaciones de rendimiento en un entorno real. Se mantiene
            // por consistencia con el código original.
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";
            return JsonConversor.ConvertirAObjeto(datos);
        }

        // OPERACIONES CRUD ESTÁNDAR (Mantenidas y adaptadas a Consumos)

        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                //if (!iAplicacionToken!.Validar(datos))
                //{
                //    respuesta["Error"] = "lbNoAutenticacion";
                //    return JsonConversor.ConvertirAString(respuesta);
                //}
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
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/
                var entidad = JsonConversor.ConvertirAObjeto<Multas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this.iAplicacion!.Guardar(entidad);

                //var registroAuditoria = new Auditorías
                //{
                //    // Empleado: Asume que 0 es un valor temporal si no tienes el ID del usuario actual.
                //    Empleado = 0,
                //    Accion = "CREAR",
                //    Descripcion = "Nuevo empleado agregado al sistema.",
                //    Previo = null,
                //    Nuevo = JsonConversor.ConvertirAString(entidad!),
                //    Fecha = DateTime.Now,
                //    Tabla = "Consumos"
                //};

                //this.iAuditoriasAplicacion!.Guardar(registroAuditoria);

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
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/
                var entidad = JsonConversor.ConvertirAObjeto<Multas>(
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
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/
                var entidad = JsonConversor.ConvertirAObjeto<Multas>(
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
