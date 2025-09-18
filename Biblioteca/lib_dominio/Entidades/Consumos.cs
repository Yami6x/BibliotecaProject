using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Consumos
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdMiembro { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("IdProducto")] public Productos? _IdProducto { get; set; }
        [ForeignKey("IdMiembro")] public Reservas? _IdMiembro { get; set; }
    }
}
