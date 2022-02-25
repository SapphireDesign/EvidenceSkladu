using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EvidenceSkladu.Models
{
    public class Produkt
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nazev { get; set; }
        [DisplayName("Počet kusů")]
        public int PocetProduktu { get; set; }
        public DateTime CreatedDataTime { get; set; } = DateTime.Now;
    }
}


