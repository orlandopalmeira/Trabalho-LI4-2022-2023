using eFeiras.Business.Feiras;
using eFeiras.Business.Utilizadores;
using eFeiras.Business.Produtos;

namespace eFeiras.Business
{
    public interface IEFeirasFacade
    {
        // Utilizadores
        public bool existsEmail(string email);

        public Utilizador getUtilizadorWithEmail(string email);

        public bool validateNewAccount(string email, string cc, string nif, string username);

        public bool adicionaConta(Utilizador utilizador);

        // Feiras
        public ICollection<Feira> getFeirasEmCurso();

        // Produtos
        public int getQuantidadeDisponivelProduto(int produtoid);

        public int getQuantidadeDisponivelProduto(Produto produto);

    }
}
