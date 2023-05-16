using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    [Table("family", Schema = "peekdeal")]
    public class Family
    {
        [Key]
        public long Id_famiglia { get; set; }
        public string? Nome { get; set; }
    }
}
