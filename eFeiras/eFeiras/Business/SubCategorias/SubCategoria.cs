using eFeiras.Business.Categorias;

namespace eFeiras.Business.SubCategorias
{
    public sealed class SubCategoria
    { // Acho por bem esta classe ser imutável
        private int id;
        private string nome;
        private int categoria_id;
        private Categoria categoria;

        public SubCategoria(int id,string nome, int categoria_id)
        {
            this.id = id;
            this.nome = nome;
            this.categoria_id = categoria_id;
        }

        public SubCategoria(int id, string nome, Categoria categoria)
        {
            this.id = id;
            this.nome = nome;
            this.categoria = categoria; // Fazer clone se categoria não for imutável.
        }

        public int getId() { return this.id; }
        public string getNome() { return this.nome;}
        public Categoria getCategoria() { return this.categoria; }

        public int getCategoriaID() { return this.categoria_id; }

        public void setCategoria(Categoria cat)
        {
            this.categoria = cat;
        }
    }
}
