using eFeiras.Business.Utilizadores;
using eFeiras.Utils;

namespace eFeiras.Data
{
    public class UtilizadorDAO : Map<int, Utilizador>
    {
        private static UtilizadorDAO? singleton = null;

        private UtilizadorDAO() { }

        public static UtilizadorDAO getInstance()
        {
            if (UtilizadorDAO.singleton == null)
            {
                UtilizadorDAO.singleton = new UtilizadorDAO();
            }
            return UtilizadorDAO.singleton;
        }

        public bool containsKey(int key) 
        {
            bool result = false;
            try
            {
                
            }
            catch(Exception ex)
            {
                throw new DAOException("Erro no containsKey do UtilizadorDAO");
            }
            return result;
        }

        public bool containsValue(Utilizador value)
        {
            return this.containsKey(value.getID());
        }

        public Utilizador get(int key)
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }

        public ICollection<int> keys()
        {
            throw new NotImplementedException();
        }

        public void put(int key, Utilizador value)
        {
            throw new NotImplementedException();
        }

        public Utilizador remove(int key)
        {
            throw new NotImplementedException();
        }

        public int size()
        {
            throw new NotImplementedException();
        }

        public ICollection<Utilizador> values()
        {
            throw new NotImplementedException();
        }

        bool Map<int, Utilizador>.containsValue(int value)
        {
            throw new NotImplementedException();
        }
    }
}
