using Healy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Healy_API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<ProfissionalSaude> ProfissionaisSaude { get; set; }
        public DbSet<Exame> Exames { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("Data Source=oracle.fiap.com.br:1521/orcl;User ID=username;Password=password");
        }
    }
}
