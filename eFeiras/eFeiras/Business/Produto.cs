using System.Runtime.CompilerServices;
using eFeiras.Business.Utilizadores;

namespace eFeiras.Business
{
    public class Produto
    {
        private int id;
        private string nome;
        private string descricao;
        private float preco;
        private int quantidade_disponivel;
        private string img_path;
        // Depois vemos qual é o mais conveniente.
        private Utilizador vendedor;
        private int utilizadorID;
        // Depois vemos qual é o mais conveniente.
        private SubCategoria subCategoria;
        private int subCategoriaID;

        public Produto(int id, string nome, string descricao, float preco, int qnt_disp, string img_path,
                       Utilizador vendedor, int utilizadorID, SubCategoria sc, int scID)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco;
            this.quantidade_disponivel = qnt_disp;
            this.img_path = img_path;
            this.vendedor = vendedor; //.clone()? Talvez sim, um utilizador não é imutável.
            this.utilizadorID = utilizadorID;
            this.subCategoria = sc; //.clone()? Talvez não, uma subcategoria poderá ser imutável
            this.subCategoriaID = scID;
        }

        public float getPreco() { return this.preco; }

    }
}
