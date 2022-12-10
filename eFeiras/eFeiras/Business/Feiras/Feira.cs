using eFeiras.Business.Categorias;

namespace eFeiras.Business.Feiras
{
    public class Feira
    {
        private int id;
        private string titulo;
        private string descricao;
        private DateOnly data_inicio;
        private DateOnly data_fim;
        private string img_path;
        private int limite_bancas;
        // Depois escolhemos o mais conveniente
        private Categoria categoria;
        private int categoriaID;
        // Depois escolhemos o mais conveniente
        private List<Banca> bancas;
        private List<int> ids_bancas;

        public string getName()
        {
            return this.titulo;
        }

    }

    
}
