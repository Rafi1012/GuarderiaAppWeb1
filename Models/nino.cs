using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GuarderiaAppWeb.Models
{
    public class nino
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Matricula { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; } = DateTime.Today;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaSalida { get; set; }

        public List<Autorizacion>? Autorizacion { get; set; }
        public List<Alergia>? Alergia { get; set; }
        public List<Consumo>? Consumo { get; set; }
        public List<CargoMensual>? CargoMensual { get; set; }


    }
}
