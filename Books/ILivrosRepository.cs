using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Entities.ExtendedModels;

namespace Books
{
    public interface ILivrosRepository : IRepositoryBase<Livros>
    {
        IEnumerable<Livros> GetAllLivros();
        Livros GetLivrosById(int livroId);
        LivrosExtended GetLivrosWithDetails(int livroId);
    }
}
