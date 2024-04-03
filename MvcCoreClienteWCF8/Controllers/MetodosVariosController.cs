using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF8.Services;

namespace MvcCoreClienteWCF8.Controllers
{
    public class MetodosVariosController : Controller
    {
        private ServiceMetodosVarios service;

        public MetodosVariosController(ServiceMetodosVarios service)
        {
            this.service = service;
        }

        public IActionResult TablaMultiplicar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TablaMultiplicar
            (int numero)
        {
            int[] numeros = await
                this.service.GetTablaMultiplicarAsync(numero);
            return View(numeros);
        }
    }
}
