using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Presentaciones
            services.AddScoped<IAutoresPresentacion, AutoresPresentacion>();
            services.AddScoped<ICategoriasPresentacion, CategoriasPresentacion>();
            services.AddScoped<IConsumosPresentacion, ConsumosPresentacion>();
            services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
            services.AddScoped<ILibrosPresentacion, LibrosPresentacion>();
            services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            services.AddScoped<IEmpleados_RolesPresentacion, Empleados_RolesPresentacion>();
            services.AddScoped<IIdiomasPresentacion, IdiomasPresentacion>();
            services.AddScoped<IMiembrosPresentacion, MiembrosPresentacion>();
            services.AddScoped<IPrestamosPresentacion, PrestamosPresentacion>();
            services.AddScoped<IMultasPresentacion, MultasPresentacion>();
            services.AddScoped<IPagosPresentacion, PagosPresentacion>();
            services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
            services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
            services.AddScoped<IReservasPresentacion, ReservasPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
            services.AddScoped<IRolesPermisosPresentacion, RolesPermisosPresentacion>();
            services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Login", "");
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.MapRazorPages();
        }
    }
}