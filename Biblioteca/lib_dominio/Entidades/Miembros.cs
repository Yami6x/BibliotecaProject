﻿namespace lib_dominio.Entidades
{
    public class Miembros
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
