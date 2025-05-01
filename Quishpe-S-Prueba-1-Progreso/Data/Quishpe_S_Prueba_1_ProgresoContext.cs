using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quishpe_S_Prueba_1_Progreso.Models;

namespace Quishpe_S_Prueba_1_Progreso.Data
{
    public class Quishpe_S_Prueba_1_ProgresoContext : DbContext
    {
        public Quishpe_S_Prueba_1_ProgresoContext (DbContextOptions<Quishpe_S_Prueba_1_ProgresoContext> options)
            : base(options)
        {
        }

        public DbSet<Quishpe_S_Prueba_1_Progreso.Models.Dueño> Dueño { get; set; } = default!;
        public DbSet<Quishpe_S_Prueba_1_Progreso.Models.Mascota> Mascota { get; set; } = default!;
    }
}
