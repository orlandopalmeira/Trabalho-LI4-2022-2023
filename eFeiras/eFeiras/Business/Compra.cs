using eFeiras.Business.Produtos;
using eFeiras.Utils;
using System.Runtime.CompilerServices;

namespace eFeiras.Business
{
    public class Compra
    {
        private int id;
        private float montante;
        private DateTime data;
        private int comprador_id;
        // Depois escolhemos o que for mais conveniente
        private List<Pair<Produto,int>> produtos; // Pair<Produto,quantidade_produto>

        public Compra(int id, DateTime data, int compradorID)
        {
            this.id = id;
            this.montante = 0;
            this.data = data;
            this.comprador_id = compradorID;
            this.produtos = new List<Pair<Produto, int>>();
        }
        /// <summary>
        /// Calcula o montante desta compra de acordo com os produto que tem.
        /// </summary>
        public void calcMontante1()
        {
            this.montante = 0;
            foreach(Pair<Produto,int> p in this.produtos){
                this.montante += p.getX().getPreco() * p.getY();
            }
        }
        private int hasProduto(Produto p) 
        {
            int r = -1;
            for(int i = 0; i < this.produtos.Count(); i++)
            {
                if (this.produtos[i].getX().Equals(p)) { r = i; break; }
            }
            return r;
        }
        public void addProduto(Produto produto, int quantidade)
        {
            if (this.hasProduto(produto) != -1)
            {
                this.produtos.Add(new Pair<Produto, int>(produto, quantidade));
            }
        }

        public int getID() 
        {
            return this.id;
        }
        
        
    }
}
