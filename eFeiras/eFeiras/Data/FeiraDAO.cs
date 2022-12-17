using eFeiras.Business.Feiras;
using eFeiras.Utils;
using Dapper;
using System.Data.SqlClient;
using eFeiras.Business.Bancas;
using eFeiras.Business.Categorias;

namespace eFeiras.Data
{
    public class FeiraDAO : Map<int, Feira>
    {
        private static FeiraDAO? singleton = null;
        private static BancaDAO? bancaDAO = null;
        private static CategoriaDAO? categoriaDAO = null;
        private static UtilizadorDAO? userDAO = null;

        private FeiraDAO() { }

        public static FeiraDAO getInstance()
        {
            if(FeiraDAO.singleton == null)
            {
                FeiraDAO.singleton = new FeiraDAO();
                FeiraDAO.bancaDAO = BancaDAO.getInstance();
                FeiraDAO.categoriaDAO = CategoriaDAO.getInstance();
                FeiraDAO.userDAO = UtilizadorDAO.getInstance();
            }
            return FeiraDAO.singleton;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Feira WHERE id = " + key;
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
                throw new DAOException("Erro no containsKey do FeiraDAO");
            }
            return result;
        }

        public bool containsValue(Feira value)
        {
            return this.containsKey(value.getId());
        }

        public Feira? get(int key)
        {
            return DAOAuxiliar.getFeira(key);
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }

        public ICollection<int> keys()
        {
            return DAOAuxiliar.getFeirasIDs();
        }

        public void put(int key, Feira value)
        {
            string s_cmd = "insert into dbo.Feira (titulo,descricao,data_inicio,data_fim,imagem,limite_bancas,categoria_id) values" +
                            "('" + value.getName() + "','" + value.getDescricao() + "','" +
                            value.getDataInicioSTR() + "','" + value.getDataFimSTR() + "','" + 
                            value.getImgPath() + "','" + value.getLimiteBancas() + "','" +
                            value.getCategoriaID() +  "')";
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
                throw new DAOException("Erro no put do FeiraDAO");
            }
        }

        public Feira remove(int key)
        {
            Feira result = this.get(key);
            string s_cmd = "DELETE FROM dbo.Feira WHERE id = " + key;
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
                throw new DAOException("Erro no remove do FeiraDAO");
            }
            return result;
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Feira";
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
                throw new DAOException("Erro no size do FeiraDAO");
            }
            return result;
        }

        
        public ICollection<Feira> values()
        {
            return DAOAuxiliar.getFeiras();
        }
    }
}
