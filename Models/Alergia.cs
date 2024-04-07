using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuarderiaAppWeb.Models
{
    public class Alergia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdAlergia { get; set; }


        public int Matricula {  get; set; }

        public int IdMenu { get; set; }

      
        public nino? Nino { get; set; }
        public List<Menu>? Menus { get; set; }

    }
}