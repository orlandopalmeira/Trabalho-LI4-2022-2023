﻿using Dapper;
using eFeiras.Business.Produtos;
using eFeiras.Utils;
using System.Data.SqlClient;

namespace eFeiras.Data
{
    public class ProdutoDAO: Map<int,Produto>
    {
        private static ProdutoDAO? singleton = null;
        private ProdutoDAO() { }

        public static ProdutoDAO getInstance()
        {
            if (ProdutoDAO.singleton == null)
            {
                ProdutoDAO.singleton = new ProdutoDAO();
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
            return DAOAuxiliar.getProduto(key);
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }

        public ICollection<int> keys()
        {
            return DAOAuxiliar.getProdutosIDs();
        }

        public void put(int key, Produto value) 
        {
            string s_cmd = "INSERT INTO dbo.Produto (nome,descricao,preco,quantidade_disponivel,imagem,Utilizador_id,SubCategoria_id) VALUES ('" +
                           value.getNome() + "','" + value.getDescricao() + "','" + value.getQuantidadeDisponivel() + "','" +
                           value.getImg_path() + "','" + value.getVendedorId() + "','" + value.getSubcategoriaId() + "')";
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
            return DAOAuxiliar.getProdutos();
        }
    }
}
