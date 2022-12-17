using eFeiras.Data;
using eFeiras.Utils;

namespace eFeiras.Business.Compras
{
    public class ComprasFacade : IComprasFacade
    {
        private Map<int, Compra> compras;

        public ComprasFacade()
        {
            this.compras = CompraDAO.getInstance();
        }

        public Compra getCompra(int compra_id)
        {
            return this.compras.get(compra_id);
        }
    }
}
