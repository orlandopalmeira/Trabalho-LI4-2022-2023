using eFeiras.Data;
using eFeiras.Utils;

namespace eFeiras.Business.Feiras
{
    public class FeirasFacade
    {
        private Map<int, Feira> feiras;

        public FeirasFacade()
        {
            this.feiras = FeiraDAO.getInstance();
        }

        private bool existsSomething(Func<Feira,bool> predicate)
        {
            bool result = false;
            ICollection<Feira> feiras_ = this.feiras.values();
            foreach(Feira f in feiras_)
            {
                if (predicate(f))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool existsName(string name)
        {
            // verifica se já existe uma feira com o nome mencionado.
            return this.existsSomething((Feira f) => name.CompareTo(f.getName()) == 0);
        }
    }
}
