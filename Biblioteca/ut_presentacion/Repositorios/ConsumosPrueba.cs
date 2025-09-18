using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

[TestClass]
public class ConsumosPrueba
{
    private readonly IConexion? iConexion;
    private List<Consumos>? lista;
    private Consumos? entidad;

    public ConsumosPrueba()
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
        lista = iConexion!.Consumos!.ToList();
        return lista.Count > 0;
    }

    public bool Guardar()
    {
        entidad = EntidadesNucleo.Consumos();
        iConexion!.Consumos!.Add(entidad);
        iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        entidad!.Cantidad = 1;
        var entry = iConexion!.Entry<Consumos>(entidad);
        entry.State = EntityState.Modified;
        iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        iConexion!.Consumos!.Remove(entidad!);
        iConexion!.SaveChanges();
        return true;
    }
}