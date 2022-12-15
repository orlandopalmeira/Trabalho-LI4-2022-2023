using eFeiras.Business;
using eFeiras.Business.SubCategorias;
using eFeiras.Utils;
using System.Data.SqlClient;

namespace eFeiras.Data
{
    public class CompraDAO: Map<int,Compra>
    {
        private static CompraDAO? singleton = null;

        public CompraDAO getInstance()
        {
            if (CompraDAO.singleton == null)
            {
                CompraDAO.singleton = new CompraDAO();
            }
            return CompraDAO.singleton;
        }

        private CompraDAO() { }
        public Compra? get(int key)
        {
            throw new NotImplementedException();
        }

        public void put(int key, Compra value)
        {
            throw new NotImplementedException();
        }

        public Compra remove(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<int> keys()
        {
            ICollection<int> result = new HashSet<int>();
            string s_cmd = "SELECT * FROM dbo.Compra";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                result.Add(id);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no keys do CompraDAO");
            }
            return result;
        }

        public ICollection<Compra> values()
        {
            throw new NotImplementedException();
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Compra";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result= reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no size do UtilizadorDAO");
            }
            return result;
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Compra WHERE id = " + key;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no containsKey do CompraDAO");
            }
            return result;
        }

        public bool containsValue(Compra value)
        {
            return this.containsKey(value.getID());
        }

        

    }
}
