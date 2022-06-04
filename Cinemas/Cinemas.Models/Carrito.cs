using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.Models
{
    public class Carrito
    {
        public int Id { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Pelicula Pelicula { get; set; }
        public int PeliculaId { get; set; }
        [Range(1, 20, ErrorMessage = "Solo se pueden comprar 20 entradas a la vez")]
        public int Count { get; set; }
    }
}
