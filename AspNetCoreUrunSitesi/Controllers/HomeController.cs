using AspNetCoreUrunSitesi.Models;
using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreUrunSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Slider> _sliderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<News> _newsRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<Slider> sliderRepository, IRepository<Product> productRepository, IRepository<News> newsRepository)
        {
            _logger = logger;
            _sliderRepository = sliderRepository;
            _productRepository = productRepository;
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel() // Anasayfa modelimizden bir nesne oluşturduk
            {
                Sliders = _sliderRepository.GetAll(), // Modelimizin içindeki slider listesini doldurduk
                Products = _productRepository.GetAll(),
                News = _newsRepository.GetAll()
            };
            return View(model); // İçini doldurduğumuz modelimizi view a gönderdik
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
