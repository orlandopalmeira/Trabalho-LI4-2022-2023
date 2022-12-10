namespace eFeiras.Business.Utilizadores
{
    public class Utilizador // Talvez deva ser abstrata? Temos três tipos de utilizadores
    {
        // Atributos do utilizador
        private int id;
        private int userType;
        private string? nome;
        private string? nif;
        private string? cartao_cidadao;
        private string? email;
        private string? rua_porta_andar;
        private string? cidade;
        private string? codigo_postal;
        private string? apresentacao;
        private bool aprovado; // false=não aprovado, true = aprovado
        private string? username;
        private string? password;

        public Utilizador(int id, int userType, string nome, string nif, string cartao_cidadao, string email,
                             string rua_porta_andar, string cidade, string codigo_postal, string apresentacao,
                             bool aprovado, string username, string password)
        {
            this.id = id;
            this.userType = userType;
            this.nome = nome;
            this.nif = nif;
            this.cartao_cidadao = cartao_cidadao;
            this.email = email;
            this.rua_porta_andar = rua_porta_andar;
            this.cidade = cidade;
            this.codigo_postal = codigo_postal;
            this.apresentacao = apresentacao;
            this.aprovado = aprovado;
            this.username = username;
            this.password = password;
        }

        // TODO: Getters and setters if necessary

        public int getID()
        {
            return this.id;
        }

        public int getUserType()
        {
            return this.userType;
        }

        public string getNome()
        {
            return this.nome;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getCC()
        {
            return this.cartao_cidadao;
        }

        public string getNIF()
        {
            return this.nif;
        }

        public string getUsername()
        {
            return this.username;
        }

        public string getRuaPortaAndar()
        {
            return this.rua_porta_andar;
        }

        public string getCidade()
        {
            return this.cidade;
        }

        public string getCodigoPostal()
        {
            return this.codigo_postal;
        }

        public string getApresentacao()
        {
            return this.apresentacao;
        }

        public bool getAprovado()
        {
            return this.aprovado;
        }

        public string getPassword()
        {
            return this.password;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
}
