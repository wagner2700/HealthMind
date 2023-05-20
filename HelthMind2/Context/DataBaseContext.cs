
using SistemaApiIdwall.Model;
using Microsoft.EntityFrameworkCore;

namespace SistemaApiIdwall.Context
{
    public class DataBaseContext: DbContext
    {
        
        // Propriedade responsável pelo acesso Medico
        public DbSet<SuspeitosModel> Suspeito { get; set; }

        public DbSet<NacionalidadeModel> Nacionalidade;

        // Propriedade responsável pelo acesso Paciente
        //public DbSet<PacienteModel> paciente { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }
    }
}
