using Microsoft.EntityFrameworkCore;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.API.Repositories
{
    public interface IDictRepository 
    {
        void Create(Dict dto);
        List<Dict> GetAll();
        Dict GetById(int id);
        void AddTranslates(int id, List<int> translates);
        void RemoveTranslate(int id, int translId);
        void Update(int id, UpdateDictDTO dto);
        void Delete(int id);
    }

    public class DictRepository: IDictRepository
    {
        private readonly OnlineDictionaryContext db = new OnlineDictionaryContext();
        public void AddTranslates(int id, List<int> translates)
        {
            List<DictsTranslate> dT = new List<DictsTranslate>();
            translates.ForEach(x => dT.Add
            (
                new DictsTranslate 
                {
                    DictId = id,
                    TranslateId = x
                }
            ));
            db.DictsTranslates.AddRange(dT);
            db.SaveChanges();
        }

        public void Create(Dict dto)
        {
            db.Dicts.Add
                (
                    dto
                );
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Dict> GetAll()
        {
            return db.Dicts
                .Include(x => x.DictsTranslates)
                .ThenInclude(x => x.Translate)
                .ThenInclude(x => x.Word1)
                .Include(x => x.DictsTranslates)
                .ThenInclude(x => x.Translate)
                .ThenInclude(x => x.Word2)
                .ToList();
        }

        public Dict GetById(int id)
        {
            return db.Dicts
                .Include(x => x.DictsTranslates)
                .ThenInclude(x => x.Translate)
                .ThenInclude(x => x.Word1)
                .Include(x => x.DictsTranslates)
                .ThenInclude(x => x.Translate)
                .ThenInclude(x => x.Word2)
                .Single(x => x.Id == id);
        }

        public void RemoveTranslate(int id, int translId)
        {
            var dT = db.DictsTranslates.Single(x => x.DictId == id && x.TranslateId == translId);
            db.DictsTranslates.Remove(dT);
            db.SaveChanges();
        }

        public void Update(int id, UpdateDictDTO dto)
        {
            var dict = GetById(id);
            if (dto.Name != null) { dict.Name = dto.Name; }
            if (dto.Info != null) { dict.Info = dto.Info; }
            if (dto.Language1Id != null) { dict.Language1Id = (int)dto.Language1Id; }
            if (dto.Language2Id != null) { dict.Language2Id = (int)dto.Language2Id; }
            db.SaveChanges();
        }
    }
}
