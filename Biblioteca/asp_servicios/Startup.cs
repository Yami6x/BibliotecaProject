using asp_servicios.Controllers;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;
namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration? Configuration { set; get; }
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection
       services)
        {
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<IAutoresAplicacion, AutoresAplicacion>();
            services.AddScoped<ICategoriasAplicacion, CategoriasAplicacion>();
            services.AddScoped<IConsumosAplicacion, ConsumosAplicacion>();
            services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
            services.AddScoped<ILibrosAplicacion, LibrosAplicacion>();
            services.AddScoped<IRolesAplicacion, RolesAplicacion>();
            services.AddScoped<IEmpleados_RolesAplicacion, Empleados_RolesAplicacion>();
            services.AddScoped<IIdiomasAplicacion, IdiomasAplicacion>();
            services.AddScoped<IMiembrosAplicacion, MiembrosAplicacion>();
            services.AddScoped<IPrestamosAplicacion, PrestamosAplicacion>();
            services.AddScoped<IMultasAplicacion, MultasAplicacion>();
            services.AddScoped<IPagosAplicacion, PagosAplicacion>();
            services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
            services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
            services.AddScoped<IReservasAplicacion, ReservasAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
            services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();



            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}