
using Microsoft.EntityFrameworkCore;
using SistemaApiIdwall.Context;

namespace SistemaApiIdwall.Model
{
    public class SuspeitoRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public SuspeitoRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;


        }
        public IList<SuspeitosModel> ListarTodos()
        
        {
            var Lista = new List<SuspeitosModel>();
            Lista = dataBaseContext.Suspeito.ToList<SuspeitosModel>();
            return Lista;

        }

        // Inserir registro de suspeito
        public void Inserir(SuspeitosModel suspeitosModel)
        {
            dataBaseContext.Suspeito.Add(suspeitosModel);
            dataBaseContext.SaveChanges();
        }

        // Consultar suspeito pelo nome
        public SuspeitosModel ConsultarPorNome(string nomePesquisa)
        {
            var suspeito = dataBaseContext.Suspeito.Where(r => r.NomeSuspeito.Contains(nomePesquisa)).FirstOrDefault<SuspeitosModel>();

            return suspeito;
        }


        // Pesquisr por classificação de Suspeito - Red | Yellow | Un
        public IList<SuspeitosModel> ConsultarPorClassificação(string classificacaoPesquisa)
        {



            var lista = dataBaseContext.Suspeito.Where(r => r.Classificacao == classificacaoPesquisa).ToList();
            return lista;
        }

        public IList<SuspeitosModel> ListarPorNacionalidade(string nacionalidadePesquisa)
        {
            var lista = dataBaseContext.Suspeito.Where(r => r.NacionalidadeId == nacionalidadePesquisa).ToList();

            return lista;
        }


        public int QtdadeTotal()
        {
            return dataBaseContext.Set<SuspeitosModel>().Count();
        }
    }
}
