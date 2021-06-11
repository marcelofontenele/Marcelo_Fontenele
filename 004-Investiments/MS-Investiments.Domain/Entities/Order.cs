using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_Investiments.Domain.Entities
{
    [Table("Orders", Schema = "Toro")]
    public class Order
    {
        public int Id { get; set; }

        [MaxLength(8), Required]
        public int Amount { get; set; }

        [Required]
        public decimal Value { get; set; }

        [MaxLength(8), Required]
        public string Symbol { get; set; }

        [ForeignKey("AccountId")]
        public int AccountId { get; set; }

        public Account Account { get; set; }

        [NotMapped]
        public int UserId { get; set; }

        public DateTime? Created { get; set; }
    }
}