using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_Transaction.Domain.Entities
{
    [Table("Accounts", Schema = "Toro")]
    public class Account
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime? Created { get; set; }
    }
}