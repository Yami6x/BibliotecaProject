using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Empleados_Roles
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int RolId { get; set; }

        [ForeignKey("EmpleadoId")] public Empleados? _Empleado { get; set; }
        [ForeignKey("RolId")] public Roles? _Rol { get; set; }
    }
}
