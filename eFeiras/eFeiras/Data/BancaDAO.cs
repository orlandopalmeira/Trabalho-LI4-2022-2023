using eFeiras.Utils;
using eFeiras.Business;
using System.Collections;

namespace eFeiras.Data
{
    public class BancaDAO: IDictionary<Pair<int,int>,Banca>
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

        public Banca this[Pair<int, int> key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<Pair<int, int>> Keys => throw new NotImplementedException();

        public ICollection<Banca> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Pair<int, int> key, Banca value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<Pair<int, int>, Banca> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<Pair<int, int>, Banca> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(Pair<int, int> key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Pair<int, int>, Banca>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Pair<int, int>, Banca>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Pair<int, int> key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Pair<int, int>, Banca> item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        bool IDictionary<Pair<int, int>, Banca>.TryGetValue(Pair<int, int> key, out Banca value)
        {
            throw new NotImplementedException();
        }
    }
}
