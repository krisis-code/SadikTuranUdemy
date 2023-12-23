using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{

    public class KursKayit
    {
        [Key]
        public int KayitId { get; set; }

        public int? OgrenciId { get; set; }

        public Ogrenci ogrenci { get; set; } = null!;

        public int? KursId { get; set; }

        public Kurs kurs { get; set; } = null!;
        public DateTime KayitTarihi { get; set; }
       
    
    }

}