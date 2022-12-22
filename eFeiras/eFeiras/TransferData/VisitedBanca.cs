using eFeiras.Business.Bancas;

namespace eFeiras.TransferData
{
    public class VisitedBanca
    {
        private static Banca? visited = null;

        private VisitedBanca() { }

        public static void setBanca(Banca? banca)
        {
            visited = banca;
        }

        public static Banca? getBanca()
        {
            return visited;
        }
    }
}
