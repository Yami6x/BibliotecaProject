using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Reservas
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public int IdLibro { get; set; }
        public int IdMiembro { get; set; }
        public string? Estado { get; set; }

        [ForeignKey("IdLibro")] public Libros? _Libro { get; set; }
        [ForeignKey("IdMiembro")] public Miembros? _Miembro { get; set; }
    }
}
