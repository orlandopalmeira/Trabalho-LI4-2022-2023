using eFeiras.Business.Feiras;
using eFeiras.Utils;

namespace eFeiras.Data
{
    public class FeiraDAO : Map<int, Feira>
    {
        private static FeiraDAO? singleton = null;

        private FeiraDAO() { }

        public static FeiraDAO getInstance()
        {
            if(FeiraDAO.singleton == null)
            {
                FeiraDAO.singleton = new FeiraDAO();
            }
            return FeiraDAO.singleton;
        }

        public bool containsKey(int key)
        {
            throw new NotImplementedException();
        }

        public bool containsValue(int value)
        {
            throw new NotImplementedException();
        }

        public Feira get(int key)
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }

        public ICollection<int> keys()
        {
            throw new NotImplementedException();
        }

        public void put(int key, Feira value)
        {
            throw new NotImplementedException();
        }

        public Feira remove(int key)
        {
            throw new NotImplementedException();
        }

        public int size()
        {
            throw new NotImplementedException();
        }

        public ICollection<Feira> values()
        {
            throw new NotImplementedException();
        }
    }
}
