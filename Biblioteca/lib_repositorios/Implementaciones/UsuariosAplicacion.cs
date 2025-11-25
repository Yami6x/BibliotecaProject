using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace lib_repositorios.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion? IConexion = null;

        public UsuariosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Usuarios? ValidarUsuario(Usuarios entidad)
        {
            if (entidad == null || string.IsNullOrEmpty(entidad.Email) || string.IsNullOrEmpty(entidad.Contrasena))
                return null;

            var usuario = this.IConexion!.Usuarios!
                .FirstOrDefault(x => x.Email == entidad.Email && x.Contrasena == entidad.Contrasena);

            return usuario;
        }

        public Usuarios? Guardar(Usuarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.UsuarioID != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Usuarios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Usuarios? Modificar(Usuarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.UsuarioID == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Usuarios? Borrar(Usuarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.UsuarioID == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Usuarios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Usuarios> Listar()
        {
            return this.IConexion!.Usuarios!
                .Include(u => u.ReferenciaID)
                .Take(20)
                .ToList();
        }

        public List<Usuarios> PorTipoUsuario(Usuarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (string.IsNullOrEmpty(entidad.Contrasena) &&
                string.IsNullOrEmpty(entidad.TipoUsuario) &&
                string.IsNullOrEmpty(entidad.Email))
            {
                return this.IConexion!.Usuarios!.ToList();
            }

            return this.IConexion!.Usuarios!
                .Where(x =>
                    (entidad.Contrasena != null && x.Contrasena!.Contains(entidad.Contrasena)) ||
                    (entidad.TipoUsuario != null && x.TipoUsuario!.Contains(entidad.TipoUsuario)) ||
                    (entidad.Email != null && x.Email!.Contains(entidad.Email))
                )
                .ToList();
        }
    }
}
