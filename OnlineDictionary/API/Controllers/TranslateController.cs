using Microsoft.AspNetCore.Mvc;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;
using OnlineDictionary.API.Services;

namespace OnlineDictionary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private readonly ITranslateService _service;
        public TranslateController(ITranslateService translateService) => _service = translateService;

        [HttpGet("all")]
        public ActionResult<IEnumerable<Translate>> GetAll
            ()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}/type")]
        public ActionResult<string> GetLangType
            (
                int id
            )
        {
            return _service.GetLangType(id);
        }

        [HttpGet("all/type")]
        public ActionResult<IEnumerable<Translate>> GetAllByLangType
            (
                [FromQuery] string type
            )
        {
            return _service.GetAllByLangType(type);
        }

        [HttpGet("{id}")]
        public ActionResult<Translate> GetById
            (
                int id
            )
        {
            return _service.GetById(id);
        }

        [HttpPost("zero")]
        public void CreateZero
            (
                [FromBody] CreateTranslateZeroDTO dto
            )
        {
            _service.CreateZero(dto);
        }
        
        [HttpPost]
        public void Create
            (
                [FromBody] CreateTranslateDTO dto
            )
        {
            _service.Create(dto);
        }

        [HttpPatch("{id}")]
        public void Update 
            (
                int id,
                [FromBody] UpdateTranslateDTO dto
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
