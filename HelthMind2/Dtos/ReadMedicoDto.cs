using System.ComponentModel.DataAnnotations.Schema;

namespace HelthMind2.Dtos
{
    public class ReadMedicoDto
    {
        public int MedicoId { get; set; }

        public string NomeMedico { get; set; }

        public string Cpf { get; set; }

       
        public string Especialidade { get; set; }


        public string CRMMedico { get; set; }
    }
}
