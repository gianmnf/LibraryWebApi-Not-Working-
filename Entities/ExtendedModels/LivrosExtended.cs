using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace Entities.ExtendedModels
{
    public class LivrosExtended : IEntity
    {
        public IEnumerable<Livros> Livros { get; set; }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public string Tipo { get; set; }
        public string Autor { get; set; }

        public LivrosExtended()
        {
        }

        public LivrosExtended(Livros livros)
        {
            Id = livros.Id;
            Nome = livros.Nome;
            Preco = livros.Preco;
            Tipo = livros.Tipo;
            Autor = livros.Autor;
        }
    }
}
