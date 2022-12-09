namespace eFeiras.Utils
{
    public class LoginData
    {
        // Esta classe serve para transferir os dados de login de uma página para outra.
        private static LoginData? singleton = null;
        private string? email = null;
        private string? password= null;

        public static LoginData getInstance()
        {
            if(LoginData.singleton == null)
            {
                LoginData.singleton = new LoginData();
            }
            return LoginData.singleton;
        }
        private LoginData() { }

        public void setData(string username, string password)
        {
            this.email = username;
            this.password = password;
        }

        public string getEmail() { return email; }
        public string getPassword() { return password; }

    }
}
