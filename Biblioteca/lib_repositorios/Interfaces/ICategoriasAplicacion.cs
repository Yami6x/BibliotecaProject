﻿using lib_dominio.Entidades;

public interface ICategoriasAplicacion
{
    void Configurar(string StringConexion);
    List<Categorias> Listar();
    List<Categorias> Buscar(Categorias? entidad);
    Categorias? Guardar(Categorias? entidad);
    Categorias? Modificar(Categorias? entidad);
    Categorias? Borrar(Categorias? entidad);
}
