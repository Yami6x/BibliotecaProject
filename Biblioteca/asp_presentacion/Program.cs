using asp_presentacion;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder, builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);
app.Run();