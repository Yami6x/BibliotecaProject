

namespace lib_dominio.Entidades
{
    public class Permisos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;      
        public string? Descripcion { get; set; }                
        public int? RolId { get; set; }
        public Roles? Rol { get; set; }

        public Permisos() { }

        public Permisos(string nombre, string? descripcion = null, int? rolId = null)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            RolId = rolId;
        }
    };
}
