using System;
using System.Collections.Generic;
using System.Text;
using Books;
using Entities;
using Entities.Models;

namespace Repository
{
    public class LivrosRepository : RepositoryBase<Livros>, ILivrosRepository
    {
        public LivrosRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {       
        }
    }
}
