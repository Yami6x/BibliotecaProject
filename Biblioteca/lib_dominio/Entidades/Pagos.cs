using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Pagos
    {
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string? MetodoPago { get; set; }
        public int IdMulta { get; set; }

        [ForeignKey("IdMulta")] public Multas? _Multa { get; set; }
    }
}
