using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Autores? Autores()
        {
            var entidad = new Autores();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Apellido = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Nacionalidad = "Colombia";
            entidad.FechaNacimiento = new DateTime(1970, 1, 1);
            return entidad;
        }

        public static Categorias? Categorias()
        {
            var entidad = new Categorias();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "Categoría de prueba";
            entidad.Area = "Ciencia";
            return entidad;
        }

        public static Idiomas? Idiomas()
        {
            var entidad = new Idiomas();
            entidad.Nombre = "Español";
            entidad.Codigo = "ES";
            entidad.Origen = "España";
            return entidad;
        }

        public static Libros? Libros()
        {
            var entidad = new Libros();
            entidad.Titulo = "Prueba Libro " + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.ISBN = "978-3-16-148410-0";
            entidad.AnioPublicacion = 2020;
            entidad.IdAutor = 1;
            entidad.IdCategoria = 1;
            entidad.IdIdioma = 1;
            return entidad;
        }

        public static Miembros? Miembros()
        {
            var entidad = new Miembros();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Apellido = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Email = "miembro@biblioteca.com";
            entidad.Telefono = "3001234567";
            entidad.FechaRegistro = DateTime.Now.AddYears(-1);
            return entidad;
        }

        public static Empleados? Empleados()
        {
            var entidad = new Empleados();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Apellido = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Email = "empleado@biblioteca.com";
            entidad.Telefono = "3007654321";
            entidad.Cargo = "Bibliotecario";
            entidad.FechaIngreso = DateTime.Now.AddYears(-2);
            return entidad;
        }

        public static Roles? Roles()
        {
            var entidad = new Roles();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "Rol de prueba";
            return entidad;
        }

        public static Empleados_Roles? Empleados_Roles()
        {
            var entidad = new Empleados_Roles();
            entidad.EmpleadoId = 1;
            entidad.RolId = 1;
            return entidad;
        }

        public static Prestamos? Prestamos()
        {
            var entidad = new Prestamos();
            entidad.FechaPrestamo = DateTime.Now.AddDays(-5);
            entidad.FechaDevolucion = DateTime.Now.AddDays(5);
            entidad.IdLibro = 1;
            entidad.IdMiembro = 1;
            entidad.IdEmpleado = 1;
            return entidad;
        }

        public static Reservas? Reservas()
        {
            var entidad = new Reservas();
            entidad.FechaReserva = DateTime.Now.AddDays(-2);
            entidad.IdLibro = 1;
            entidad.IdMiembro = 1;
            entidad.Estado = "Activa";
            return entidad;
        }

        public static Multas? Multas()
        {
            var entidad = new Multas();
            entidad.Monto = 10.50m;
            entidad.FechaMulta = DateTime.Now.AddDays(-1);
            entidad.IdPrestamo = 1;
            entidad.Estado = "Pendiente";
            return entidad;
        }

        public static Pagos? Pagos()
        {
            var entidad = new Pagos();
            entidad.FechaPago = DateTime.Now;
            entidad.Monto = 10.50m;
            entidad.MetodoPago = "Efectivo";
            entidad.IdMulta = 1;
            return entidad;
        }

        public static Proveedores? Proveedores()
        {
            var entidad = new Proveedores();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Contacto = "Contacto de prueba";
            entidad.Telefono = "3009876543";
            entidad.Email = "proveedor@ejemplo.com";
            return entidad;
        }

        public static Productos? Productos()
        {
            var entidad = new Productos();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "Producto de prueba";
            entidad.Stock = 50;
            entidad.Precio = 5.50m;
            entidad.ProveedorId = 1;
            return entidad;
        }

        public static Consumos? Consumos()
        {
            var entidad = new Consumos();
            entidad.Cantidad = 3;
            entidad.Fecha = DateTime.Now;
            entidad.ProductoId = 1;
            entidad.ReservaId = 1;
            return entidad;
        }
    }
}
