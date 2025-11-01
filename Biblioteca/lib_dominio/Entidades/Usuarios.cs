namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }

        
        public string? Nombre { get; set; }        
        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }   
        public string? Correo { get; set; }                      
        
        public int RolId { get; set; }
        public Roles? Rol { get; set; }
        public bool Estado { get; set; } = true;               
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public Usuarios() { }

        public Usuarios(string nombre, string usuario, string contrasena, int rolId, string? correo = null)
        {
            Nombre = nombre;
            Usuario = usuario;
            Contrasena = contrasena;
            RolId = rolId;
            Correo = correo;
        }
    }
}
