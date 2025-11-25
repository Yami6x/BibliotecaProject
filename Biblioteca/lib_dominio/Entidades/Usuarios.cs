using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        [Key] public int UsuarioID { get; set; }
        public string? Email { get; set; }
        public string? Contrasena { get; set; }
        public string? TipoUsuario { get; set; }
        public int ReferenciaID { get; set; }
    }
}
