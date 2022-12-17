using Dapper;
using eFeiras.Business.Compras;
using eFeiras.Business.Produtos;
using eFeiras.Utils;
using System.Data.SqlClient;

namespace eFeiras.Data
{
    public class CompraDAO: Map<int,Compra>
    {
        private static CompraDAO? singleton = null;
        private static ProdutoDAO? produtoDAO = null;
        public static CompraDAO getInstance()
        {
            if (CompraDAO.singleton == null)
            {
                CompraDAO.singleton = new CompraDAO();
                CompraDAO.produtoDAO = ProdutoDAO.getInstance();
            }
            return CompraDAO.singleton;
        }

        private CompraDAO() { }
        public Compra? get(int key)
        {
            return DAOAuxiliar.getCompra(key);
        }

        public void put(int key, Compra value)
        {
            // para inserir a compra
            string s_cmd = "INSERT INTO dbo.Compra (montante,data,Utilizador_id) VALUES ('" +
                            value.getMontante() + "','" + value.getDataStr("yyyy-MM-dd HH:mm:ss") + "','" +
                            value.getCompradorID() + "'); SELECT SCOPE_IDENTITY() AS chave_compra;";
            string s_cmd2 = "INSERT INTO dbo.compra_has_produto (Compra_id,Produto_id,quantidade) VALUES ('@compra_id','@produto_id','@quantidade')";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    int idCompra = con.ExecuteScalar<int>(s_cmd); // insere a compra e retorna o id dessa compra inserida.
                    foreach (Pair<int,int> p in value.getIdsProdutosQuantidade()) // insere as relações entre os produtos e a compra
                    {
                        var parameters = new { compra_id = idCompra, produto_id = p.getX(), quantidade = p.getY()};
                        con.Execute(s_cmd2, parameters);
                    }
                }
            }
            catch (Exception) 
            {
                throw new DAOException("Erro no put do CompraDAO");
            }
        }

        public Compra remove(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<int> keys()
        {
            return DAOAuxiliar.getComprasIDs();
        }

        public ICollection<Compra> values()
        {
            return DAOAuxiliar.getCompras();
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
