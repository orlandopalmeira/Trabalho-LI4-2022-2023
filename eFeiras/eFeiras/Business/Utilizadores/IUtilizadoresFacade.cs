namespace eFeiras.Business.Utilizadores
{
    public interface IUtilizadoresFacade
    {
        public int getUserType(int userID);

        public bool existsEmail(string email);

        public bool existsCC(string cc);
        public bool existsNIF(string nif);

        public bool existsUsername(string username);

        public bool validateNewAccount(string email, string cc, string nif, string username);

        public bool adicionaConta(Utilizador novo);
    }
}
