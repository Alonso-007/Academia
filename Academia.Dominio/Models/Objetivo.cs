using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academia.Dominio.Models
{
    public class Objetivo
    {
        public int ObjetivoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        [Remote("ObjetivoExiste", "Objetivos", AdditionalFields = "ObjetivoId")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(500, ErrorMessage = "Use menos caracteres")]
        public string Descricao { get; set; }

        public ICollection<Aluno> Alunos { get; set; }
    }
}