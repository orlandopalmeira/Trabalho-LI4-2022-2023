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
        // Depois escolhemos o mais conveniente
        private List<Banca> bancas;

        public Feira(int id, string titulo, string descricao, DateOnly data_inicio, DateOnly data_fim, string img_path, int limite_bancas, Categoria cat, ICollection<Banca> bncs) { 
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
            this.img_path = img_path;
            this.limite_bancas= limite_bancas;
            this.categoria = cat; // .clone()????
            this.bancas = new List<Banca>(bncs.Count);
            foreach(Banca b in bncs)
            {
                this.bancas.Add(b); // b.clone()????
            }
        }

        public string getName()
        {
            return this.titulo;
        }

        public bool emCurso()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            return today.CompareTo(this.data_inicio) >= 0 && today.CompareTo(this.data_fim) <= 0;
        }

    }

    
}
