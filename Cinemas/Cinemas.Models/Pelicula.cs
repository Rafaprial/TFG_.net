using DataAnnotationsExtensions;
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
    public class Pelicula
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Director { get; set; }
        [DataType(DataType.Date)]

        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1, 20)]
        public double Price { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        [ValidateNever]
        public Categoria Categoria { get; set; }
        [Required]
        [Display(Name = "Pegi")]
        public int PegiId { get; set; }
        [ValidateNever]
        public Pegi Pegi { get; set; }


    }
}
