using eFeiras.Business.Utilizadores;
using eFeiras.Utils;
using System.Data.SqlClient;

namespace eFeiras.Data
{
    public class UtilizadorDAO : Map<int, Utilizador>
    {
        private static UtilizadorDAO? singleton = null;

        private UtilizadorDAO() { }

        public static UtilizadorDAO getInstance()
        {
            if (UtilizadorDAO.singleton == null)
            {
                UtilizadorDAO.singleton = new UtilizadorDAO();
            }
            return UtilizadorDAO.singleton;
        }

        public bool containsKey(int key) 
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Utilizador WHERE id = " + key;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd,con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch(Exception)
            {
                throw new DAOException("Erro no containsKey do UtilizadorDAO");
            }
            return result;
        }

        public bool containsValue(Utilizador value)
        {
            return this.containsKey(value.getID());
        }

        public Utilizador get(int key)
        {
            Utilizador? result = null;
            string s_cmd = "SELECT * FROM dbo.Utilizador WHERE id = " + key;
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
                                int id = -1; int.TryParse(reader["id"].ToString(), out id);
                                int userType = -1; int.TryParse(reader[userType].ToString(), out userType);
                                string? nome = reader["nome"].ToString();
                                string? nif = reader["nif"].ToString();
                                string? cartao_cidadao = reader["cartao_cidadao"].ToString();
                                string? email = reader["e_mail"].ToString();
                                string? rua_porta_andar = reader["rua_porta_andar"].ToString();
                                string? cidade = reader["cidade"].ToString();
                                string? codigo_postal = reader["codigo_postal"].ToString();
                                string? apresentacao = reader["apresentacao"].ToString();
                                bool aprovado = reader["aprovado"].ToString().CompareTo("1") == 0 ? true : false;
                                string? username = reader["username"].ToString();
                                string? password = reader["password_"].ToString();
                                result = new Utilizador(id, userType, nome, nif, cartao_cidadao, email, rua_porta_andar, cidade, codigo_postal, apresentacao, aprovado, username, password);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no get do UtilizadorDAO");
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
                                int id = -1; int.TryParse(reader.GetString(0), out id);
                                result.Add(id);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no keys do UtilizadorDAO");
            }
            return result;
        }

        public void put(int key, Utilizador value)
        {
            string s_cmd = "INSERT INTO dbo.Utilizador (userType,nome,nif,cartao_cidadao,e_mail,rua_porta_andar,cidade,codigo_postal,apresentacao,aprovado,username,password_) VALUES" + 
                            "('" + value.getUserType() + "','" + value.getNome() + "','" +
                            value.getNIF() + "','" + value.getCC() + "','" + value.getEmail() + "','" + value.getRuaPortaAndar() + "','" +
                            value.getCidade() + "','" + value.getCodigoPostal() + "','" + value.getApresentacao() + "','" +
                            (value.getAprovado() ? "1" : "0") + "','" + value.getUsername() + "','" + value.getPassword() + "')";
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
                throw new DAOException("Erro no put do UtilizadorDAO");
            }
        }

        public Utilizador remove(int key)
        {
            Utilizador result = this.get(key);
            string s_cmd = "DELETE FROM dbo.Utilizador WHERE id = " + key;
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
                throw new DAOException("Erro no remove do UtilizadorDAO");
            }
            return result;
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Utilizador";
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
                throw new DAOException("Erro no size do Utilizador");
            }
            return result;
        }

        public ICollection<Utilizador> values()
        {
            ICollection<Utilizador> result = new HashSet<Utilizador>();
            string s_cmd = "select * from dbo.Utilizador";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                int userType = Convert.ToInt32(reader.GetByte(1));
                                string? nome = reader.GetString(2);
                                string? nif = reader.GetString(3);
                                string? cartao_cidadao = reader.GetString(4);
                                string? email = reader.GetString(5);
                                string? rua_porta_andar = reader.GetString(6);
                                string? cidade = reader.GetString(7);
                                string? codigo_postal = reader.GetString(8);
                                string? apresentacao = reader.GetString(9);
                                bool aprovado = reader.GetBoolean(10);
                                string? username = reader.GetString(11);
                                string? password = reader.GetString(12);
                                result.Add(new Utilizador(id,userType,nome,nif,cartao_cidadao,
                                                          email,rua_porta_andar,cidade,codigo_postal,
                                                          apresentacao,aprovado,username,password));

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no values() do UtilizadorDAO");
            }
            return result;
        }

    }
}
