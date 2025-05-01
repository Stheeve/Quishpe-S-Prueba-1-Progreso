using System.ComponentModel.DataAnnotations.Schema;


namespace Quishpe_S_Prueba_1_Progreso.Models
{
    public class Visita
    {
        public int Id { get; set; } 
        public DateTime FechaVisita { get; set; }
        public MotivoVisita Motivo { get; set; } 
        public int Tarifa { get
            {
                return Motivo switch
                {
                    MotivoVisita.Vacunacion => 30,
                    MotivoVisita.RevisionGeneral => 20,
                    MotivoVisita.Cirujia => 100,
                    _ => 0
                };
            }
        }
        public Boolean RequiereMedicacion {  get; set; }
        public int IdMascota { get; set; }
        [ForeignKey("IdMascota")]
        public Mascota? Mascota { get; set; }    
    }
    public enum MotivoVisita
    {                    
        Vacunacion,
        RevisionGeneral,
        Cirujia
    }
}
