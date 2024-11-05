using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_WEB_MARTE.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Resposta1")]
        [Display(Name = "Resposta1")]
        [Required(ErrorMessage = "Resposta1 é obrigatória.")]
        [StringLength(50, ErrorMessage = "A Resposta1 não pode exceder 50 caracteres.")]
        public string Resposta1 { get; set; }

        [Column("Resposta2")]
        [Display(Name = "Resposta2")]
        [Required(ErrorMessage = "Resposta2 é obrigatória.")]
        [StringLength(50, ErrorMessage = "A Resposta2 não pode exceder 50 caracteres.")]
        public string Resposta2 { get; set; }

        [Column("Resposta3")]
        [Display(Name = "Resposta3")]
        [Required(ErrorMessage = "Resposta3 é obrigatória.")]
        [StringLength(50, ErrorMessage = "A Resposta3 não pode exceder 50 caracteres.")]
        public string Resposta3 { get; set; }

        [Column("Sugestao")]
        [Display(Name = "Sugestão")]
        [StringLength(200, ErrorMessage = "A Sugestão não pode exceder 200 caracteres.")]
        public string Sugestao { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        public string Email { get; set; }
    }
}
