using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace GuarderiaAppWeb.Models
{
    public class Consumo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdConsumo { get; set; }
        public DateTime Fecha { get; set; }= DateTime.Now;

        public int Matricula { get; set; }
        public int IdMenu { get; set; }
        public int Total {  get; set; }

        public nino? Nino { get; set; } 
        
       public List<Menu> Menu { get; set;}

        //public CargoMensual? CargoMensual { get; set; }


    }
}
