using eFeiras.Business.Utilizadores;

namespace eFeiras.TransferData
{
    public class CurrentUser
    {
        /*Esta é uma classe de uma única instância cujo objectivo é armaz*/
        private static CurrentUser? singleton = null;
        private static Utilizador? current = null;
        private CurrentUser() { }

        public static void setCurrentUser(Utilizador user)
        {
            CurrentUser.current = user;
        }

        public static Utilizador getCurrentUser()
        {
            return CurrentUser.current;
        }
    }
}
