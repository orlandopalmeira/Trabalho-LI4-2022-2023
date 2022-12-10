using eFeiras.Data;
using eFeiras.Utils;

namespace eFeiras.Business.Utilizadores
{
    public class UtilizadoresFacade: IUtilizadoresFacade
    {
        private Map<int, Utilizador> utilizadores;

        public UtilizadoresFacade()
        {
            this.utilizadores = UtilizadorDAO.getInstance();
        }

        public int getUserType(int userID)
        {
            return this.utilizadores.get(userID).getUserType();
        }

        private bool existsSomething(Func<Utilizador,bool> predicate){
            ICollection<Utilizador> users = this.utilizadores.values();
            bool result = false;
            foreach (Utilizador u in users)
            {
                if (predicate(u))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool existsEmail(string email)
        {
            return this.existsSomething((Utilizador x) => x.getEmail().CompareTo(email) == 0);
        }

        public bool existsCC(string cc)
        {
            return this.existsSomething((Utilizador x) => x.getCC().CompareTo(cc) == 0);
        }
        public bool existsNIF(string nif)
        {
            return this.existsSomething((Utilizador x) => x.getNIF().CompareTo(nif) == 0);
        }

        public bool existsUsername(string username)
        {
            return this.existsSomething((Utilizador x) => x.getUsername().CompareTo(username) == 0);
        }

        public bool validateNewAccount(string email, string cc, string nif, string username)
        {
            // verifica se não existe alguma conta no sistema que já tenha algum destes parâmetros
            return !(this.existsEmail(email) || this.existsCC(cc) || 
                     this.existsNIF(nif) || this.existsUsername(username));
        }

        public bool adicionaConta(Utilizador novo)
        {
            // retorna true se a conta foi adicionada. False caso contrário
            if (this.validateNewAccount(novo.getEmail(),novo.getCC(),novo.getNIF(),novo.getUsername()))
            {
                this.utilizadores.put(novo.getID(), novo);
                return true;   
            }
            else
            {
                return false;
            }
        }
    }
}
