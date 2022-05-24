using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net; // Api işlemleri için gerekli kütüphane
using System.Net.Http; // Aşağıdaki IHttpClientFactory interface ini kullanabilmek için
using System.Text; // Api işlemlerinde gerekli
using System.Threading.Tasks;
using Newtonsoft.Json; // Bu paketi nuget tan yüklüyoruz. String verileri Json formatına, Json formatındaki verileri de string formata çevirmemizi sağlıyor
using Entities;

namespace AspNetCoreUrunSitesi.Areas.ApiAdmin.Controllers
{
    [Area("ApiAdmin")]
    public class AppUserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        string apiAdres = "https://localhost:44395/api/AppUsers";
        public AppUserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: AppUserController
        public async Task<ActionResult> IndexAsync()
        {
            var client = _httpClientFactory.CreateClient(); // Api işlemleri için bir kullanıcı oluşturduk
            var responseMessage = await client.GetAsync(apiAdres); // API mize istek yapıyoruz
            if (responseMessage.IsSuccessStatusCode) // api ye yaptığımız isteğin sonucu başarılıysa
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // responseMessage içeriğini json olarak okuyoruz
                var result = JsonConvert.DeserializeObject<List<AppUser>>(jsonData); // aldığımız jsondata yı List<AppUser> ile AppUser listesine çeviriyoruz convert metoduyla
                return View(result); // Sayfa modelimiz olan appuser listesine çevirdiğimiz modeli view a gönderiyoruz
            }
            return View(null); // eğer yukardaki işlem başarısızsa null değer döndürüyoruz
        }

        // GET: AppUserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(appUser); // parametreden gelen appUser nesnesini json a newtonsoft ile dönüştürdük
                    StringContent stringContent = new(jsonData, encoding: Encoding.UTF8, mediaType: "application/json"); // stringContent nesnesi oluşturup içine json a dönüştürdüğümüz appUser nesnesini attık ve encoding ile kodlama türünü UTF8 olarak ayarladık, mediaType kısmında ise bu nesnenin veri türünün json olduğunu belirttik.
                    var responseMessage = await client.PostAsync(apiAdres, stringContent); // client ın PostAsync metodu ile api mize post isteği yaptık
                    if (responseMessage.IsSuccessStatusCode) // eğer post isteğimiz başarılıysa
                    {
                        return RedirectToAction(nameof(Index)); // sayfayı listelemeye yönlendir
                    }
                    else ModelState.AddModelError("", $"Post İsteğinde Hata Oluştu! Hata Kodu : {(int)responseMessage.StatusCode}"); // postta hata olursa ne hatası aldığımızı görmek için
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(appUser);
        }

        // GET: AppUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AppUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppUserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
