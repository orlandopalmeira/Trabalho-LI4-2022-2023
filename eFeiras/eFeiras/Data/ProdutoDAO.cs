using eFeiras.Business;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace eFeiras.Data
{
    public class ProdutoDAO: IDictionary<int,Produto>
    {
        private static ProdutoDAO? singleton = null;
        private ProdutoDAO() { }

        public ProdutoDAO getInstance()
        {
            if(ProdutoDAO.singleton == null)
            {
                ProdutoDAO.singleton = new ProdutoDAO();
            }
            return ProdutoDAO.singleton;
        }

        public Produto this[int key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<int> Keys => throw new NotImplementedException();

        public ICollection<Produto> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(int key, Produto value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<int, Produto> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<int, Produto> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(int key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<int, Produto>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<int, Produto>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<int, Produto> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(int key, [MaybeNullWhen(false)] out Produto value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
