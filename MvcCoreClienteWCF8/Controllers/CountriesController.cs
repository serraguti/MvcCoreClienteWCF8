﻿using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF8.Services;
using ServiceCountriesNameSpace;
using System.Runtime.CompilerServices;

namespace MvcCoreClienteWCF8.Controllers
{
    public class CountriesController : Controller
    {
        private ServiceCountries service;

        public CountriesController(ServiceCountries service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            tCountryCodeAndName[] countries =
                await this.service.GetCountriesAsync();
            return View(countries);
        }

        public async Task<IActionResult> Details(string isocode)
        {
            tCountryInfo country = await
                this.service.GetCountryInfoAsync(isocode);
            return View(country);
        }
    }
}
