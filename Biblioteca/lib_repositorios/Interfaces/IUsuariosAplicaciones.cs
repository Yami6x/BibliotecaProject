﻿using lib_dominio.Entidades;
using System.Collections.Generic;

namespace lib_repositorios.Interfaces
{
    public interface IUsuariosAplicacion
    {
        void Configurar(string StringConexion);
        List<Usuarios> Listar();
        List<Usuarios> Buscar(Usuarios? entidad);
        Usuarios? Guardar(Usuarios? entidad);
        Usuarios? Modificar(Usuarios? entidad);
        Usuarios? Borrar(Usuarios? entidad);
    }
}
