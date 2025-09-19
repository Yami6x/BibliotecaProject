﻿using lib_dominio.Entidades;

public interface IAutoresAplicacion
{
    void Configurar(string StringConexion);
    List<Autores> Listar();
    List<Autores> Buscar(Autores? entidad);
    Autores? Guardar(Autores? entidad);
    Autores? Modificar(Autores? entidad);
    Autores? Borrar(Autores? entidad);
}
