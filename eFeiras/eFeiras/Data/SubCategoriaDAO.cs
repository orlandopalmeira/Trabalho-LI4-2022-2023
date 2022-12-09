using eFeiras.Business;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace eFeiras.Data
{
    public class SubCategoriaDAO : IDictionary<int, SubCategoria>
    {
        private static SubCategoriaDAO? singleton = null;
        private SubCategoriaDAO() { }

        public SubCategoriaDAO getInstance()
        {
            if (SubCategoriaDAO.singleton == null)
            {
                SubCategoriaDAO.singleton = new SubCategoriaDAO();
            }
            return SubCategoriaDAO.singleton;
        }

        public SubCategoria this[int key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<int> Keys => throw new NotImplementedException();

        public ICollection<SubCategoria> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(int key, SubCategoria value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<int, SubCategoria> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<int, SubCategoria> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(int key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<int, SubCategoria>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<int, SubCategoria>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<int, SubCategoria> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(int key, [MaybeNullWhen(false)] out SubCategoria value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
