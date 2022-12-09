using eFeiras.Business;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace eFeiras.Data
{
    public class CategoriaDAO : IDictionary<int, Categoria>
    {
        private static CategoriaDAO? singleton = null;

        public CategoriaDAO getInstance()
        {
            if(CategoriaDAO.singleton == null)
            {
                CategoriaDAO.singleton = new CategoriaDAO();
            }
            return CategoriaDAO.singleton;
        }

        private CategoriaDAO() { }
        public Categoria this[int key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<int> Keys => throw new NotImplementedException();

        public ICollection<Categoria> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(int key, Categoria value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<int, Categoria> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<int, Categoria> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(int key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<int, Categoria>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<int, Categoria>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<int, Categoria> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(int key, [MaybeNullWhen(false)] out Categoria value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
