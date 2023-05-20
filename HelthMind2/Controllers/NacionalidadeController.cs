

using SistemaApiIdwall.Context;
using SistemaApiIdwall.Model;
using SistemaApiIdwall.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;

namespace SistemaApiIdwall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NacionalidadeController : ControllerBase
    {
        private readonly NacionalidadeRepository nacionalidadeRepository;
        public NacionalidadeController(DataBaseContext dataBaseContext)
        {
            nacionalidadeRepository = new NacionalidadeRepository(dataBaseContext);
        }

        [HttpPost]
        public ActionResult<NacionalidadeModel> Post([FromBody] NacionalidadeModel nacionalidadeModel)
        {
            try
            {
                nacionalidadeRepository.InserirNacionalidade(nacionalidadeModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + nacionalidadeModel.NacionalidadeId);
                return Created(location, nacionalidadeModel);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

    }  
}
