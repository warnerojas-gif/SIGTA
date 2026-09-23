using Microsoft.AspNetCore.Mvc;
using SIGTA.Models;

namespace SIGTA.Controllers
{
    public class UsuariosController : Controller
    {
        private static readonly List<Usuario> usuarios = new()
        {
            new Usuario
            {
                Id = 1,
                NombreCompleto = "Administrador SIGTA",
                Documento = "00000000",
                Correo = "admin@sigta.com",
                Telefono = "0000000000",
                Rol = "Administrador",
                Activo = true
            }
        };

        public IActionResult Index()
        {
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            usuario.Id = usuarios.Count == 0
                ? 1
                : usuarios.Max(u => u.Id) + 1;

            usuarios.Add(usuario);

            TempData["Mensaje"] = "Usuario registrado correctamente.";

            return RedirectToAction(nameof(Index));
        }
    }
}