using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;


namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class AutoresPrueba
    {
        private readonly IConexion? iConexion;
        private List<Autores>? lista;
        private Autores? entidad;

        public AutoresPrueba()
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
            lista = iConexion!.Autores!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = EntidadesNucleo.Autores();
            iConexion!.Autores!.Add(entidad!);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Nacionalidad = "Modificado";
            var entry = iConexion!.Entry<Autores>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Autores!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}