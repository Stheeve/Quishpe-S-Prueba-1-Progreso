using System.ComponentModel.DataAnnotations;

namespace Quishpe_S_Prueba_1_Progreso.Models
{
    public class Dueño
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(55)]
        public string Nombre { get; set; }
        [MaxLength(10)]
        public string Telefono { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(1, 10)]
        public int NumMascotas { get; set; }
        public Boolean MasdeUnaMascota
        {
            get
            {
                if (NumMascotas >= 1)
                {
                    return true;
                }
                return false;
            }
        }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public double IngresoMensual {  get; set; }

    }
}
