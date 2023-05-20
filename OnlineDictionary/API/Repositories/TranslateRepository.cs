using Microsoft.EntityFrameworkCore;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.API.Repositories
{
    public interface ITranslateRepository
    {
        void Create(CreateTranslateDTO dto);
        void Delete(int id);
        void Update(int id, UpdateTranslateDTO dto);
        Translate GetById(int id);
        List<Translate> GetAll();
        List<Translate> GetAllByLangType(int id1, int id2);
    }
    public class TranslateRepository : ITranslateRepository
    {
        private readonly OnlineDictionaryContext db = new OnlineDictionaryContext();
        public void Create(CreateTranslateDTO dto)
        {
            db.Translates.Add
                (
                new Translate 
                { 
                    Word1Id = dto.Word1Id,
                    Word2Id = dto.Word2Id,
                    Example = dto.Example
                }
                );
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Translates.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Translate> GetAll()
        {
            return db.Translates
                .Include(x => x.Word1)
                .Include(x => x.Word2)
                .ToList();
        }

        public List<Translate> GetAllByLangType(int id1, int id2)
        {
            return db.Translates
                .Where(x => x.Word1.LanguageId == id1 && x.Word2.LanguageId == id2)
                .Include(x => x.Word1)
                .Include(x => x.Word2)
                .ToList();
        }

        public Translate GetById(int id)
        {
            return db.Translates
                .Include(x => x.Word1).ThenInclude(x => x.Language)
                .Include(x => x.Word2).ThenInclude(x => x.Language)
                .Single(x => x.Id == id);
        }

        public void Update(int id, UpdateTranslateDTO dto)
        {
            var translate = GetById(id);
            if (dto.Example != null) { translate.Example = dto.Example; }
            db.SaveChanges();
        }
    }
}
