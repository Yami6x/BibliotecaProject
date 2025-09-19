﻿using lib_dominio.Entidades;

public interface IMultasAplicacion
{
    void Configurar(string StringConexion);
    List<Multas> Listar();
    List<Multas> Buscar(Multas? entidad);
    Multas? Guardar(Multas? entidad);
    Multas? Modificar(Multas? entidad);
    Multas? Borrar(Multas? entidad);
}
