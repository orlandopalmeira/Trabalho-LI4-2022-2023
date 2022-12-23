using Dapper;
using eFeiras.Business.Compras;
using eFeiras.Utils;
using System.Data.SqlClient;

namespace eFeiras.Data.DAOS
{
    internal class CompraDAO
    {
        private static CompraDAO? singleton = null;
        public static CompraDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new CompraDAO();
            }
            return singleton;
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
                            value.calcMontante().ToString().Replace(',','.') + "','" + value.getDataStr("yyyy-MM-dd HH:mm:ss") + "','" +
                            value.getCompradorID() + "'); SELECT SCOPE_IDENTITY() AS chave_compra;"; // insere compra
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    int idCompra = con.ExecuteScalar<int>(s_cmd); // insere a compra e retorna o id dessa compra inserida.
                    foreach (Pair<int, int> p in value.getIdsProdutosQuantidade()) // insere as relações entre os produtos e a compra
                    {
                        con.Execute($"INSERT INTO dbo.compra_has_produto (Compra_id,Produto_id,quantidade) VALUES ('{idCompra}','{p.getX()}','{p.getY()}')");
                        con.Execute($"UPDATE dbo.Produto SET quantidade_disponivel = quantidade_disponivel - '{p.getY()}' WHERE id = '{p.getX()}'");
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
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
                                result = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
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
            catch (Exception e) { throw new DAOException(e.Message); }
            return result;
        }

        public bool containsValue(Compra value)
        {
            return containsKey(value.getID());
        }

    }
}
