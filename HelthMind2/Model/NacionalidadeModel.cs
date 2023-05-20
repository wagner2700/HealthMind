
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaApiIdwall.Model
{
    [Table("TB_NACIONALIDADES")]
    public class NacionalidadeModel
    {

        [Key]
        [Column("NACIONALIDADEID")]
        public string NacionalidadeId { get; set; }

        [Column("NACIONALIDADEDESC")]
        public string NacionalidadeDesc { get; set; }
        //[ForeignKey("SuspeitoModel")]
        //public virtual SuspeitosModel SuspeitosModel { get; set; }

        public NacionalidadeModel(string nacionalidadeId, string nacionalidadeDesc)
        {
            NacionalidadeId = nacionalidadeId;
            NacionalidadeDesc = nacionalidadeDesc;
        }
    }
}
