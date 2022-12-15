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
        private Utilizador vendedor;
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
            this.vendedor = vendedor; //.clone()? Talvez sim, um utilizador não é imutável.
            this.subCategoria = sc; //.clone()? Talvez não, uma subcategoria poderá ser imutável
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
            return this.vendedor.getID();
        }

        public int getSubcategoriaId() { return subCategoria.getId(); }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }


    }
}
