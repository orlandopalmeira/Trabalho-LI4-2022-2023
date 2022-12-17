using eFeiras.Data;
using eFeiras.Utils;

namespace eFeiras.Business.Bancas
{
    public class BancasFacade : IBancasFacade
    {
        private Map<Pair<int, int>, Banca> bancas;

        public BancasFacade() 
        { 
            this.bancas = BancaDAO.getInstance();
        }

        public Banca getBanca(Pair<int, int> vendedor_feira)
        {
            return this.bancas.get(vendedor_feira);
        }

        
    }
}
