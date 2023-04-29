using AutoMapper;
using HelthMind2.Context;
using HelthMind2.Dtos;
using HelthMind2.Model;
using HelthMind2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace HelthMind2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoRepository medicoRepository;
        private IMapper _mapper;


       

        public MedicoController(DataBaseContext context , IMapper mapper)
        {
            medicoRepository = new MedicoRepository(context);
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<MedicoModel>> Get()
        {
            try
            {
                var lista = medicoRepository.Listar();

                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            }

        [HttpPost]
        public ActionResult<MedicoModel> Post([FromBody] CreateMedicoDto medicoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            


            try
            {
                MedicoModel medico = _mapper.Map<MedicoModel>(medicoDto);
                medicoRepository.Inserir(medico);
                var location = new Uri(Request.GetEncodedUrl() + "/" + medico.MedicoId);
                return Created(location, medico);
            }
                catch(Exception error)
            {
                return BadRequest(new { message = $"Não foi possivel{error.Message}" });
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<MedicoModel> Get([FromRoute] int id)
        {
            try
            {
                var medicoModel = medicoRepository.ConsultarPorId(id);

                return Ok(medicoModel);

            }catch (KeyNotFoundException ex) 
            {
                throw ex;
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult AtualizarMedico(int id , [FromBody] MedicoModel medico)
        {
            try
            {
                var medicoModel = medicoRepository.ConsultarPorId(id);
               
                medicoRepository.atualizar(medicoModel);
                return Ok(medicoModel);

            }
            catch(Exception e)
            {
                return NotFound();
            }

            
            
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletarMedico(MedicoModel medicoModel)
        {
            try
            {
                medicoRepository.Excluir(medicoModel);
                return Ok(medicoModel);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
