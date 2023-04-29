using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelthMind2.Dtos
{
    public class UpdatePacienteDto
    {
       

        public string NomeMedico { get; set; }

        public string Cpf { get; set; }

        public string Especialidade { get; set; }

        
        public string CRMMedico { get; set; }
    }
}
