using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

[TestClass]
public class CategoriasPrueba
{
    private readonly IConexion? iConexion;
    private List<Categorias>? lista;
    private Categorias? entidad;

    public CategoriasPrueba()
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
        lista = iConexion!.Categorias!.ToList();
        return lista.Count > 0;
    }

    public bool Guardar()
    {
        entidad = EntidadesNucleo.Categorias();
        iConexion!.Categorias!.Add(entidad);
        iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        entidad!.Descripcion = "Nueva categoria";
        var entry = iConexion!.Entry<Categorias>(entidad);
        entry.State = EntityState.Modified;
        iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        iConexion!.Categorias!.Remove(entidad!);
        iConexion!.SaveChanges();
        return true;
    }
}