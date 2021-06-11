using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_Investiments.Domain.Entities
{
    [Table("Stocks", Schema = "Toro")]
    public class Stock
    {
        public int Id { get; set; }

        [MaxLength(8), Required]
        public string Symbol { get; set; }

        [Required]
        public decimal CurrentPrice { get; set; }
    }
}