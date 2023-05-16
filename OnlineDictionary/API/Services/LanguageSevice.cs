using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;
using OnlineDictionary.API.Repositories;

namespace OnlineDictionary.API.Services
{
    public interface ILangugageService
    {
        void Create(CreateLanguageDTO dto);
        List<Language> GetAll();
        Language GetById(int id);
        void Update(int id, UpdateLanguageDTO language); 
        void Delete(int id);
    }
    public class LanguageSevice : ILangugageService
    {
        private readonly ILangugageRepository _langRepo;
        public LanguageSevice(ILangugageRepository langugageRepository)
        {
            _langRepo = langugageRepository;
        }

        public void Create(CreateLanguageDTO dto)
        {
            _langRepo.Create(dto);
        }

        public void Delete(int id)
        {
            _langRepo.Delete(id);
        }

        public List<Language> GetAll()
        {
            return _langRepo.GetAll();
        }

        public Language GetById(int id)
        {
            return _langRepo.GetById(id);
        }

        public void Update(int id, UpdateLanguageDTO dto)
        {
            _langRepo.Update(id, dto);
        }
    }
}
