namespace eFeiras.Utils
{
    public sealed class Pair<X,Y>{ // objectos deste tipo são imutáveis
        private X x;
        private Y y;

        public Pair(X x, Y y) { this.x = x; this.y = y; }

        public X getX()
        {
            return this.x;
        }

        public Y getY()
        {
            return this.y;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Pair<X,Y> p = (Pair<X, Y>)obj;
                return this.x.Equals(p.x) && this.y.Equals(p.y);
            }
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() + this.y.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.x.ToString(), this.y.ToString());
        }

    }
}
