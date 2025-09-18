using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

[TestClass]
public class EmpleadosPrueba
{
    private readonly IConexion? iConexion;
    private List<Empleados>? lista;
    private Empleados? entidad;

    public EmpleadosPrueba()
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
        lista = iConexion!.Empleados!.ToList();
        return lista.Count > 0;
    }

    public bool Guardar()
    {
        entidad = EntidadesNucleo.Empleados();
        iConexion!.Empleados!.Add(entidad);
        iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        entidad!.Cargo = "Modificado";
        var entry = iConexion!.Entry<Empleados>(entidad);
        entry.State = EntityState.Modified;
        iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        iConexion!.Empleados!.Remove(entidad!);
        iConexion!.SaveChanges();
        return true;
    }
}