using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_Auth.Domain.Entities
{
    [Table("Users", Schema = "Toro")]
    public class User
    {
        public int Id { get; set; }

        [MaxLength(11), Required]
        public string CPF { get; set; }

        [MaxLength(32), Required]
        public string Login { get; set; }

        [MaxLength(64), Required]
        public string Name { get; set; }

        [MaxLength(32), Required]
        public string Password { get; set; }

        [DefaultValue(1)]
        public bool Active { get; set; }
    }
}