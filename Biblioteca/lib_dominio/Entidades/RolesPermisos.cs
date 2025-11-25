namespace lib_dominio.Entidades
{
    public class RolesPermisos
    {

        public int RolID { get; set; }
        public int PermisoID { get; set; }
        public Roles? Rol { get; set; }
        public Permisos? Permiso { get; set; }
    }
}
