using eFeiras.Business.Compras;
using eFeiras.Business.Feiras;
using eFeiras.Business.Produtos;
using eFeiras.Business.Utilizadores;
using eFeiras.Data;

namespace eFeiras.Business
{
    public class eFeirasFacade: IEFeirasFacade
    {
        private IDatabaseFacade db; // base de dados

        public eFeirasFacade()
        {
            this.db = new DatabaseFacade();
        }
        // Utilizadores
        public bool existsEmail(string email)
        {
            return db.existsEmail(email);
        }

        public Utilizador getUtilizadorWithEmail(string email)
        {
            return db.getUtilizadorWithEmail(email);
        }

        public bool validateNewAccount(string email, string cc, string nif, string username)
        {
            return !db.existsEmail(email) && !db.existsCC(cc) && !db.existsNIF(nif) && !db.existsUsername(username);
        }

        public bool adicionaConta(Utilizador utilizador)
        {
            if (this.validateNewAccount(utilizador.getEmail(), utilizador.getCC(), utilizador.getNIF(), utilizador.getUsername()))
            {
                this.db.addUtilizador(utilizador);
                return true;
            }
            return false;
        }

        // Feiras
        public ICollection<Feira> getFeirasEmCurso()
        {
            return db.getAllFeirasEmCurso();
        }

        // Produtos
        public int getQuantidadeDisponivelProduto(int produtoid)
        {
            return db.getQuantidadeDisponivelProduto(produtoid);
        }

        public int getQuantidadeDisponivelProduto(Produto produto)
        {
            return db.getQuantidadeDisponivelProduto(produto);
        }

        // Compras

        public void addCompra(Compra compra)
        {
            this.db.addCompra(compra);
        }

        // Bancas

        // Categorias

        // Subcategorias


    }
}
