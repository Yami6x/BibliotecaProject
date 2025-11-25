using lib_dominio.Entidades;

public interface IAuditoriasAplicacion
{
    void Configurar(string StringConexion);
    List<Auditorias> Listar();
    List<Auditorias> Buscar(Auditorias? entidad);
    Auditorias? Guardar(Auditorias? entidad);
    Auditorias? Modificar(Auditorias? entidad);
    Auditorias? Borrar(Auditorias? entidad);
}