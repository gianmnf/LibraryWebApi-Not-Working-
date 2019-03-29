using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ILoggerManager _logger { get; set; }

        public ValuesController(ILoggerManager logger)
        {
            logger = _logger;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //Desativado
            /*_logger.LogInfo("Aqui está a mensagem informativa gerada pelo Controller.");
            _logger.LogDebug("Aqui está a mensagem de debug gerada pelo Controller.");
            _logger.LogWarn("Aqui está a mensagem de aviso gerada pelo Controller.");
            _logger.LogError("Aqui está a mensagem de erro gerada pelo Controller."); */
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
