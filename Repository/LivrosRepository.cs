using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Books;
using Entities;
using Entities.ExtendedModels;
using Entities.Models;

namespace Repository
{
    public class LivrosRepository : RepositoryBase<Livros>, ILivrosRepository
    {
        public LivrosRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {       
        }

        public IEnumerable<Livros> GetAllLivros()
        {
            return FindAll()
                .OrderBy(li => li.Nome);
        }

        public Livros GetLivrosById(int livrosId)
        {
            return FindByCondition(livros => livros.Id.Equals(livrosId))
                .DefaultIfEmpty(new Livros())
                .FirstOrDefault();
        }

        public LivrosExtended GetLivrosWithDetails(int livroId)
        {
            return new LivrosExtended(GetLivrosById(livroId))
            {
                Livros = RepositoryContext.Livros
                        .Where(li => li.Id == livroId)
            };

        }
    }
}
