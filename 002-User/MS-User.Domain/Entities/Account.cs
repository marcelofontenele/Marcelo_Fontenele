using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_User.Domain.Entities
{
    [Table("Accounts", Schema = "Toro")]
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public decimal AccountAmount { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public IList<Stock> Positions { get; set; }
    }
}