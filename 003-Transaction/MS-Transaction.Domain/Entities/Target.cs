using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_Transaction.Domain.Entities
{
    [Table("Targets", Schema = "Toro")]
    public class Target
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(4), Required]
        public string Bank { get; set; }

        [MaxLength(6), Required]
        public string Branch { get; set; }

        [MaxLength(16), Required]
        public string Account { get; set; }

        public DateTime? Created { get; set; }
    }
}