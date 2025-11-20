namespace lib_dominio.Entidades
{
    public class Permisos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }   
        public string? Descripcion { get; set; }                
        public int? RolId { get; set; }
        public Roles? Rol { get; set; }
              
    }
}
