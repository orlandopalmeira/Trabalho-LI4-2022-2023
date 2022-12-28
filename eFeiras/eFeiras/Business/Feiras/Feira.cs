using eFeiras.Business.Bancas;
using eFeiras.Business.Categorias;
using System.Runtime.CompilerServices;

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
        private int categoria_id;
        private Categoria categoria;
        private List<Banca> bancas;

        public Feira(System.Int32 id, System.String titulo, System.String descricao, System.DateTime data_inicio, System.DateTime data_fim, System.String imagem, System.Int32 limite_bancas, System.Int32 categoria_id) 
        {
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.data_inicio = DateOnly.FromDateTime(data_inicio);
            this.data_fim = DateOnly.FromDateTime(data_fim);
            this.img_path= imagem;
            this.limite_bancas = limite_bancas;
            this.categoria_id = categoria_id;
            this.bancas = new List<Banca>(limite_bancas);
        }
        
        public Feira(int id, string titulo, string descricao, DateOnly data_inicio, DateOnly data_fim, string img_path, int limite_bancas, Categoria cat, ICollection<Banca> bncs) { 
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
            this.img_path = img_path;
            this.limite_bancas= limite_bancas;
            this.categoria = cat; // .clone()????
            this.categoria_id = cat.getID();
            this.bancas = new List<Banca>(bncs.Count);
            foreach(Banca b in bncs)
            {
                this.bancas.Add(b); // b.clone()????
            }
        }

        public Feira(int id, string titulo, string descricao, DateOnly data_inicio, DateOnly data_fim, string img_path, int limite_bancas, Categoria cat)
        {
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
            this.img_path = img_path;
            this.limite_bancas = limite_bancas;
            this.categoria = cat; // .clone()????
            this.bancas = new List<Banca>(limite_bancas);
        }

        
        public int getId() { return id; }

        public string getName()
        {
            return this.titulo;
        }

        public string getDescricao() { return this.descricao; }

        public DateOnly getDataInicio()
        {
            return this.data_inicio;
        }
        public string getDataInicioSTR()
        {
            return this.data_inicio.ToString("yyyy-MM-dd");
        }

        public DateOnly getDataFim()
        {
            return this.data_fim;
        }

        public string getDataFimSTR()
        {
            return this.data_fim.ToString("yyyy-MM-dd");
        }

        public string getImgPath()
        {
            return this.img_path;
        }

        public Categoria getCategoria() { return this.categoria; }

        public void setCategoria(Categoria categoria) 
        { 
            this.categoria = categoria; // categoria.clone()???
            this.categoria_id = categoria.getID(); 
        }
        public int getCategoriaID() { return this.categoria_id; }

        public int getLimiteBancas()
        {
            return this.limite_bancas;
        }

        public List<Banca> getBancas()
        {
            return this.bancas.Select(x => x).ToList(); // x.clone()?
        }

        public bool addBanca(Banca banca)
        {
            this.bancas ??= new List<Banca>(this.limite_bancas);
            if(this.bancas.Count < this.limite_bancas) // limite ultrapassado?
            {
                this.bancas.Add(banca); // banca.clone()???
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool emCurso()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            return today.CompareTo(this.data_inicio) >= 0 && today.CompareTo(this.data_fim) <= 0;
        }

        public bool utilizadorTemBanca(int id_vendedor)
        {
            foreach(Banca b in this.bancas)
            {
                if(b.getVendedorId() == id_vendedor)
                    return true;
            }

            return false;
        }

    }

    
}
