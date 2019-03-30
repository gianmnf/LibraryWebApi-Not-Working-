using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public interface IRepositoryWrapper
    {
        ILivrosRepository Livros { get; }
    }
}
