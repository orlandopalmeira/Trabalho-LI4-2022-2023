using eFeiras.Business.Produtos;
using eFeiras.Business.Utilizadores;
using eFeiras.Utils;

namespace eFeiras.TransferData
{
    public class CarrinhoCompras
    {
        private static Utilizador? comprador = null;
        private static IDictionary<int, Pair<Produto, int>> produtos = new Dictionary<int,Pair<Produto,int>>(10);


        public static void addProduto(Produto prod, int quantidade)
        {
            if (produtos.ContainsKey(prod.getID())) // já está no carrinho de compras
            {
                Pair<Produto,int> old = produtos[prod.getID()];
                CarrinhoCompras.removeProduto(prod.getID());
                CarrinhoCompras.produtos.Add(prod.getID(), new Pair<Produto, int>(prod, old.getY() + quantidade));
            }
            else // ainda não está no carrinho de compras
            {
                CarrinhoCompras.produtos.Add(prod.getID(), new Pair<Produto, int>(prod, quantidade));
            }
        }

        public static bool removeProduto(Produto prod)
        {
            return CarrinhoCompras.produtos.Remove(prod.getID());
        }

        public static bool removeProduto(int idprod)
        {
            return CarrinhoCompras.produtos.Remove(idprod);
        }


        /// <summary>
        /// Altera a quantidade de um produto, incrementando-a ou decrementando-a.
        /// </summary>
        /// <param name="idprod">Id do produto ao qual se aplica esta operação</param>
        /// <param name="incr">Booleano que indica se vamos incrementar ou decrementar</param>
        /// <returns></returns>
        private static int changeQuantidade(int idprod, bool incr)
        {
            Pair<Produto, int>? old;
            if (CarrinhoCompras.produtos.TryGetValue(idprod, out old))
            {
                CarrinhoCompras.produtos.Add(idprod, new Pair<Produto, int>(old.getX(), old.getY() + (incr ? 1 : -1)));
                return old.getY() + (incr ? 1 : -1);
            }
            return -1;
        }

        /// <summary>
        /// Altera a quantidade de um produto, incrementando-a ou decrementando-a.
        /// </summary>
        /// <param name="prod">O produto ao qual se aplica esta operação</param>
        /// <param name="incr">Booleano que indica se vamos incrementar ou decrementar</param>
        /// <returns></returns>
        private static int changeQuantidade(Produto prod, bool incr)
        {
            return changeQuantidade(prod.getID(), incr);
        }

        public static int incrementaProduto(Produto prod) 
        {
            return changeQuantidade(prod, true);
        }

        public static int incrementaProduto(int idprod)
        {
            return changeQuantidade(idprod, true);
        }

        public static int decrementaProduto(Produto prod)
        {
            return changeQuantidade(prod, false);
        }

        public static int decrementaProduto(int idprod)
        {
            return changeQuantidade(idprod, false);
        }

        public static void setComprador(Utilizador u) 
        {
            CarrinhoCompras.comprador = u;
        }

        public static Utilizador getComprador()
        {
            return CarrinhoCompras.comprador;
        }

        public static int quantosProdutos()
        {
            return CarrinhoCompras.produtos.Count;
        }

        public static ICollection<Pair<Produto,int>> getShoppingCartInfo()
        {
            return CarrinhoCompras.produtos.Values;
        }

        public static float custoTotal()
        {
            float res = 0;
            foreach (Pair<Produto,int> p in produtos.Values)
            {
                res += p.getX().getPreco() * p.getY();
            }
            return res;
        }

        public static void clear()
        {
            CarrinhoCompras.comprador = null;
            CarrinhoCompras.produtos.Clear();
        }

    }
}
