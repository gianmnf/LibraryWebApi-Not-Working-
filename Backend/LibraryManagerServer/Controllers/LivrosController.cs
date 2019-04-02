using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Books;
using Entities.Models;
using Entities.Extensions;

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
                _logger.LogError($"Algo deu errado na ação GetAllLivros: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpGet("{id}", Name = "LivrosById")]
        public IActionResult GetLivrosById(Guid id)
        {
            try
            {
                var livros = _repository.Livros.GetLivrosById(id);
                if (livros.IsEmptyObject())
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
                _logger.LogError($"Algo deu errado na ação GetLivrosById: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpGet("{id}/details")]
        public IActionResult GetLivrosWithDetails(Guid id)
        {
            try
            {
                var livros = _repository.Livros.GetLivrosWithDetails(id);
                if (livros.IsEmptyObject())
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
                _logger.LogError($"Algo deu errado na ação GetLivrosWithDetails: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPost]
        public IActionResult CreateLivros([FromBody]Livros livros)
        {
            try
            {
                if (livros.IsObjectNull())
                {
                    _logger.LogError("Objeto enviado pelo cliente é nulo.");
                    return BadRequest("Objeto Livros é nulo");
                }

                if (!ModelState.IsValid)
                {
                   _logger.LogInfo("Objeto inválido enviado pelo cliente.");
                    return BadRequest("Objeto modelo invalido.");
                }

                _repository.Livros.CreateLivros(livros);

                return CreatedAtRoute("LivrosById", new { id = livros.Id }, livros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado na ação CreateOwner: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLivros(Guid id,[FromBody]Livros livros)
        {
            try
            {
                if (livros.IsObjectNull())
                {
                    _logger.LogError("Objeto enviado pelo cliente é nulo.");
                    return BadRequest("Objeto Livros é nulo");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInfo("Objeto inválido enviado pelo cliente.");
                    return BadRequest("Objeto modelo invalido.");
                }

                var dbLivros = _repository.Livros.GetLivrosById(id);
                if(dbLivros.IsEmptyObject())
                {
                    _logger.LogError($"Livro com o id: {id} não foi encontrado");
                    return NotFound();
                }

                _repository.Livros.UpdateLivros(dbLivros, livros);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado na ação UpdateOwner: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLivros(Guid id)
        {
            try
            {
                var livros = _repository.Livros.GetLivrosById(id);
                if(livros.IsEmptyObject())
                {
                    _logger.LogError($"Livro com o id {id} não foi encontrado");
                    return NotFound();
                }

                _repository.Livros.DeleteLivros(livros);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado na ação DeleteOwner: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }
    }
}
