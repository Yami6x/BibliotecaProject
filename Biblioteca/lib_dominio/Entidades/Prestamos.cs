using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Prestamos
    {
        public int Id { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public int IdLibro { get; set; }
        public int IdMiembro { get; set; }

        [ForeignKey("IdLibro")] public Libros? Libro { get; set; }
        [ForeignKey("IdMiembro")] public Miembros? Miembro { get; set; }
    }
}
