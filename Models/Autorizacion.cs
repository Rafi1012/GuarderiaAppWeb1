using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuarderiaAppWeb.Models
{
    public class Autorizacion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdAutorizado { get; set; }
        
        public int Matricula { get; set; }

        public string Nombre { get; set; } 

        public string Apellido{ get; set; }

        public string Cedula {  get; set; }

        public string Direccion { get; set;}

        public string Telefono {  get; set; }

        public string Relacion { get; set; }

        public bool Recoger { get; set;}=false;

        public List<nino> Ninos { get; set; } // Lista de Niños asociados a la Autorización
                                              //public nino? Nino { get; set; }

        public List<Pago>? Pago { get; set; }


    }
}
