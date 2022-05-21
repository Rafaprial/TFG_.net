using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinemas.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El valor de Nombre tiene que ser valido")]
        public string Name { get; set; }
        /*[Validation(ErrorMessage ="Error")]*/
        /*[DisplayName("Orden")]*/

        [Range(1, 199, ErrorMessage = "El rango  debe de estar entre 1 y 199")]
        public int Orden { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
