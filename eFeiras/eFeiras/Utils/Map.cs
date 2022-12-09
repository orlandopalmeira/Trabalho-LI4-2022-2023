namespace eFeiras.Utils
{
    public interface Map<X,Y>
    {
        public Y get(X key);

        public void put(X key, Y value);

        public Y remove(X key);

        public ICollection<X> keys();

        public ICollection<Y> values();
        public int size();

        public bool isEmpty();

        public bool containsKey(X key);

        public bool containsValue(X value);
    }
}
