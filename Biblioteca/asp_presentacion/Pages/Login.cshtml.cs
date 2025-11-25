using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUsuariosPresentacion? iPresentacion = null;

        public LoginModel(IUsuariosPresentacion iPresentacion)
        {
            this.iPresentacion = iPresentacion;
        }

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Contrasena { get; set; }

        public string? Mensaje { get; set; }
        public bool Success { get; set; }

        public void OnGet()
        {
            // Verificar si ya hay sesión activa
            var token = HttpContext.Session.GetString("Token");
            if (!string.IsNullOrEmpty(token))
            {
                Response.Redirect("/Index");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var usuario = new Usuarios
                {
                    Email = Email,
                    Contrasena = Contrasena
                };

                var respuesta = await iPresentacion!.Login(usuario);

                if (respuesta.ContainsKey("Success") && (bool)respuesta["Success"])
                {
                    // Guardar en sesión
                    HttpContext.Session.SetString("Token", respuesta["Token"].ToString()!);
                    HttpContext.Session.SetString("Email", respuesta["Email"].ToString()!);
                    HttpContext.Session.SetString("TipoUsuario", respuesta["TipoUsuario"].ToString()!);
                    HttpContext.Session.SetString("UsuarioID", respuesta["UsuarioID"].ToString()!);

                    // Redirigir a la página principal
                    return RedirectToPage("/Index");
                }
                else
                {
                    Mensaje = respuesta.ContainsKey("Error")
                        ? respuesta["Error"].ToString()
                        : "Usuario o contraseña incorrectos";
                    Success = false;
                }
            }
            catch (Exception ex)
            {
                Mensaje = "Error al iniciar sesión: " + ex.Message;
                Success = false;
            }

            return Page();
        }
    }
}