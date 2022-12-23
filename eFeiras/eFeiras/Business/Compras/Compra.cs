using eFeiras.Business.Produtos;
using eFeiras.Business.Utilizadores;
using eFeiras.Utils;

namespace eFeiras.Business.Compras
{
    public class Compra
    {
        private int id;
        private float montante;
        private DateTime data;
        private int comprador_id;
        private Utilizador? comprador;
        private List<Pair<int, int>>? ids_produtos; // Pair<id_produto,quantidade_produto>
        private List<Pair<Produto, int>>? produtos; // Pair<Produto,quantidade_produto>

        public Compra(int id, float montante, DateTime data, int comprador_id)
        {// Construtor para o DAPPER
            this.id = id;
            this.montante = montante;
            this.data = data;
            this.comprador_id = comprador_id;
            this.comprador = null;
            this.ids_produtos = new List<Pair<int, int>>();
            this.produtos = new List<Pair<Produto, int>>();
        }

        public Compra(int id, DateTime data, Utilizador comprador, ICollection<Pair<Produto,int>> produtos)
        {
            this.id = id;
            this.montante = 0;
            this.data = data;
            this.comprador_id = comprador.getID();
            this.comprador = comprador; // .clone()?
            this.produtos ??= new List<Pair<Produto, int>>(produtos.Count);
            this.ids_produtos ??= new List<Pair<int, int>>(produtos.Count);
            foreach(Pair<Produto,int> p in produtos)
            {
                this.produtos.Add(p);
                this.ids_produtos.Add(new Pair<int, int>(p.getX().getID(),p.getY()));
            }
        }

        public Compra(int id, DateTime data, Utilizador comprador, ICollection<Pair<int, int>> ids_produtos)
        {
            this.id = id;
            this.montante = 0;
            this.data = data;
            this.comprador_id = comprador.getID();
            this.comprador = comprador; // .clone()?
            this.produtos ??= new List<Pair<Produto, int>>(ids_produtos.Count);
            this.ids_produtos ??= new List<Pair<int, int>>(ids_produtos.Count);
            foreach (Pair<int, int> p in ids_produtos)
            {
                this.ids_produtos.Add(new Pair<int, int>(p.getX(), p.getY()));
            }
        }
        /// <summary>
        /// Calcula o montante desta compra de acordo com os produtos que tem.
        /// </summary>
        public float calcMontante()
        {
            this.montante = 0;
            if(this.produtos != null)
            {
                foreach (Pair<Produto, int> p in produtos)
                {
                    this.montante += p.getX().getPreco() * p.getY();
                }
            }
            return this.montante;
        }
        private int hasProduto(Produto p)
        {
            int r = -1;
            if(this.produtos != null)
            {
                for (int i = 0; i < produtos.Count; i++)
                {
                    if (produtos[i].getX().Equals(p)) { r = i; break; }
                }
            }
            return r;
        }
        public void addProduto(Produto produto, int quantidade)
        {
            if (hasProduto(produto) != -1)
            {
                this.produtos ??= new List<Pair<Produto, int>>();
                this.ids_produtos ??= new List<Pair<int, int>>();
                produtos.Add(new Pair<Produto, int>(produto, quantidade));
                ids_produtos.Add(new Pair<int, int>(produto.getID(),quantidade));
            }
        }

        public int getID()
        {
            return id;
        }

        public float getMontante()
        {
            return this.montante;
        }

        public DateTime getData()
        {
            return this.data;
        }

        public string getDataStr(string format)
        {
            return this.data.ToString(format);
        }

        public int getCompradorID()
        {
            return this.comprador_id;
        }

        public ICollection<Pair<int,int>> getIdsProdutosQuantidade() 
        {
            ICollection<Pair<int, int>> result = new List<Pair<int, int>>(this.ids_produtos.Count);
            foreach (Pair<int,int> p in this.ids_produtos)
            {
                result.Add(p); // p.clone()?
            }
            return result;
        }

        public void setComprador(Utilizador comp)
        {
            this.comprador = comp; //.clone()?
        }


    }
}
