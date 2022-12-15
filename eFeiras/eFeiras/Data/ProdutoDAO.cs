using eFeiras.Business.Categorias;
using eFeiras.Business.Produtos;
using eFeiras.Business.SubCategorias;
using eFeiras.Business.Utilizadores;
using eFeiras.Utils;
using System.Data.SqlClient;

namespace eFeiras.Data
{
    public class ProdutoDAO: Map<int,Produto>
    {
        private static ProdutoDAO? singleton = null;
        private static SubCategoriaDAO? scDAO = null;
        private static UtilizadorDAO? userDAO = null;
        private ProdutoDAO() { }

        public static ProdutoDAO getInstance()
        {
            if (ProdutoDAO.singleton == null)
            {
                ProdutoDAO.singleton = new ProdutoDAO();
                ProdutoDAO.scDAO = SubCategoriaDAO.getInstance();
                ProdutoDAO.userDAO = UtilizadorDAO.getInstance();
            }
            return ProdutoDAO.singleton;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Produto WHERE id = " + key;
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
                throw new DAOException("Erro no containsKey do ProdutoDAO");
            }
            return result;
        }

        public bool containsValue(Produto value)
        {
            return this.containsKey(value.getID());
        }

        public Produto? get(int key)
        {
            Produto? result = null;
            string s_cmd = "SELECT * FROM dbo.Produto WHERE id = " + key;
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
                                string? nome = reader.GetString(1);
                                string? descricao = reader.GetString(2);
                                float preco = reader.GetFloat(3);
                                int qnt_disp = reader.GetInt32(4);
                                string? img_path = reader.GetString(5);
                                int vendedor_id = reader.GetInt32(6);
                                Utilizador vendedor = userDAO.get(vendedor_id);
                                int subcat_id = reader.GetInt32(7);
                                SubCategoria subcat = scDAO.get(subcat_id);
                                result = new Produto(id, nome, descricao, preco, qnt_disp, img_path, vendedor, subcat);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no get do ProdutoDAO");
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
            string s_cmd = "SELECT * FROM dbo.Produto";
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
                throw new DAOException("Erro no keys do ProdutoDAO");
            }
            return result;
        }

        public void put(int key, Produto value) 
        {
            string s_cmd = "INSERT INTO dbo.Produto (nome,descricao,preco,quantidade_disponivel,imagem,Utilizador_id,SubCategoria_id) VALUES (" +
                           value.getNome() + "," + value.getDescricao() + "," + value.getQuantidadeDisponivel() + "," +
                           value.getImg_path() + "," + value.getVendedorId() + "," + value.getSubcategoriaId() + ")";
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
                throw new DAOException("Erro no put do ProdutoDAO");
            }
        }

        public Produto remove(int key)
        {
            Produto result = this.get(key);
            string s_cmd = "DELETE FROM dbo.Produto WHERE id = " + key;
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
                throw new DAOException("Erro no remove do ProdutoDAO");
            }
            return result;
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Produto";
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
                throw new DAOException("Erro no size do ProdutoDAO");
            }
            return result;
        }

        public ICollection<Produto> values()
        {
            ICollection<Produto> result = new HashSet<Produto>();
            string s_cmd = "SELECT * FROM dbo.Produto";
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
                                string? nome = reader.GetString(1);
                                string? descricao = reader.GetString(2);
                                float preco = reader.GetFloat(3);
                                int qnt_disp = reader.GetInt32(4);
                                string? img_path = reader.GetString(5);
                                int vendedor_id = reader.GetInt32(6);
                                Utilizador vendedor = userDAO.get(vendedor_id);
                                int subcat_id = reader.GetInt32(7);
                                SubCategoria subcat = scDAO.get(subcat_id);
                                result.Add(new Produto(id, nome, descricao, preco, qnt_disp, img_path, vendedor, subcat));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no values do ProdutoDAO");
            }
            return result;
        }
    }
}
