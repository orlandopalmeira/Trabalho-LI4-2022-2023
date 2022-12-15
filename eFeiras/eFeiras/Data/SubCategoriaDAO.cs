using eFeiras.Business.Categorias;
using eFeiras.Business.SubCategorias;
using eFeiras.Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace eFeiras.Data
{
    public class SubCategoriaDAO : Map<int, SubCategoria>
    {
        private static SubCategoriaDAO? singleton = null;
        private static CategoriaDAO? categoriaDAO = null;
        private SubCategoriaDAO() { }
        public static SubCategoriaDAO getInstance()
        {
            if (SubCategoriaDAO.singleton == null)
            {
                SubCategoriaDAO.categoriaDAO = CategoriaDAO.getInstance();
                SubCategoriaDAO.singleton = new SubCategoriaDAO();
            }
            return SubCategoriaDAO.singleton;
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
            return this.containsKey(value.getId());
        }

        public SubCategoria? get(int key)
        {
            SubCategoria? result = null;
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
                                int id = reader.GetInt32(0);
                                string nome = reader.GetString(1);
                                int id_categoria = reader.GetInt32(2);
                                Categoria? c = SubCategoriaDAO.categoriaDAO.get(id_categoria);
                                if (c != null)
                                {
                                    result = new SubCategoria(id, nome, c);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no get do SucCategoriaDAO");
            }
            return result;
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }

        public ICollection<int> keys()
        {
            ICollection<int> result = new HashSet<int>();
            string s_cmd = "SELECT * FROM dbo.Subcategoria";
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
                throw new DAOException("Erro no keys do SubCategoriaDAO");
            }
            return result;
        }

        public void put(int key, SubCategoria value)
        {
            string s_cmd = "INSERT INTO dbo.Subcategoria (nome,categoria_id) VALUES (" +
                            value.getNome() + "," + value.getCategoria().getID() + ")";
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
            SubCategoria result = this.get(key);
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
            ICollection<SubCategoria> result = new HashSet<SubCategoria>();
            string s_cmd = "SELECT * FROM dbo.Subcategoria";
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
                                string nome = reader.GetString(1);
                                int id_categoria = reader.GetInt32(2);
                                result.Add(new SubCategoria(id, nome, SubCategoriaDAO.categoriaDAO.get(id_categoria)));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no values do SubCategoriaDAO");
            }
            return result;
        }
    } 
}
