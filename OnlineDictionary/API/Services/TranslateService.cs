using Microsoft.AspNetCore.Mvc;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;
using OnlineDictionary.API.Repositories;

namespace OnlineDictionary.API.Services
{
    public interface ITranslateService 
    {
        List<Translate> GetAll();
        string GetLangType(int id);
        List<Translate> GetAllByLangType(string type);
        Translate GetById(int id);
        void CreateZero(CreateTranslateZeroDTO dto);
        void Create(CreateTranslateDTO dto);
        void Update(int id, UpdateTranslateDTO dto);
        void Delete(int id);
    }
    public class TranslateService : ITranslateService
    {
        private readonly ILangugageRepository _langRepo;
        private readonly ITranslateRepository _transRepo;
        private readonly IWordRepository _wordRepo;
        public TranslateService(ITranslateRepository translateRepository, 
            IWordRepository wordRepository, ILangugageRepository langugageRepository)
        {
            _transRepo = translateRepository;
            _wordRepo = wordRepository;
            _langRepo = langugageRepository;    
        }

        public void Create(CreateTranslateDTO dto)
        {
            _transRepo.Create(dto);
        }

        public void CreateZero(CreateTranslateZeroDTO dto)
        {
            var word1Id = _wordRepo.Create
                (
                    new Word 
                    {
                        Value = dto.Value1,
                        LanguageId = _langRepo.GetByName(dto.LangName1).Id
                    }
                );
            var word2Id = _wordRepo.Create
                (
                    new Word
                    {
                        Value = dto.Value2,
                        LanguageId = _langRepo.GetByName(dto.LangName2).Id
                    }
                );

            _transRepo.Create
                (
                    new CreateTranslateDTO 
                    {
                        Word1Id = word1Id, 
                        Word2Id = word2Id
                    }
                );
        }

        public void Delete(int id)
        {
            _transRepo.Delete(id);
        }

        public List<Translate> GetAll()
        {
            return _transRepo.GetAll();
        }

        public List<Translate> GetAllByLangType(string type)
        {
            string[] types = type.Split('-');
            var lan1 = _langRepo.GetByName(types[0]).Id;
            var lan2 = _langRepo.GetByName(types[1]).Id;
            return _transRepo.GetAllByLangType(lan1, lan2);
        }

        public Translate GetById(int id) 
        {
            return _transRepo.GetById(id);
        }

        public string GetLangType(int id)
        {
            var translate = _transRepo.GetById(id);
            return $"{translate.Word1.Language.Name}-{translate.Word2.Language.Name}";
        }

        public void Update(int id, UpdateTranslateDTO dto)
        {
            _transRepo.Update(id, dto);
        }
    }
}
