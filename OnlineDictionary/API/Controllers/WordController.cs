using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;
using OnlineDictionary.API.Services;

namespace OnlineDictionary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordService _service;
        public WordController(IWordService wordService) => _service = wordService;
        [HttpGet("all")]
        public ActionResult<IEnumerable<Word>> GetAll
            ()
        {
            return _service.GetAll();
        }
        [HttpGet("all/{langId}")]
        public ActionResult<IEnumerable<Word>> GetByLanguage
            (
                int langId
            )
        {
            return _service.GetByLanguage(langId);
        }
        [HttpGet("{id}")]
        public ActionResult<Word> GetById
            (
                int id
            )
        {
            return _service.GetById(id);
        }
        [HttpPost]
        public void Create
            (
                [FromBody] CreateWordDTO dto
            )
        {
            _service.Create(dto);
        }
        [HttpPatch("{id}")]
        public void Update
            (
                int id,
                [FromBody] UpdateWordDTO dto
            )
        {
            _service.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public void Delete
            (
                int id
            )
        {
            _service.Delete(id);
        }
    }
}
