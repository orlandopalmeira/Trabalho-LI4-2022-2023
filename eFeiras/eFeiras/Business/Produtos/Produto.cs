using eFeiras.Business.SubCategorias;
using eFeiras.Business.Utilizadores;

namespace eFeiras.Business.Produtos
{
    public class Produto
    {
        private int id;
        private string nome;
        private string descricao;
        private float preco;
        private int quantidade_disponivel;
        private string img_path;
        private int vendedor_id;
        private Utilizador vendedor;
        private int subcategoria_id;
        private SubCategoria subCategoria;

        public Produto(int id, string nome, string descricao, float preco, int qnt_disp, string img_path,
                       Utilizador vendedor, SubCategoria sc)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco;
            this.quantidade_disponivel = qnt_disp;
            this.img_path = img_path;
            this.vendedor = vendedor; //.clone()? 
            this.vendedor_id = vendedor.getID();
            this.subCategoria = sc; //.clone()? 
            this.subcategoria_id = sc.getId();
        }

        public Produto(System.Int32 id, System.String nome, System.String descricao, System.Decimal preco, System.Int32 quantidade_disponivel, System.String imagem, System.Int32 Utilizador_id, System.Int32 SubCategoria_id) // construtor para o DAPPER
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.preco = Convert.ToSingle(preco);
            this.quantidade_disponivel= quantidade_disponivel;
            this.img_path = imagem;
            this.vendedor_id = Utilizador_id;
            this.subcategoria_id = SubCategoria_id;
        }


        public int getID()
        {
            return this.id;
        }

        public string getNome() { return nome; }

        public string getDescricao() { return descricao; }

        public float getPreco() { return preco; }

        public int getQuantidadeDisponivel() { return quantidade_disponivel;}

        public string getImg_path() { return img_path; }
        public int getVendedorId()
        {
            return this.vendedor_id;
        }

        public void setVendedor(Utilizador vendedor)
        {
            this.vendedor = vendedor;
        }

        public int getSubcategoriaId() { return this.subcategoria_id; }

        public void setSubCategoria(SubCategoria subCategoria)
        {
            this.subCategoria = subCategoria;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }


    }
}
