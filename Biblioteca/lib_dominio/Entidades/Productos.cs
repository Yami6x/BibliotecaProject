using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public int IdProveedor { get; set; }

        [ForeignKey("IdProveedor")] public Proveedores? _Proveedor { get; set; }
    }
}
