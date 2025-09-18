namespace lib_dominio.Entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefono { get; set; }
        public string Cargo { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
    }
}
