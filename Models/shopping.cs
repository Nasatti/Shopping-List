using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    [Table("shopping", Schema = "peekdeal")]
    public class Shopping
    {
        [Key]
        public long Id_spesa { get; set; }
        public DateTime Data { get; set; }
        public long Id_famiglia { get; set; }
    }
}
