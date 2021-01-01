using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academia.Dominio.Models
{
    public class CategoriaExercicio
    {
        public int CategoriaExercicioId { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        [Remote("CategoriaExiste", "CategoriasExercicios", AdditionalFields = "CategoriaExercicioId")]
        public string Nome { get; set; }

        public ICollection<Exercicio> Exercicios { get; set; }
    }
}