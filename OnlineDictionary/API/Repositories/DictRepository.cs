using Microsoft.EntityFrameworkCore;
using OnlineDictionary.API.DTO;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.API.Repositories
{
    public interface IDictRepository 
    {
        void Create(CreateDictDTO dto);
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

        public void Create(CreateDictDTO dto)
        {
            db.Dicts.Add
                (
                    new Dict
                    {
                        Name = dto.Name,
                        Info = dto.Info,
                        Language1Id = dto.Language1Id,
                        Language2Id = dto.Language2Id
                    }
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
                .ToList();
        }

        public Dict GetById(int id)
        {
            return db.Dicts
                .Include(x => x.DictsTranslates)
                .ThenInclude(x => x.Translate)
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
