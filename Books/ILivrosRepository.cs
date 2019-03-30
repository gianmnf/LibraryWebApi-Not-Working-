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
        Livros GetLivrosById(Guid livroId);
        LivrosExtended GetLivrosWithDetails(Guid livroId);
        void CreateLivros(Livros livros);
        void UpdateLivros(Livros dbLivros, Livros livros);
        void DeleteLivros(Livros livros);
    }
}
