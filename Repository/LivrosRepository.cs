using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Books;
using Entities;
using Entities.ExtendedModels;
using Entities.Extensions;
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

        public Livros GetLivrosById(Guid livrosId)
        {
            return FindByCondition(livros => livros.Id.Equals(livrosId))
                .DefaultIfEmpty(new Livros())
                .FirstOrDefault();
        }

        public LivrosExtended GetLivrosWithDetails(Guid livroId)
        {
            return new LivrosExtended(GetLivrosById(livroId))
            {
                Livros = RepositoryContext.Livros
                        .Where(li => li.LivroId == livroId)
            };

        }

        public void CreateLivros(Livros livros)
        {
            livros.Id = Guid.NewGuid();
            Create(livros);
            Save();
        }

        public void UpdateLivros(Livros dbLivros, Livros livros)
        {
            dbLivros.Map(livros);
            Update(dbLivros);
            Save();
        }

        public void DeleteLivros(Livros livros)
        {
            Delete(livros);
            Save();
        }
    }
}
