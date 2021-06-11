using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_Transaction.Domain.Entities
{
    [Table("Users", Schema = "Toro")]
    public class User
    {
        public int Id { get; set; }

        [MaxLength(11), Required]
        public string CPF { get; set; }

        public DateTime? Created { get; set; }
    }
}