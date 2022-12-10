using eFeiras.Business.Categorias;

namespace eFeiras.Business.SubCategorias
{
    public sealed class SubCategoria
    { // Acho por bem esta classe ser imutável
        private int id;
        private string nome;
        private Categoria categoria;

        public SubCategoria(int id, string nome, Categoria categoria)
        {
            this.id = id;
            this.nome = nome;
            this.categoria = categoria; // Fazer clone se categoria não for imutável.
        }

        public int getId() { return this.id; }
        public string getNome() { return this.nome;}
        public Categoria getCategoria() { return this.categoria; }
    }
}
