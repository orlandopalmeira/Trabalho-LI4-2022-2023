using eFeiras.Business.SubCategorias;

namespace eFeiras.Business.Categorias
{
    public sealed class Categoria
    { // Acho por bem esta classe ser imutável
        private int id;
        private string nome;

        public Categoria(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public int getID() { return id; }
        public string getNome() { return nome; }

    }
}
