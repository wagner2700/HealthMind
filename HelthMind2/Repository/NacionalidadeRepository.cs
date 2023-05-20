using SistemaApiIdwall.Context;
using SistemaApiIdwall.Model;

namespace SistemaApiIdwall.Repository
{
    public class NacionalidadeRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public NacionalidadeRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;

        }

        public void InserirNacionalidade(NacionalidadeModel nacionalidadeModel)
        {
            dataBaseContext.Nacionalidade.Add(nacionalidadeModel);
            dataBaseContext.SaveChanges();
        }
    }
}
