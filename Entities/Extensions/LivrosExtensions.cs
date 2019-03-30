using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class LivrosExtensions
    {
        public static void Map(this Livros dbLivros, Livros livros)
        {
            dbLivros.Nome = livros.Nome;
            dbLivros.Preco = livros.Preco;
            dbLivros.Tipo = livros.Tipo;
            dbLivros.Autor = livros.Autor;
      
        }
    }
}
