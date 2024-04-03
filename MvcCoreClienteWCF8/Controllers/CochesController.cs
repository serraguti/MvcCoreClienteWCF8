using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF8.Services;
using ServiceReferenceCoches;

namespace MvcCoreClienteWCF8.Controllers
{
    public class CochesController : Controller
    {
        private ServiceCoches service;

        public CochesController(ServiceCoches service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            Coche[] cars = await this.service.GetCochesAsync();
            return View(cars);
        }

        public async Task<IActionResult> Details(int idcoche)
        {
            Coche car = await this.service.FindCocheAsync(idcoche);
            return View(car);
        }
    }
}
