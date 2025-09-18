using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Consumos
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int ReservaId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("ProductoId")] public Productos? _Producto { get; set; }
        [ForeignKey("ReservaId")] public Reservas? _Reserva { get; set; }
    }
}
