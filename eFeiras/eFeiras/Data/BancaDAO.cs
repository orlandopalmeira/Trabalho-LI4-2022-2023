using eFeiras.Utils;
using eFeiras.Business.Bancas;
using System.Data.SqlClient;
using Dapper;

namespace eFeiras.Data
{
    public class BancaDAO: Map<Pair<int,int>,Banca> // Chave -> Pair<id_feira,id_vendedor>
    {
        private static BancaDAO? singleton = null; 

        public static BancaDAO getInstance()
        {
            if (BancaDAO.singleton == null)
            {
                BancaDAO.singleton = new BancaDAO();
            }
            return BancaDAO.singleton;
        }

        private BancaDAO() { }

        
        public bool containsKey(Pair<int, int> key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Banca WHERE Feira_id = " + key.getX() + " and Utilizador_id = " + key.getY();
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
                throw new DAOException("Erro no containsKey do BancaDAO");
            }
            return result;
        }

        public bool containsValue(Banca value)
        {
            return this.containsKey(new Pair<int, int>(value.getFeiraId(),value.getVendedorId()));
        }

        public Banca? get(Pair<int, int> key)
        {
            return DAOAuxiliar.getBanca(key.getX(),key.getY());
        }


        public bool isEmpty()
        {
            return this.size() == 0;
        }

        public ICollection<Pair<int,int>> keys()
        {
            return DAOAuxiliar.getBancasIDs();
        }

        public void put(Pair<int, int> key, Banca value)
        {
            string s_cmd = "insert into dbo.Banca (Feira_id,Utilizador_id,titulo) values" +
                            "('" + key.getX() + "','" + key.getY() + "','" + value.getTitulo() + "')";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no put do BancaDAO");
            }
        }

        public Banca remove(Pair<int, int> key)
        {
            Banca result = this.get(key);
            string s_cmd = "DELETE FROM dbo.Banca WHERE Feira_id = " + key.getX() + " and Utilizador_id = " + key.getY();
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no remove do BancaDAO");
            }
            return result;
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Banca";
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
                                result = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no size do BancaDAO");
            }
            return result;
        }

        public ICollection<Banca> values()
        {
            return DAOAuxiliar.getBancas();
        }

    }
}
