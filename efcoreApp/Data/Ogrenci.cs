using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }

        public string? OgranciAd { get; set; }

        public string? OgranciSoyad { get; set; }

        public string AdSoyad
        {
            get
            {
                return this.OgranciAd + " " + this.OgranciSoyad;
            }
        }
        public string? Eposta { get; set; }
  
        public string? Telefon { get; set; }
    }
}