using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelthMind2.Dtos
{
    public class ReadPacienteDto
    {

        public string Nome { get; set; }


        public string CpfPaciente { get; set; }


      
        public string Estado { get; set; }


        public ReadMedicoDto ReadMedicoDto { get; set; }
    }
}
