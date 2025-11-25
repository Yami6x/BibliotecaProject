using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

[TestClass]
public class MiembrosPrueba
{
    private readonly IConexion? iConexion;
    private List<Miembros>? lista;
    private Miembros? entidad;

    public MiembrosPrueba()
    {
        iConexion = new Conexion();
        iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
    }

    [TestMethod]
    public void Ejecutar()
    {
        Assert.IsTrue(Guardar());
        Assert.IsTrue(Modificar());
        Assert.IsTrue(Listar());
        Assert.IsTrue(Borrar());
    }

    public bool Listar()
    {
        lista = iConexion!.Miembros!.ToList();
        return lista.Count > 0;
    }

    public bool Guardar()
    {
        entidad = EntidadesNucleo.Miembros();
        iConexion!.Miembros!.Add(entidad!);
        iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        entidad!.Telefono = "999999999";
        var entry = iConexion!.Entry<Miembros>(entidad);
        entry.State = EntityState.Modified;
        iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        iConexion!.Miembros!.Remove(entidad!);
        iConexion!.SaveChanges();
        return true;
    }
}