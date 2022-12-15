using eFeiras.Utils;
using eFeiras.Business;
using System.Collections;

namespace eFeiras.Data
{
    public class BancaDAO: Map<Pair<int,int>,Banca>
    {
        private static BancaDAO? singleton = null;

        public static BancaDAO getInstance()
        {
            if (BancaDAO.singleton == null)
            {
                BancaDAO.singleton = new BancaDAO();
            }
            return BancaDAO.singleton;
        }

        public bool containsKey(Pair<int, int> key)
        {
            throw new NotImplementedException();
        }

        public bool containsValue(Banca value)
        {
            throw new NotImplementedException();
        }

        public Banca? get(Pair<int, int> key)
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }

        public ICollection<Pair<int, int>> keys()
        {
            throw new NotImplementedException();
        }

        public void put(Pair<int, int> key, Banca value)
        {
            throw new NotImplementedException();
        }

        public Banca remove(Pair<int, int> key)
        {
            throw new NotImplementedException();
        }

        public int size()
        {
            throw new NotImplementedException();
        }

        public ICollection<Banca> values()
        {
            throw new NotImplementedException();
        }
    }
}
