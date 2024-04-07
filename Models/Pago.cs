using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuarderiaAppWeb.Models
{
    public class Pago
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdPago { get; set; }
        public int IdAutorizado { get; set; }
        public int Nofactura { get; set; }
        public int Nocuenta { get; set; }   

        public int Costo { get; set; }

        public int Monto { get; set;}

       public Autorizacion Autorizacion{  get; set; }

        public List<CargoMensual>? CargoMensuales { get; set; }

        //public CargoMensual CargoMensual { get; set; }





    }
}
