using WebPorshe.Model;

namespace WebPorshe.repository
{
    public interface IPorshe
    {
        public Porshe Add(Porshe porshe);
        public Porshe Get(int id);
        public Porshe Update(Porshe porshe);
        public List<Porshe> GetAll();
        public Porshe Delete(int id);
        

    }
}
