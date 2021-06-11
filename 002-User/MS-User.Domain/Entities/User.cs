using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS_User.Domain.Entities
{
    [Table("Users", Schema = "Toro")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(11), Required]
        public string CPF { get; set; }

        [MaxLength(128), Required]
        public string Name { get; set; }
    }
}