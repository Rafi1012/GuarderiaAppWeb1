using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuarderiaAppWeb.Models
{
    public class CargoMensual
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int NoFactura { get; set; }
        public DateTime Fecha { get; set; }= DateTime.Now;
        
        public int Matricula {  get; set; }= 0;
        
        public int CostoFijo { get; set; }

        public int TotalConsumo { get; set; }

        public int Total { get; set; }

        public bool Estado { get; set; } = false;

        

        //public List<Consumo>? Consumo { get; set; }    
        public nino? Nino { get; set; } 
        public Pago? Pago { get; set; }
    }
}