using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Models
{
    [Table("Vuelo")]
    public class Vuelo
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Origen { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Destino { get; set; }

        [Column(TypeName = "varchar")]
        [Range(100,1000)]
        public string Matricula { get; set; }
    }
}