using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DateEvento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
         //MinLength(03, ErrorMessage = "{0} deve conter no mínimo 03 caracteres"),
         //MaxLength(50, ErrorMessage = "{0} deve conter no mínimo 50 caracteres")
         StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo entre 3 e 50 caracteres")
        ]
        public string Tema { get; set; }
        
        [Range(10, 1000, ErrorMessage = "Não pode ser menor que 10 e maior que 1000")]
        public int QtdPessoas { get; set; }
        
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida")]
        public string ImagemURL { get; set; }
        
        [Required(ErrorMessage = "o campo {0} deve ser preenchido")]
        [Phone(ErrorMessage ="O campo {0} deve conter um número válido")]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "O campo {0} deve ser obrigatório"),
         Display(Name = "e-Mail"),
         EmailAddress(ErrorMessage ="O o campo {0} deve ser um e-mail válido!")
        ]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedeSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}
