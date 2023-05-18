using Microsoft.EntityFrameworkCore;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.API.Repositories
{
    public interface IWordRepository
    {
        void Create(Word dto);
        List<Word> GetAll();
        Word GetById(int id);
        List<Word> GetByLanguage(int languageId);
        void Delete(int id);
        void Update(int id, UpdateWordDTO dto);
    }
    public class WordRepository : IWordRepository
    {
        private readonly ILangugageRepository _langRepository = new LanguageRepository();
        private readonly OnlineDictionaryContext db = new OnlineDictionaryContext();
        public void Create(Word word)
        {
            db.Words.Add(word);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Words.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Word> GetAll()
        {
            return db.Words.ToList();
        }

        public Word GetById(int id)
        {
            return db.Words.Single(x => x.Id == id);
        }

        public List<Word> GetByLanguage(int languageId)
        {
            return db.Words.Where(x => x.LanguageId == languageId).ToList();
        }

        public void Update(int id, UpdateWordDTO dto)
        {
            //rough DI violation
            var word = GetById(id);
            if (dto.LanguageName != null) 
            {
                var langId = _langRepository.GetByName(dto.LanguageName).Id;
                word.LanguageId = langId;
            }
            if (dto.Value != null) { word.Value = dto.Value; }
            if (dto.Info != null) { word.Info = dto.Info; }
            db.SaveChanges();
        }
    }
}
