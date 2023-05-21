using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;
using OnlineDictionary.API.Services;

namespace OnlineDictionary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictController : ControllerBase
    {
        private readonly IDictService _service;
        public DictController(IDictService dictService) => _service = dictService;


        [HttpGet("all")]
        public ActionResult<IEnumerable<Dict>> GetAll
            ()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Dict> GetById
            (
                int id
            )
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public void Create
            (
                [FromBody] CreateDictDTO dto
            )
        {
            _service.Create(dto);
        }

        [HttpPatch("{id}/add/{translId}")]
        public void AddTranslate
            (
                int id,
                int translId
            )
        {
            _service.AddTranslate(id, translId);
        }

        [HttpPatch("{id}/add/many")]
        public void AddTranslates
            (
                int id,
                [FromBody] List<TranslateDTO> translates //dto? support arrays?
            )
        {
            _service.AddTranslates(id, translates);
        }
        
        [HttpPatch("{id}")]
        public void Update
            (
                int id,
                [FromBody] UpdateDictDTO dto
            )
        {
            _service.Update(id, dto);
        }
        
        [HttpPatch("{id}/remove/{translId}")]
        public void RemoveTranslate
            (
                int id,
                int translId
            )
        {
            _service.RemoveTranslate(id, translId);
        }
        
        [HttpDelete("id")]
        public void Delete
            (
                int id
            )
        {
            _service.Delete(id);
        }
    }
}
