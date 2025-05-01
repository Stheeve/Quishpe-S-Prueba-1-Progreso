using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quishpe_S_Prueba_1_Progreso.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }
        public string NombreMascota { get; set; }
        public string Raza { get; set; }
        public double Peso { get; set; }
        public double Tamano { get; set; }
        public DateTime FechaNacimiento { get; set;}
        public int IdDueño { get; set; }
        [ForeignKey("IdDueño")]
        public Dueño? Dueño { get; set; }
    }
}
