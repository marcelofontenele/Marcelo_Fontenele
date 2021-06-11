using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_User.Domain.Entities
{
    [Table("Stocks", Schema = "Toro")]
    public class Stock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(8), Required]
        public string Symbol { get; set; }

        [Required]
        public int Amount { get; set; }

        public int AccountId { get; set; }

        [Required]
        public decimal CurrentPrice { get; set; }
    }
}