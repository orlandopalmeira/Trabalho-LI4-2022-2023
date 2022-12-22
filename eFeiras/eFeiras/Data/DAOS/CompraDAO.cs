﻿using Dapper;
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
                            value.getMontante() + "','" + value.getDataStr("yyyy-MM-dd HH:mm:ss") + "','" +
                            value.getCompradorID() + "'); SELECT SCOPE_IDENTITY() AS chave_compra;"; // insere compra
            string s_cmd2 = "INSERT INTO dbo.compra_has_produto (Compra_id,Produto_id,quantidade) VALUES ('@compra_id','@produto_id','@quantidade')"; // associa a compra aos produtos
            string s_cmd3 = "UPDATE dbo.Produto SET quantidade_disponivel - '@qnt_comp' WHERE id = '@compra_id'"; // actualiza a quantidade disponível dos produtos da compra
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    int idCompra = con.ExecuteScalar<int>(s_cmd); // insere a compra e retorna o id dessa compra inserida.
                    foreach (Pair<int, int> p in value.getIdsProdutosQuantidade()) // insere as relações entre os produtos e a compra
                    {
                        var parameters = new { compra_id = idCompra, produto_id = p.getX(), quantidade = p.getY() };
                        con.Execute(s_cmd2, parameters); // associa o produto a compra
                        con.Execute(s_cmd3,new { qnt_comp = p.getY(), compra_id = idCompra}); // actualiza a quantidade do produto comprado
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
                                result = reader.GetInt32(0);
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
            catch (Exception)
            {
                throw new DAOException("Erro no containsKey do CompraDAO");
            }
            return result;
        }

        public bool containsValue(Compra value)
        {
            return containsKey(value.getID());
        }

    }
}
