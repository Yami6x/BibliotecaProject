using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PrestamosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private List<Prestamos>? lista;
        private Prestamos? entidad;

        public PrestamosAplicacionPrueba()
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
            if (entidad == null)
            {
                throw new ArgumentNullException(nameof(entidad), "La entidad Prestamos no puede ser nula.");
            }
            iConexion!.Prestamos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            if (entidad == null)
            {
                throw new InvalidOperationException("No se puede modificar porque la entidad Prestamos no fue inicializada.");
            }
            entidad!.IdLibro = 1;
            var entry = iConexion!.Entry<Prestamos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            if (entidad == null)
            {
                throw new InvalidOperationException("No se puede borrar porque la entidad Prestamos no fue inicializada.");
            }
            iConexion!.Prestamos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}

