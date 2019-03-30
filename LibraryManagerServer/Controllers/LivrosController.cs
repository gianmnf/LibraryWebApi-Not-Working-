using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Books;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagerServer.Controllers
{
    [Route("api/livros")]
    public class LivrosController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public LivrosController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllLivros()
        {
            try
            {
                var livros = _repository.Livros.GetAllLivros();
                _logger.LogInfo($"Retornou todos os livros do banco de dados");
                return Ok(livros);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Algo deu na ação GetAllLivros: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetLivrosById(int id)
        {
            try
            {
                var livros = _repository.Livros.GetLivrosById(id);
                if (livros == null)
                {
                    _logger.LogError($"Livro com o id: {id} não foi encontrado.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Livro com o id: {id} foi encontrado.");
                    return Ok(livros);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu na ação GetLivrosById: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpGet("{id}/details")]
        public IActionResult GetLivrosWithDetails(int id)
        {
            try
            {
                var livros = _repository.Livros.GetLivrosWithDetails(id);
                if (livros == null)
                {
                    _logger.LogError($"Livro com o id: {id} não foi encontrado.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Livro com o id: {id} foi encontrado.");
                    return Ok(livros);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu na ação GetLivrosWithDetails: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }
    }
}
