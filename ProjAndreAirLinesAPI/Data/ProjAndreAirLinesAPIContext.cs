using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjAndreAirLinesAPI.Model;

namespace ProjAndreAirLinesAPI.Data
{
    public class ProjAndreAirLinesAPIContext : DbContext
    {
        public ProjAndreAirLinesAPIContext (DbContextOptions<ProjAndreAirLinesAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProjAndreAirLinesAPI.Model.Endereco> Endereco { get; set; }

        public DbSet<ProjAndreAirLinesAPI.Model.Passageiro> Passageiro { get; set; }

        public DbSet<ProjAndreAirLinesAPI.Model.Aeronave> Aeronave { get; set; }

        public DbSet<ProjAndreAirLinesAPI.Model.Aeroporto> Aeroporto { get; set; }

        public DbSet<ProjAndreAirLinesAPI.Model.Voo> Voo { get; set; }
    }
}
