using System.ComponentModel.DataAnnotations.Schema;

namespace Quishpe_S_Prueba_1_Progreso.Models
{
    public class Visita
    {
        public int Id { get; set; } 
        public DateTime FechaVisita { get; set; }
        public string Motivo { get; set; } 
        public int Tarifa { get; set; }
        public Boolean RequiereMedicacion {  get; set; }
        public int IdMascota { get; set; }
        [ForeignKey("IdMascota")]
        public Mascota Mascota { get; set; }    
    }
}
