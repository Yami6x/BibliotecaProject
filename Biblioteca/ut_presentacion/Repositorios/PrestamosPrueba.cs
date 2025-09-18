using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

[TestClass]
public class PrestamosPrueba
{
    private readonly IConexion? iConexion;
    private List<Prestamos>? lista;
    private Prestamos? entidad;

    public PrestamosPrueba()
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
        lista = iConexion!.Prestamos!.ToList();
        return lista.Count > 0;
    }

    public bool Guardar()
    {
        entidad = EntidadesNucleo.Prestamos();
        iConexion!.Prestamos!.Add(entidad);
        iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        entidad!.IdLibro = 1 ;
        var entry = iConexion!.Entry<Prestamos>(entidad);
        entry.State = EntityState.Modified;
        iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        iConexion!.Prestamos!.Remove(entidad!);
        iConexion!.SaveChanges();
        return true;
    }
}