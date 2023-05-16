using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.API.Repositories
{
    public interface ILangugageRepository
    {
        void Create(CreateLanguageDTO dto);
        void Delete(int id);
        List<Language> GetAll();
        Language GetById(int id);
        void Update(int id, UpdateLanguageDTO language);
    }
    public class LanguageRepository : ILangugageRepository
    {
        private readonly OnlineDictionaryContext db = new OnlineDictionaryContext();
        public void Create(CreateLanguageDTO dto)
        {
            db.Languages.Add
                (
                new Language 
                {
                    Name = dto.Name,
                    Info = dto.Info,
                }
                );
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Languages.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Language> GetAll()
        {
            return db.Languages.ToList();
        }

        public Language GetById(int id)
        {
            return db.Languages.Find(id);
        }

        public void Update(int id, UpdateLanguageDTO dto)
        {
            var langToChange = GetById(id);
            if (langToChange.Name != null) { langToChange.Name = dto.Name; }
            if (langToChange.Info != null) { langToChange.Info = dto.Info; }
            db.SaveChanges();
        }
    }
}
