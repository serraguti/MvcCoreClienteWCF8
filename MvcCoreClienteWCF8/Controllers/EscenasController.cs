using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF8.Services;
using ServiceReferenceEscenas;

namespace MvcCoreClienteWCF8.Controllers
{
    public class EscenasController : Controller
    {
        private ServiceEscenas service;

        public EscenasController(ServiceEscenas service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            Escena[] escenas = await this.service.GetEscenasAsync();
            return View(escenas);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int idpeli)
        {
            Escena[] escenas = await this.service.GetEscenasPelis(idpeli);
            return View(escenas);
        }
    }
}
