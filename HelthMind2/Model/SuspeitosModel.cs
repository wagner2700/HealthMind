using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaApiIdwall.Model
{
    [Table("PESSOAS")]
    public class SuspeitosModel
    {
        [Key]
        [Column("SUSPEITOID")]
        public int SuspeitoId { get; set; }

        [Column("NOMESUSPEITO")]
        public string NomeSuspeito { get; set; }

        // [Column("DataNacimento")]
        // public DateTime DataNascimento { get; set; }
        [Column("CLASSIFICACAO")]
        public string Classificacao { get; set; }

        [Column("SEXO")]
        public string Sexo { get; set; }

        [ForeignKey("NacionalidadeModel")]
        public string NacionalidadeId { get; set; }
        public virtual NacionalidadeModel NacionalidadeModel { get; set; }

        public SuspeitosModel(int suspeitoId, string nomeSuspeito, string classificacao, string sexo, string nacionalidadeId)
        {
            SuspeitoId = suspeitoId;
            NomeSuspeito = nomeSuspeito;
            Classificacao = classificacao;
            Sexo = sexo;
            NacionalidadeId = nacionalidadeId;
        }
    }

}

