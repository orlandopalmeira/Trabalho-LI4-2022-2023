using eFeiras.Business;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace eFeiras.Data
{
    public class CompraDAO: IDictionary<int,Compra>
    {
        private static CompraDAO? singleton = null;

        public CompraDAO getInstance()
        {
            if (CompraDAO.singleton == null)
            {
                CompraDAO.singleton = new CompraDAO();
            }
            return CompraDAO.singleton;
        }

        private CompraDAO() { }


        public Compra this[int key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<int> Keys => throw new NotImplementedException();

        public ICollection<Compra> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(int key, Compra value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<int, Compra> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<int, Compra> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(int key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<int, Compra>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<int, Compra>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<int, Compra> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(int key, [MaybeNullWhen(false)] out Compra value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
