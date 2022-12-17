using Dapper;
using System.Data.SqlClient;
using eFeiras.Business.Categorias;
using eFeiras.Business.SubCategorias;
using eFeiras.Business.Utilizadores;
using eFeiras.Business.Produtos;
using eFeiras.Business.Compras;
using eFeiras.Utils;
using eFeiras.Business.Bancas;
using eFeiras.Business.Feiras;

namespace eFeiras.Data
{
    internal class DAOAuxiliar
    {
        // CATEGORIAS
        internal static Categoria getCategoria(int categoriaID)
        {
            Categoria? result = null;
            string s_cmd = $"SELECT * FROM dbo.Categoria WHERE id = '{categoriaID}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Categoria aux = con.QueryFirst<Categoria>(s_cmd);
                    result = aux;
                }
            }
            catch (Exception e) { throw new DAOException(e.Message); }
            return result;
        }

        internal static ICollection<Categoria> getCategorias()
        {
            ICollection<Categoria> categorias = new HashSet<Categoria>();
            string s_cmd = "SELECT * FROM dbo.Categoria";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Categoria> aux = con.Query<Categoria>(s_cmd);
                    foreach (Categoria categoria in aux)
                    {
                        categorias.Add(categoria);
                    }
                }
            }
            catch (Exception e) { throw new DAOException(e.Message); }
            return categorias;
        }

        internal static ICollection<int> getCategoriasIDs()
        {
            ICollection<int> result = new HashSet<int>();
            string s_cmd = "SELECT id FROM dbo.Categoria";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<int> aux = con.Query<int>(s_cmd);
                    foreach (int id in aux)
                    {
                        result.Add(id);
                    }
                }
            }
            catch (Exception e) { throw new DAOException(e.Message); }
            return result;
        }

        // SUBCATEGORIAS
        internal static SubCategoria getSubCategoria(int subcategoriaID)
        {
            SubCategoria? result = null;
            string s_cmd = $"SELECT * FROM dbo.Subcategoria WHERE id = '{subcategoriaID}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    SubCategoria aux = con.QueryFirst<SubCategoria>(s_cmd);
                    aux.setCategoria(DAOAuxiliar.getCategoria(aux.getCategoriaID()));
                    result = aux;
                }
            }
            catch (Exception e) { throw new DAOException(e.Message); }
            return result;
        }

        internal static ICollection<SubCategoria> getSubCategorias()
        {
            ICollection<SubCategoria> result = new HashSet<SubCategoria>();
            string s_cmd = "SELECT * FROM dbo.Subcategoria";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<SubCategoria> aux = con.Query<SubCategoria>(s_cmd);
                    foreach(SubCategoria sc in aux)
                    {
                        sc.setCategoria(DAOAuxiliar.getCategoria(sc.getCategoriaID()));
                        result.Add(sc);
                    }
                }
            }
            catch(Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        internal static ICollection<int> getSubCategoriasIDs()
        {
            ICollection<int> result = new HashSet<int>();
            string s_cmd = "SELECT id FROM dbo.Subcategoria";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<int> aux = con.Query<int>(s_cmd);
                    foreach (int i in aux)
                    {
                        result.Add(i);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        // UTILIZADORES

        internal static Utilizador getUtilizador(int utilizadorID)
        {
            Utilizador? utilizador = null;
            string s_cmd = $"SELECT * FROM dbo.Utilizador where id = '{utilizadorID}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Utilizador aux = con.QueryFirst<Utilizador>(s_cmd);
                    utilizador = aux;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return utilizador;
        }

        internal static ICollection<Utilizador> getUtilizadores()
        {
            ICollection<Utilizador> result = new HashSet<Utilizador>();
            string s_cmd = "SELECT * FROM dbo.Utilizador";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Utilizador> aux = con.Query<Utilizador>(s_cmd);
                    foreach(Utilizador u in aux)
                    {
                        result.Add(u);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        internal static ICollection<int> getUtilizadoresIDs()
        {
            ICollection<int> result = new HashSet<int>();
            string s_cmd = "SELECT id FROM dbo.Utilizador";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<int> aux = con.Query<int>(s_cmd);
                    foreach (int i in aux)
                    {
                        result.Add(i);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        // PRODUTOS
        internal static Produto getProduto(int produto_id)
        {
            Produto? result = null;
            string s_cmd = $"SELECT * FROM dbo.Produto where id='{produto_id}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Produto aux = con.QueryFirst<Produto>(s_cmd);
                    aux.setVendedor(getUtilizador(aux.getVendedorId()));
                    aux.setSubCategoria(getSubCategoria(aux.getSubcategoriaId()));
                    result = aux;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        internal static ICollection<Produto> getProdutos() 
        {
            ICollection<Produto> result = new HashSet<Produto>();
            string s_cmd = "SELECT * FROM dbo.Produto";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Produto> aux = con.Query<Produto>(s_cmd);
                    foreach (Produto produto in aux)
                    {
                        produto.setVendedor(getUtilizador(produto.getVendedorId()));
                        produto.setSubCategoria(getSubCategoria(produto.getSubcategoriaId()));
                        result.Add(produto);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        internal static ICollection<int> getProdutosIDs()
        {
            ICollection<int> result = new HashSet<int>();
            string s_cmd = "SELECT id FROM dbo.Produto";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<int> aux = con.Query<int>(s_cmd);
                    foreach (int i in aux)
                    {
                        result.Add(i);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        // COMPRAS
        internal static Compra getCompra(int compraID)
        {
            Compra? compra = null;
            string s_cmd = $"SELECT * FROM dbo.Compra where id = '{compraID}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Compra aux = con.QueryFirst<Compra>(s_cmd);
                    IEnumerable<Pair<int,int>> produtosDaCompra = con.Query<Pair<int, int>>($"SELECT Produto_id,quantidade where Compra_id='{compraID}'");
                    foreach(Pair<int, int> p in produtosDaCompra)
                    {
                        aux.addProduto(getProduto(p.getX()),p.getY());
                    }
                    compra = aux;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return compra;
        }

        internal static ICollection<Compra> getCompras()
        {
            ICollection<Compra> compras = new HashSet<Compra>();
            string s_cmd = "SELECT * FROM dbo.Compra";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Compra> aux = con.Query<Compra>(s_cmd);
                    foreach (Compra c in aux)
                    {
                        IEnumerable<Pair<int, int>> produtosDaCompra = con.Query<Pair<int, int>>($"SELECT Produto_id,quantidade where Compra_id='{c.getID()}'");
                        foreach (Pair<int, int> p in produtosDaCompra)
                        {
                            c.addProduto(getProduto(p.getX()), p.getY());
                        }
                        compras.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return compras;
        }

        internal static ICollection<int> getComprasIDs()
        {
            ICollection<int> result = new HashSet<int>();
            string s_cmd = "SELECT id FROM dbo.Compra";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<int> aux = con.Query<int>(s_cmd);
                    foreach (int i in aux)
                    {
                        result.Add(i);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        // BANCAS
        internal static Banca getBanca(int feira_id, int utilizador_id)
        {
            Banca? banca = null;
            string s_cmd = $"SELECT * FROM dbo.Banca WHERE Feira_id = '{feira_id}' AND Utilizador_id = '{utilizador_id}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Banca aux = con.QueryFirst<Banca>(s_cmd);
                    Feira feira = con.QueryFirst<Feira>($"SELECT * FROM dbo.Feira WHERE id='{feira_id}'");
                    Utilizador vendedor = getUtilizador(utilizador_id);
                    IEnumerable<int> prodsIDS = con.Query<int>($"SELECT * FROM dbo.banca_has_produto WHERE Feira_id = '{feira_id}' AND Utilizador_id = '{utilizador_id}'");
                    foreach(int prodID in prodsIDS)
                    {
                        aux.addProduto(getProduto(prodID));
                    }
                    aux.setFeira(feira);
                    aux.setVendedor(vendedor);
                    banca = aux;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return banca;
        }

        internal static ICollection<Banca> getBancas()
        {
            ICollection<Banca> result = new HashSet<Banca>();
            string s_cmd = "SELECT * FROM dbo.Banca";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Banca> bancas = con.Query<Banca>(s_cmd);
                    foreach(Banca banca in bancas)
                    {
                        Feira feira = con.QueryFirst<Feira>($"SELECT * FROM dbo.Feira WHERE id='{banca.getFeiraId()}'");
                        Utilizador vendedor = getUtilizador(banca.getVendedorId());
                        IEnumerable<int> prodsIDS = con.Query<int>($"SELECT * FROM dbo.banca_has_produto WHERE Feira_id = '{banca.getFeiraId()}' AND Utilizador_id = '{banca.getVendedorId()}'");
                        foreach (int prodID in prodsIDS)
                        {
                            banca.addProduto(getProduto(prodID));
                        }
                        banca.setFeira(feira);
                        banca.setVendedor(vendedor);
                        result.Add(banca);
                    }

                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        internal static ICollection<Pair<int,int>> getBancasIDs()
        {
            ICollection<Pair<int, int>> result = new HashSet<Pair<int, int>>();
            string s_cmd = "SELECT Feira_id,Utilizador_id FROM dbo.Banca";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Pair<int, int>> aux = con.Query<Pair<int, int>>(s_cmd);
                    foreach (Pair<int, int> p in aux)
                    {
                        result.Add(p);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }
        
        // FEIRAS
        private static ICollection<Banca> getBancasOfFeira(int feiraID) 
        {
            ICollection<Banca> result = new HashSet<Banca>();
            string s_cmd = $"SELECT * FROM dbo.Banca WHERE Feira_id = '{feiraID}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Banca> bancas = con.Query<Banca>(s_cmd);
                    foreach (Banca banca in bancas)
                    {
                        Feira feira = con.QueryFirst<Feira>($"SELECT * FROM dbo.Feira WHERE id='{banca.getFeiraId()}'");
                        Utilizador vendedor = getUtilizador(banca.getVendedorId());
                        IEnumerable<int> prodsIDS = con.Query<int>($"SELECT Produto_id FROM dbo.banca_has_produto WHERE Feira_id = '{banca.getFeiraId()}' AND Utilizador_id = '{banca.getVendedorId()}'");
                        foreach (int prodID in prodsIDS)
                        {
                            banca.addProduto(getProduto(prodID));
                        }
                        banca.setFeira(feira);
                        banca.setVendedor(vendedor);
                        result.Add(banca);
                    }

                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }
        internal static Feira getFeira(int feiraID)
        {
            Feira? feira = null;
            string s_cmd = $"SELECT * FROM dbo.Feira WHERE id = '{feiraID}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Feira aux = con.QueryFirst<Feira>(s_cmd);
                    Categoria categoria = getCategoria(aux.getCategoriaID());
                    ICollection<Banca> bancas = getBancasOfFeira(feiraID);
                    foreach (Banca banca in bancas)
                    {
                        aux.addBanca(banca);
                    }
                    aux.setCategoria(categoria);
                    feira = aux;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return feira;
        }

        internal static ICollection<Feira> getFeiras()
        {
            ICollection<Feira> result = new HashSet<Feira>();
            string s_cmd = "SELECT * FROM dbo.Feira";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Feira> aux = con.Query<Feira>(s_cmd);
                    foreach(Feira feira in aux)
                    {
                        Categoria categoria = getCategoria(feira.getCategoriaID());
                        ICollection<Banca> bancas = getBancasOfFeira(feira.getId());
                        foreach(Banca banca in bancas)
                        {
                            feira.addBanca(banca);
                        }
                        feira.setCategoria(categoria);
                        result.Add(feira);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        internal static ICollection<int> getFeirasIDs()
        {
            ICollection<int> result = new HashSet<int>();
            string s_cmd = "SELECT id FROM dbo.Feira";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<int> aux = con.Query<int>(s_cmd);
                    foreach (int i in aux)
                    {
                        result.Add(i);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }
    }
}
