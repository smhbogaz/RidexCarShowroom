using System.ComponentModel.DataAnnotations;

namespace Ridex_Car_Showroom.DAL
{
    public class Cars
    {
        [Key]
        public int Id { get; set; }
        public int KisiSayisi { get; set; }
        public string? YakitTipi { get; set; }
        public string? VitesTipi { get; set; }
        public int UretimYili { get; set; }
        public string? Marka { get; set; }
        public string? Model { get; set; }
        public int Fiyat { get; set; }
        public string? Resim { get; set; }
        public string? IlanTarihi { get; set; }
        public int IlanSahibiID { get; set; }
    }
}
