using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Libros
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public int? AnioPublicacion { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
        public int IdIdioma { get; set; }

        [ForeignKey("IdAutor")] public Autores? _Autor { get; set; }
        [ForeignKey("IdCategoria")] public Categorias? _Categoria { get; set; }
        [ForeignKey("IdIdioma")] public Idiomas? _Idioma { get; set; }
    }
}
