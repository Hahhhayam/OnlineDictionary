using Microsoft.AspNetCore.Mvc;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;
using OnlineDictionary.API.Repositories;

namespace OnlineDictionary.API.Services
{
    public interface IWordService
    {
        List<Word> GetAll();
        List<Word> GetByLanguage(int languageId);
        Word GetById(int id);
        void Create(CreateWordDTO dto);
        void Update(int id, UpdateWordDTO dto);
        void Delete(int id);

    }
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepo;
        private readonly ILangugageRepository _langugageRepo;
        public WordService(IWordRepository wordRepozitory, ILangugageRepository langugageRepository)
        {
            _wordRepo = wordRepozitory;
            _langugageRepo = langugageRepository;
        }
        public void Create(CreateWordDTO dto)
        {
            var lang = _langugageRepo.GetByName(dto.LanguageName);
            _wordRepo.Create(new Word 
            {
                Value = dto.Value,
                Info = dto.Info,
                LanguageId = lang.Id
            });
        }

        public void Delete(int id)
        {
            _wordRepo.Delete(id);
        }

        public List<Word> GetAll()
        {
            return _wordRepo.GetAll();
        }

        public Word GetById(int id)
        {
            return _wordRepo.GetById(id);
        }

        public List<Word> GetByLanguage(int languageId)
        {
            return _wordRepo.GetByLanguage(languageId);
        }

        public void Update(int id, UpdateWordDTO dto)
        {
            _wordRepo.Update(id, dto);
        }
    }
}

