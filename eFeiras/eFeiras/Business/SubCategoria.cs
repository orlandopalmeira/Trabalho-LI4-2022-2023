namespace eFeiras.Business
{
    public sealed class SubCategoria
    { // Acho por bem esta classe ser imutável
        private int id;
        private string nome;
        // depois escolhemos aquele que for mais conveniente
        private int categoriaId;
        private Categoria categoria;

        public SubCategoria(int id, string nome, int categoriaID, Categoria categoria)
        {
            this.id = id;
            this.nome = nome;
            categoriaId = categoriaID;
            this.categoria = categoria; // Fazer clone se categoria não for imutável.
        }
    }
}
