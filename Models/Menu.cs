using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuarderiaAppWeb.Models
{
    public class Menu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdMenu { get; set; }

        public string NomPlato { get; set; }
         
        public int Costo {  get; set; }

      public List<Ingrediente>? Ingrediente { get; set;}

               
      public Alergia? Alergia { get; set; }

        
       public Consumo? Consumo { get; set; }
    }
}
