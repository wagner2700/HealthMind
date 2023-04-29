using System.ComponentModel.DataAnnotations;

namespace HelthMind2.Dtos
{
    public class CreateCienamDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
