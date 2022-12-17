using eFeiras.Business.Feiras;
using eFeiras.Business.Produtos;
using eFeiras.Business.Utilizadores;

namespace eFeiras.Business.Bancas
{
    public class Banca
    {
        private int feira_id;
        private Feira feira;
        private int vendedor_id;
        private Utilizador vendedor;
        private string titulo;
        private List<int> ids_produtos;
        private List<Produto> produtos;
        public Banca(System.Int32 Feira_id, System.Int32 Utilizador_id, System.String titulo)
        {
            this.feira_id = Feira_id;
            this.vendedor_id = Utilizador_id;
            this.titulo = titulo;
            this.ids_produtos = new List<int>();
            this.produtos = new List<Produto>();
        }

        public int getFeiraId()
        {
            return feira_id;
        }

        public Feira getFeira()
        {
            return feira;
        }

        public void setFeira(Feira feira)
        {
            this.feira_id = feira.getId();
            this.feira = feira; //.clone()?
        }

        public int getVendedorId()
        {
            return vendedor_id;
        }

        public Utilizador getVendedor()
        {
            return vendedor;
        }

        public void setVendedor(Utilizador vendedor)
        {
            this.vendedor_id = vendedor.getID();
            this.vendedor = vendedor; //.clone();???
        }

        public string getTitulo()
        {
            return titulo;
        }

        public void addProduto(Produto p)
        {
            this.produtos ??= new List<Produto>();
            this.ids_produtos ??= new List<int>();
            this.produtos.Add(p);
            this.ids_produtos.Add(p.getID());
        }

        public List<Produto> getProdutos()
        {
            return this.produtos.Select(x => x).ToList();
        }

        public override int GetHashCode()
        {
            return this.feira_id.GetHashCode() + this.vendedor_id.GetHashCode();
        }
    }
}
