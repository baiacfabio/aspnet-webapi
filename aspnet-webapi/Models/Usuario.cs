using System;
using System.ComponentModel.DataAnnotations;

namespace aspnet_webapi.Models
{
    public class Usuario : ModelBase
    {
        const string MSG_CAMPO_OBRIGATORIO = "Este campo é obrigatório.";

        [Required(ErrorMessage = MSG_CAMPO_OBRIGATORIO)]
        [MinLength(3, ErrorMessage = "Este campo deve possuir ao menos 3 caracteres.")]
        [MaxLength(255, ErrorMessage = "Este campo deve possuir no máximo 255 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = MSG_CAMPO_OBRIGATORIO)]
        [MaxLength(150, ErrorMessage = "Este campo deve ter no máximo 150 caracteres.")]
        public string Email { get; set; }
        public int Idade { get; set; }

        [Required(ErrorMessage = MSG_CAMPO_OBRIGATORIO)]
        public DateTime? DataNascimento { get; set; }
    }
}