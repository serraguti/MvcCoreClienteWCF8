using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF8.Models;
using MvcCoreClienteWCF8.Services;

namespace MvcCoreClienteWCF8.Controllers
{
    public class CatastroController : Controller
    {
        private ServiceCatastro service;

        public CatastroController(ServiceCatastro service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Provincia> provincias = await this.service.GetProvinciasAsync();
            return View(provincias);
        }

        public async Task<IActionResult> Municipios(string provincia)
        {
            List<string> datos =
                await this.service.GetMunicipiosAsync(provincia);
            return View(datos);
        }
    }
}
