using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Multas
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaMulta { get; set; }
        public int IdPrestamo { get; set; }
        public string? Estado { get; set; }

        [ForeignKey("IdPrestamo")] public Prestamos? _Prestamo { get; set; }
    }
}
