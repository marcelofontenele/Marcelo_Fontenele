using System.ComponentModel.DataAnnotations.Schema;

namespace MS_User.Domain.Entities
{
    [NotMapped]
    public class AccountTransaction
    {
        public int AccountId { get; set; }

        public decimal Value { get; set; }

        public Stock Stock { get; set; }
    }
}