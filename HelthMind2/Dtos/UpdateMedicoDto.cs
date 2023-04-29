using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelthMind2.Dtos
{
    public class UpdateMedicoDto
    {
        [Column("NOMEMEDICO")]
        public string NomeMedico { get; set; }

        [Column("CPF")]
        [StringLength(12 , ErrorMessage = "Necessário minimo 12 caracteres")]
        public string Cpf { get; set; }

        [Column("ESPECIALIDADE")]
        public string Especialidade { get; set; }

        //[Column("DATANASCIMENTO")]
        //public Calendar DataNacimento { get; set; }

        [Column("CRM")]
        public string CRMMedico { get; set; }
    }
}
