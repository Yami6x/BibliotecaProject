using asp_servicios.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosAplicacion? _UsuariosAplicacion = null;
        private readonly TokenAplicacion? iAplicacionToken = null;

        public UsuariosController(IUsuariosAplicacion _UsuariosAplicacion, TokenAplicacion iAplicacionToken)
        {
            this._UsuariosAplicacion = _UsuariosAplicacion;
            this.iAplicacionToken = iAplicacionToken;
        }
        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";
            return JsonConversor.ConvertirAObjeto(datos);
        }

        [HttpPost]
        public string Login()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                var entidad = JsonConversor.ConvertirAObjeto<Usuarios>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this._UsuariosAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                var usuario = this._UsuariosAplicacion!.ValidarUsuario(entidad);

                if (usuario == null)
                {
                    respuesta["Error"] = "Usuario o contraseña incorrectos";
                    respuesta["Success"] = false;
                }
                else
                {
                    // Generar un token simple
                    var token = iAplicacionToken!.Generar();

                    respuesta["Success"] = true;
                    respuesta["Token"] = token;
                    respuesta["Email"] = usuario.Email;
                    respuesta["TipoUsuario"] = usuario.TipoUsuario;
                    respuesta["UsuarioID"] = usuario.UsuarioID;
                    respuesta["Mensaje"] = "Login exitoso";
                }

                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Success"] = false;
                respuesta["Mensaje"] = "Error en el servidor";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
        [HttpPost]
        public string ValidarUsuario()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Usuarios>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this._UsuariosAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                var usuario = this._UsuariosAplicacion!.ValidarUsuario(entidad);

                if (usuario == null)
                {
                    respuesta["Error"] = "Usuario no encontrado";
                }
                else
                {
                    respuesta["Entidad"] = usuario;
                    respuesta["Respuesta"] = "OK";
                }

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
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                this._UsuariosAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                respuesta["Entidades"] = this._UsuariosAplicacion!.Listar();
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
        public string PorTipoUsuario()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Usuarios>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this._UsuariosAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                respuesta["Entidades"] = this._UsuariosAplicacion!.PorTipoUsuario(entidad);
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
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Usuarios>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                this._UsuariosAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this._UsuariosAplicacion!.Guardar(entidad);
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
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Usuarios>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                this._UsuariosAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this._UsuariosAplicacion!.Modificar(entidad);
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
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Usuarios>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                this._UsuariosAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));


                entidad = this._UsuariosAplicacion!.Borrar(entidad);
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