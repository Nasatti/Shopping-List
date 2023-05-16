using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    [Table("article", Schema = "peekdeal")]
    public class Article
    {
        [Key]
        public long Id_articolo { get; set; }
        public string? Articolo { get; set; }
        public long Id_spesa { get; set; }
        public int Quantità { get; set; }
        public bool Acquistato { get; set; }

    }
}
