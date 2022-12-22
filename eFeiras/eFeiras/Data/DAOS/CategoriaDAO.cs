using eFeiras.Business.Categorias;
using System.Data.SqlClient;

namespace eFeiras.Data.DAOS
{
    internal class CategoriaDAO
    {
        private static CategoriaDAO? singleton = null;

        public static CategoriaDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new CategoriaDAO();
            }
            return singleton;
        }

        private CategoriaDAO() { }

        public Categoria? get(int key)
        {
            return DAOAuxiliar.getCategoria(key);
        }

        public void put(int key, Categoria value)
        {
            string s_cmd = "INSERT INTO dbo.Categoria (id,nome) VALUES ('" +
                            value.getID() + "','" + value.getNome() + "')";
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
                throw new DAOException("Erro no put do CategoriaDAO");
            }
        }

        public Categoria remove(int key)
        {
            Categoria result = get(key);
            string s_cmd = "DELETE FROM dbo.Categoria WHERE id = " + key;
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
                throw new DAOException("Erro no get do Categoria");
            }
            return result;
        }

        public ICollection<int> keys()
        {
            return DAOAuxiliar.getCategoriasIDs();
        }

        public ICollection<Categoria> values()
        {
            return DAOAuxiliar.getCategorias();
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Categoria";
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
                throw new DAOException("Erro no size do CategoriaDAO");
            }
            return result;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Categoria WHERE id = " + key;
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
                throw new DAOException("Erro no containsKey do CategoriaDAO");
            }
            return result;
        }

        public bool containsValue(Categoria value)
        {
            return containsKey(value.getID());
        }

    }
}
