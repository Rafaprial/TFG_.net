using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.Models
{
    public class Pegi
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Pegi Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int EdadMax { get; set; }
    }
}
