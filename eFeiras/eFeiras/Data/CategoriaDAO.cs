using Dapper;
using eFeiras.Business.Categorias;
using eFeiras.Business.SubCategorias;
using eFeiras.Utils;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Data.SqlClient;

namespace eFeiras.Data
{
    public class CategoriaDAO : Map<int, Categoria>
    {
        private static CategoriaDAO? singleton = null;
        private static SubCategoriaDAO? subcatDAO = null;

        public static CategoriaDAO getInstance()
        {
            if(CategoriaDAO.singleton == null)
            {
                CategoriaDAO.singleton = new CategoriaDAO();
                CategoriaDAO.subcatDAO = SubCategoriaDAO.getInstance();
            }
            return CategoriaDAO.singleton;
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
            Categoria result = this.get(key);
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
            return this.size() == 0;
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
            return this.containsKey(value.getID());  
        }

    }
}
