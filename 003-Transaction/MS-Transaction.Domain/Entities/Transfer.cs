using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_Transaction.Domain.Entities
{
    [Table("Transfers", Schema = "Toro")]
    public class Transfer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(8), Required]
        public string Event { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public Target Target { get; set; }

        public Origin Origin { get; set; }

        public DateTime? Created { get; set; }
    }
}