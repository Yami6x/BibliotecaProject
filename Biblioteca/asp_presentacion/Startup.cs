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
            services.AddScoped<IEmpleados_RolesPresentacion, Empleados_RolesPresentacion>();
            services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
            services.AddScoped<IIdiomasPresentacion, IdiomasPresentacion>();
            services.AddScoped<ILibrosPresentacion, LibrosPresentacion>();
            services.AddScoped<IMiembrosPresentacion, MiembrosPresentacion>();
            services.AddScoped<IMultasPresentacion, MultasPresentacion>();
            services.AddScoped<IPagosPresentacion, PagosPresentacion>();
            services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
            services.AddScoped<IPrestamosPresentacion, PrestamosPresentacion>();
            services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
            services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
            services.AddScoped<IReservasPresentacion, ReservasPresentacion>();
            services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
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
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}