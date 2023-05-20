using SistemaApiIdwall.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;




namespace SistemaApiIdwall.Model

{
    [Route("api/[controller]")]
    [ApiController]
    public class SuspeitosController : ControllerBase
    {
        private readonly SuspeitoRepository suspeitoRepository;

        public SuspeitosController(DataBaseContext dataBaseContext)
        {
            suspeitoRepository = new SuspeitoRepository(dataBaseContext);
        }

        [HttpGet]
        public ActionResult<List<SuspeitosModel>> Get()
        {
            try
            {
                var Lista = suspeitoRepository.ListarTodos();
                if (Lista != null)
                {
                    return Ok(Lista);

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<SuspeitosModel> Post([FromRoute] SuspeitosModel suspeitosModel)
        {
            try
            {
                suspeitoRepository.Inserir(suspeitosModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + suspeitosModel.SuspeitoId);
                return Created(location, suspeitosModel);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpGet("{nome:alpha}")]
        public ActionResult<SuspeitosModel> Get(string nome)
        {
            try
            {
                var pessoa = suspeitoRepository.ConsultarPorNome(nome);


                return Ok(pessoa); // Retorna HTTP 200 com o objeto pessoa


            }
            catch (Exception ex)
            {
                //Loga a exceção para fins de depuração
                Console.WriteLine(ex);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{classificacao:alpha}")]
        public ActionResult<IList<SuspeitosModel>> getbyclassificacao(string classificacao)
        {
            try
            {
                var lista = suspeitoRepository.ConsultarPorClassificação(classificacao);

                if (lista == null)
                {
                    return NotFound(); // retorna http 404 se a pessoa não for encontrada
                }

                return Ok(lista); // retorna http 200 com o objeto pessoa
            }
            catch (Exception ex)
            {
                //Loga a exceção para fins de depuração
                Console.WriteLine(ex);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{nacionalidade:alpha}")]
        public ActionResult<List<SuspeitosModel>> GetByNacionalidade(string nacionalidade)
        {
            var lista = suspeitoRepository.ListarPorNacionalidade(nacionalidade);

            return Ok(lista);
        }

        [HttpGet("/contagemTotal")]
        public ActionResult<int> ContarOcorrencias()
        {
            try
            {
                int QtdOcorrencias = suspeitoRepository.QtdadeTotal();
                return Ok(QtdOcorrencias);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



    }
}
