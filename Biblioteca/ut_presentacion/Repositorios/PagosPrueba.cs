using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

[TestClass]
public class PagosPrueba
{
    private readonly IConexion? iConexion;
    private List<Pagos>? lista;
    private Pagos? entidad;

    public PagosPrueba()
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
        lista = iConexion!.Pagos!.ToList();
        return lista.Count > 0;
    }

    public bool Guardar()
    {
        entidad = EntidadesNucleo.Pagos();
        iConexion!.Pagos!.Add(entidad);
        iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        entidad!.MetodoPago = "Modificado";
        var entry = iConexion!.Entry<Pagos>(entidad);
        entry.State = EntityState.Modified;
        iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        iConexion!.Pagos!.Remove(entidad!);
        iConexion!.SaveChanges();
        return true;
    }
}