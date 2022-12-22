using eFeiras.Business.Feiras;
using System.Data.SqlClient;

namespace eFeiras.Data.DAOS
{
    internal class FeiraDAO
    {
        private static FeiraDAO? singleton = null;

        private FeiraDAO() { }

        public static FeiraDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new FeiraDAO();
            }
            return singleton;
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
            return containsKey(value.getId());
        }

        public Feira? get(int key)
        {
            return DAOAuxiliar.getFeira(key);
        }

        public bool isEmpty()
        {
            return size() == 0;
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
                            value.getCategoriaID() + "')";
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
            Feira result = get(key);
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

        public ICollection<Feira> getFeirasEmCurso()
        {
            return DAOAuxiliar.getFeirasEmCurso();
        }
        public ICollection<Feira> values()
        {
            return DAOAuxiliar.getFeiras();
        }
    }
}
