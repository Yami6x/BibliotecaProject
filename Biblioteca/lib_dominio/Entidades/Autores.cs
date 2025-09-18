namespace lib_dominio.Entidades
{
    public class Autores
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Nacionalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
