using eFeiras.Utils;
using eFeiras.Data;

namespace eFeiras.Business.Produtos
{
    public class ProdutosFacade
    {
        private Map<int, Produto> produtos;

        public ProdutosFacade()
        {
            this.produtos = ProdutoDAO.getInstance();
        }

        public Produto getProduto(int produto_id)
        {
            return this.produtos.get(produto_id);
        }
    }
}
