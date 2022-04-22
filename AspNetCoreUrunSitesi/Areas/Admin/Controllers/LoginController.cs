using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreUrunSitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IRepository<AppUser> _repository;

        public LoginController(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AppUser appUser)
        {
            try
            {
                var account = _repository.Get(x => x.Username == appUser.Username & x.Password == appUser.Password & x.IsActive & x.IsAdmin);
                if (account == null) // Girilen bilgilere göre eşleşen kayıt yoksa
                {
                    ModelState.AddModelError("", "Giriş Başarısız!");
                }
                else
                {

                }
            }
            catch (Exception hata)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View();
        }
    }
}
