using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{

    public class Auditorias
    {

        [Key] public long AuditoriaID { get; set; }
        public DateTime FechaHora { get; set; }
        public string? UsuarioEmail { get; set; }
        public string? TipoAccion { get; set; }
        public string? NombreTabla { get; set; }
        public int? RegistroID { get; set; }
        public string? Detalles { get; set; }
    }
}

