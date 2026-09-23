using Microsoft.AspNetCore.Mvc;
using SIGTA.Models;

namespace SIGTA.Controllers
{
    public class ClientesController : Controller
    {
        private static readonly List<Cliente> clientes = new()
        {
            new Cliente
            {
                Id = 1,
                NombreCompleto = "Cliente de prueba",
                Documento = "123456789",
                Telefono = "3000000000",
                Correo = "cliente@ejemplo.com",
                Direccion = "Calle 1 # 1-01",
                Activo = true
            }
        };

        public IActionResult Index()
        {
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            cliente.Id = clientes.Count == 0
                ? 1
                : clientes.Max(c => c.Id) + 1;

            clientes.Add(cliente);

            TempData["Mensaje"] = "Cliente registrado correctamente.";

            return RedirectToAction(nameof(Index));
        }
    }
}