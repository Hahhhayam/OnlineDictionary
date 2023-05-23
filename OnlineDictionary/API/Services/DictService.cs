using Microsoft.AspNetCore.Mvc;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;
using OnlineDictionary.API.Repositories;

namespace OnlineDictionary.API.Services
{
    public interface IDictService
    {
        List<Dict> GetAll();
        Dict GetById(int id);
        void Create(CreateDictDTO dto);
        void AddTranslate(int id, int translId);
        void AddTranslates(int id, List<TranslateDTO> translates);
        void Update(int id, UpdateDictDTO dto);
        void RemoveTranslate(int id, int translId);
        void Delete(int id);
    }
    public class DictService: IDictService
    {
        private readonly IDictRepository _dictRepo;
        private readonly ILangugageRepository _langRepo;
        public DictService(IDictRepository dictRepository, ILangugageRepository langugageRepository)
        {
            _dictRepo = dictRepository;
            _langRepo = langugageRepository;
        }

        public void AddTranslate(int id, int translId)
        {
            _dictRepo.AddTranslates(id, new List<int>() { translId });
        }

        public void AddTranslates(int id, List<TranslateDTO> translates)
        { 
            List<int> ids = new List<int>();
            translates.ForEach(x => ids.Add(x.Id));
            _dictRepo.AddTranslates(id, ids);
        }

        public void Create(CreateDictDTO dto)
        {
            var lanId1 = _langRepo.GetByName(dto.Language1Name).Id;
            var lanId2 = _langRepo.GetByName(dto.Language2Name).Id;
            _dictRepo.Create(new Dict 
            {
                Name = dto.Name,
                Info = dto.Info,
                Language1Id = lanId1,
                Language2Id = lanId2
            });
        }

        public void Delete(int id)
        {
            _dictRepo.Delete(id);
        }

        public List<Dict> GetAll()
        {
            return _dictRepo.GetAll();
        }

        public Dict GetById(int id)
        {
            return _dictRepo.GetById(id);
        }

        public void RemoveTranslate(int id, int translId)
        {
            _dictRepo.RemoveTranslate(id, translId);
        }

        public void Update(int id, UpdateDictDTO dto)
        {
            _dictRepo.Update(id, dto);
        }
    }
}
