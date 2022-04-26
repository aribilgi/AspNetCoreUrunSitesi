using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreUrunSitesi.Models
{
    public class HomePageViewModel // Anasayfada kullanacağımız sayfa modeli
    {
        public List<Slider> Sliders { get; set; } // Anasayfada gösterilecek sliderların listesini tutacak nesnemiz
    }
}
