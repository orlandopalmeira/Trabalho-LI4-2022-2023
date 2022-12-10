using eFeiras.Business.Categorias;
using eFeiras.Utils;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Data.SqlClient;

namespace eFeiras.Data
{
    public class CategoriaDAO : Map<int, Categoria>
    {
        private static CategoriaDAO? singleton = null;

        public static CategoriaDAO getInstance()
        {
            if(CategoriaDAO.singleton == null)
            {
                CategoriaDAO.singleton = new CategoriaDAO();
            }
            return CategoriaDAO.singleton;
        }

        private CategoriaDAO() { }

        public Categoria? get(int key)
        {
            Categoria? result = null;
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
                                int id = -1; int.TryParse(reader.GetString(0), out id);
                                string nome = reader.GetString(1);
                                result = new Categoria(id, nome);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no get do Categoria");
            }
            return result;
        }

        public void put(int key, Categoria value)
        {
            string s_cmd = "INSERT INTO dbo.Categoria (id,nome) VALUES (" + 
                            value.getID() + "," + value.getNome() + ")";
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
            ICollection<int> result = new HashSet<int>();
            string s_cmd = "SELECT * FROM dbo.Categoria";
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
                                int id = -1; int.TryParse(reader.GetString(0), out id);
                                result.Add(id);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no keys do CategoriaDAO");
            }
            return result;
        }

        public ICollection<Categoria> values()
        {
            ICollection<Categoria> categorias = new HashSet<Categoria>();
            string s_cmd = "SELECT * FROM dbo.Categoria";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                int id = -1; int.TryParse(reader.GetString(0), out id);
                                string nome = reader.GetString(1);
                                categorias.Add(new Categoria(id,nome));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no values do CategoriaDAO");
            }
            return categorias;
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
                                int.TryParse(reader.GetString(0), out result);
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
