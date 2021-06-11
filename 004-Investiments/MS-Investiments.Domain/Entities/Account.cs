using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_Investiments.Domain.Entities
{
    [Table("Accounts", Schema = "Toro")]
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public decimal AccountAmount { get; set; }

        public int UserId { get; set; }

        public DateTime? Created { get; set; }
    }
}