using eFeiras.Business.SubCategorias;
using System.Data.SqlClient;

namespace eFeiras.Data.DAOS
{
    internal class SubCategoriaDAO
    {
        private static SubCategoriaDAO? singleton = null;
        private SubCategoriaDAO() { }
        public static SubCategoriaDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new SubCategoriaDAO();
            }
            return singleton;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Subcategoria WHERE id = " + key;
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
                throw new DAOException("Erro no containsKey do SubCategoriaDAO");
            }
            return result;
        }

        public bool containsValue(SubCategoria value)
        {
            return containsKey(value.getId());
        }

        public SubCategoria? get(int key)
        {
            return DAOAuxiliar.getSubCategoria(key);
        }

        public bool isEmpty()
        {
            return size() == 0;
        }

        public ICollection<int> keys()
        {
            return DAOAuxiliar.getSubCategoriasIDs();
        }

        public void put(int key, SubCategoria value)
        {
            string s_cmd = "INSERT INTO dbo.Subcategoria (nome,categoria_id) VALUES ('" +
                            value.getNome() + "','" + value.getCategoria().getID() + "')";
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
                throw new DAOException("Erro no put do SubCategoriaDAO");
            }
        }

        public SubCategoria remove(int key)
        {
            SubCategoria result = get(key);
            string s_cmd = "DELETE FROM dbo.Subcategoria WHERE id = " + key;
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
                throw new DAOException("Erro no remove do SubCategoriaDAO");
            }
            return result;
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Subcategoria";
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
                throw new DAOException("Erro no size do SubCategoriaDAO");
            }
            return result;
        }

        public ICollection<SubCategoria> values()
        {
            return DAOAuxiliar.getSubCategorias();
        }
    }
}
