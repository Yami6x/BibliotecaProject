using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    
        public class Auditoria
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Usuario { get; set; } = string.Empty;

            [Required]
            [StringLength(100)]
            public string Entidad { get; set; } = string.Empty;

            [Required]
            [StringLength(50)]
            public string Accion { get; set; } = string.Empty;

            public DateTime Fecha { get; set; } = DateTime.Now;

            public string? Detalles { get; set; }

            [StringLength(50)]
            public string? DireccionIP { get; set; }
        }
    }


