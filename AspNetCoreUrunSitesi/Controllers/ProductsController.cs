using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreUrunSitesi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public ProductsController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index(int? id) // Index action ı id parametresi alabilir ? işareti buranın null olabileceği yani gönderilmeyebileceği anlamına gelir
        {
            if (id != null)
            {
                return View(_productRepository.GetAll(x => x.CategoryId == id));
            }
            return View(_productRepository.GetAll());
        }
    }
}
