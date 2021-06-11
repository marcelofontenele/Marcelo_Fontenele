using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_Transaction.Domain.Entities
{
    [Table("Transfers_Origins", Schema = "Toro")]
    public class Origin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(4), Required]
        public string Bank { get; set; }

        [MaxLength(6), Required]
        public string Branch { get; set; }

        [MaxLength(11), Required]
        public string CPF { get; set; }

        public DateTime? Created { get; set; }
    }
}