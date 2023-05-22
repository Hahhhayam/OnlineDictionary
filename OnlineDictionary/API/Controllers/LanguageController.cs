using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;
using OnlineDictionary.API.Services;

namespace OnlineDictionary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILangugageService _service;
        public LanguageController(ILangugageService langugageService) => _service = langugageService;

        [HttpPost]
        public void Create
            (
                [FromBody] CreateLanguageDTO dto
            )
        {
            _service.Create(dto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Language>> GetAll
            ()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Language> GetById
            (
                int id
            )
        {
            return _service.GetById(id);
        }

        [HttpPatch("{id}")]
        public void Update
            (
                int id,
                [FromBody] UpdateLanguageDTO dto
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
