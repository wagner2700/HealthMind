using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelthMind2.Dtos
{
    public class CreatePacienteDto
    {

        public string Nome { get; set; }

       
        public string CpfPaciente { get; set; }


       
        public string Estado { get; set; }


        public int MedicoId { get; set; }
    }
}
