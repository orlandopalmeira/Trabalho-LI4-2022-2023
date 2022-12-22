using System.Data.SqlClient;

namespace eFeiras.Data
{
    /// <summary>
    /// Esta classe armazena os dados de acesso à base de dados.
    /// </summary>
    internal class DAOconfig
    {
        public const string USER = "orlando";
        public const string PASSWORD = "orlando912";
        public const string MACHINE = "ORLANDOPC\\SQLEXPRESS";
        public const string DATABASE = "eFeiras";
    
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = MACHINE;
            builder.UserID = USER;
            builder.Password = PASSWORD;
            builder.InitialCatalog = DATABASE;
            builder.TrustServerCertificate = true;
            return builder.ConnectionString;
        }
    }
}
