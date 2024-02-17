using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebPorshe.Model;
using WebPorshe.repository;
using WebPorshe.Repository;

namespace WebPorshe.Controller
{
    public class SqlPorsheRepository : IPorshe
    {
        private readonly AppDbContext _appDbContext;

        public SqlPorsheRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Porshe Add(Porshe porshe)
        {
            _appDbContext.Porshes.Add(porshe);
            _appDbContext.SaveChanges();
            return porshe;
        }

        public Porshe Delete(int id)
        {
            
                var porsheDB = Get(id);
                if (porsheDB != null)
                {
                _appDbContext.Remove(porsheDB);
                }
                return porsheDB;
            
        }

        public Porshe Get(int id)
        {
            return _appDbContext.Porshes.FirstOrDefault(p => p.id == id);
        }


        public List<Porshe> GetAll()
        {
            return _appDbContext.Porshes.ToList();
        }

        public Porshe Update(Porshe updatedPorshe)
        {
            if (updatedPorshe.id == 0)
            {
                _appDbContext.Porshes.Add(updatedPorshe);
            }
            else
            {
                var existingPorshe = _appDbContext.Porshes.Find(updatedPorshe.id);
                if (existingPorshe != null)
                {
                    existingPorshe.Model = updatedPorshe.Model;
                    existingPorshe.Color = updatedPorshe.Color;
                }
            }

            _appDbContext.SaveChanges();
            return updatedPorshe;
        }
    }
}