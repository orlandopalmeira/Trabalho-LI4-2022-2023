namespace eFeiras.Data
{
    /// <summary>
    /// Esta classe armazena os dados de acesso à base de dados.
    /// </summary>
    public class DAOconfig
    {
        public const string USER = "orlando";
        public const string PASSWORD = "orlando912";
        public const string MACHINE = "LAPTOP-M6U8FVRC";
        public const string DATABASE = "eFeiras";
        public const string CONNECTION_STR = @"Data Source=" + MACHINE + ";Initial Catalog=" + DATABASE + 
                                              ";User ID=" + USER + ";Password=" + PASSWORD;
    }
}
