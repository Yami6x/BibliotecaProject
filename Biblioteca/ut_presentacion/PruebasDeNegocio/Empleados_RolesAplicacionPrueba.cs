using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class Empleados_RolesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private List<Empleados_Roles>? lista;
        private Empleados_Roles? entidad;

        public Empleados_RolesAplicacionPrueba()
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
            lista = iConexion!.Empleados_Roles!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = EntidadesNucleo.Empleados_Roles();
            iConexion!.Empleados_Roles!.Add(entidad!);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            
            entidad!.RolId = entidad!.RolId + 1;
            var entry = iConexion!.Entry<Empleados_Roles>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Empleados_Roles!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}

