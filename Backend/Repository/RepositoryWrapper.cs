using System;
using System.Collections.Generic;
using System.Text;
using Books;
using Entities;

namespace Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ILivrosRepository _livros;

        public ILivrosRepository Livros
        {
            get
            {
                if(_livros == null)
                {
                    _livros = new LivrosRepository(_repoContext);
                }

                return _livros;
            }

        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
 
    }
}
