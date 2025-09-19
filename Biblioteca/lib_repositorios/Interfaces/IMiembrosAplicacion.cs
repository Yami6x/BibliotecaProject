using lib_dominio.Entidades;

public interface IMiembrosAplicacion
{
    void Configurar(string StringConexion);
    List<Miembros> Listar();
    List<Miembros> Buscar(Miembros? entidad);
    Miembros? Guardar(Miembros? entidad);
    Miembros? Modificar(Miembros? entidad);
    Miembros? Borrar(Miembros? entidad);
}
