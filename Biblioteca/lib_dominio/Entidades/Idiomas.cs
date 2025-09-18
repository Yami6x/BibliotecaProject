namespace lib_dominio.Entidades
{
    public class Idiomas
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Codigo { get; set; }
        public string? Origen { get; set; }
    }
}