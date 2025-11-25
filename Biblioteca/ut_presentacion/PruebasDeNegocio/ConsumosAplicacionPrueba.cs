using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ConsumosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private List<Consumos>? lista;
        private Consumos? entidad;

        public ConsumosAplicacionPrueba()
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
            iConexion!.Consumos!.Add(entidad!);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Cantidad = entidad!.Cantidad + 1;
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
}
