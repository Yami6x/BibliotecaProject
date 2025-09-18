namespace lib_dominio.Entidades
{
    public class Categorias
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Area { get; set; }
    }
}
