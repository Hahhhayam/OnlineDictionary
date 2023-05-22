using Microsoft.EntityFrameworkCore;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.API.Repositories
{
    public interface IWordRepository
    {
        int Create(Word dto);
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
        public int Create(Word word)
        {
            db.Words.Add(word);
            db.SaveChanges();
            return word.Id;
        }

        public void Delete(int id)
        {
            db.Words.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Word> GetAll()
        {
            return db.Words.Include(x => x.Language).ToList();
        }

        public Word GetById(int id)
        {
            return db.Words.Include(x => x.Language).Single(x => x.Id == id);
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
            if (!string.IsNullOrEmpty(dto.Value)) { word.Value = dto.Value; }
            if (!string.IsNullOrEmpty(dto.Info)) { word.Info = dto.Info; }
            db.SaveChanges();
        }
    }
}
