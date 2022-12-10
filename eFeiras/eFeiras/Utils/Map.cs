using System.Runtime.CompilerServices;

namespace eFeiras.Utils
{
    public interface Map<X,Y>
    {
        Y this[X key] // perigoso, talvez não se use
        {
            get => this.get(key);
            set => this.put(key, value);
        }
        public Y? get(X key);

        public void put(X key, Y value);

        public Y remove(X key);

        public ICollection<X> keys();

        public ICollection<Y> values();
        public int size();

        public bool isEmpty();

        public bool containsKey(X key);

        public bool containsValue(Y value);
    }
}
