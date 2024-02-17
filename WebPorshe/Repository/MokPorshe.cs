using System.Collections.Generic;
using System.Linq;
using WebPorshe.Model;
using WebPorshe.repository;

namespace WebPorshe.Repository
{
    public class MokPorshe : IPorshe
    {
        private readonly List<Porshe> _list;

        public MokPorshe()
        {
            _list = new List<Porshe>
            {
                new Porshe { id = 1, Model = "Cayman", Color = "White" },
                new Porshe { id = 2, Model = "Cayenne", Color = "Black" },
                new Porshe { id = 3, Model = "Boxster", Color = "Pink" }
            };
        }

        public Porshe Add(Porshe porshe)
        {
      
            if (_list.Any(existingPorshe => existingPorshe.id == porshe.id))
            {
               
                throw new InvalidOperationException("Object with the same ID already exists.");
            }

            _list.Add(porshe);
            return porshe;
        }
        public Porshe Delete(int id)
        {
            var porsheDB = Get(id);
            if (porsheDB != null)
            {
                _list.Remove(porsheDB);
            }
            return porsheDB;
        }

        public Porshe Get(int id)
        {
            return _list.FirstOrDefault(p => p.id == id);
        }

        public List<Porshe> GetAll()
        {
            return _list;
        }

        public Porshe Update(Porshe porshe)
        {
            var porsheDB = Get(porshe.id);
            if (porsheDB != null)
            {
                _list.Remove(porsheDB);
                _list.Add(porshe);
            }
            return porshe;
        }
    }
}