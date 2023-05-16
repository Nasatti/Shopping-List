using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    [Table("user", Schema = "peekdeal")]
    public class User
    {
        [Key]
        public long Id_utente { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Email { get; set; }
        public string? Psw { get; set; }
        public long Id_famiglia { get; set; }
    }
}
