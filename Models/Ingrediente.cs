using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuarderiaAppWeb.Models
{
    public class Ingrediente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdIngrediente { get; set; }
        
        public string NomIngrediente { get; set; }

        public int IdMenu { get; set; }

        public List<Menu>? Menu { get; set; }
        // public Menu? Menu { get; set; }

    } 
}
