using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class TokenAplicacion
    {
        private readonly IConexion IConexion;

        private const string LlaveSecreta = "KJGjkhdjkfgkjf54fs65d4f65sd4f";

        public TokenAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion.StringConexion = StringConexion;
        }

        public string Llave(Usuarios? entidad)
        {
            if (entidad == null)
                return string.Empty;

            var usuario = this.IConexion.Usuarios!
                .FirstOrDefault(x => x.Email == entidad.Email &&
                                x.Contrasena == entidad.Contrasena);

            if (usuario == null)
                return string.Empty;

            return LlaveSecreta;
        }

        public string Generar()
        {
            return LlaveSecreta;
        }

        public bool Validar(Dictionary<string, object> datos)
        {
            if (!datos.ContainsKey("Llave"))
                return false;

            return LlaveSecreta == datos["Llave"]?.ToString();
        }
    }
}