using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreUrunSitesi.Areas.ApiAdmin.Controllers
{
    [Area("ApiAdmin")] // Adres çubuğunda /ApiAdmin/Home/Index şeklinde istek yapılırsa aşağıdaki action çalışsın
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
