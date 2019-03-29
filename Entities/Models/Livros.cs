using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Livros")]
    public class Livros
    {
        public int LivroId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo nome não pode passar de 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        public float Preco { get; set; }

        [Required(ErrorMessage ="Tipo é obrigatório")]
        [StringLength(80, ErrorMessage = "O campo tipo não pode passar de 80 caracteres")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Autor é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo autor não pode passar de 100 caracteres")]
        public string Autor { get; set; }
    }
}
