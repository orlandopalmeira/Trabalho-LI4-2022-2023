using eFeiras.Business.Feiras;
using System.Runtime.CompilerServices;

namespace eFeiras.TransferData
{
    public class VisitedFeira
    {
        // Armazena a feira que está a ser visitada neste momento
        private static Feira? visited = null;

        private VisitedFeira() { }


        public static void setFeira(Feira? feira)
        {
            visited = feira;
        }

        public static Feira? getFeira()
        {
            return visited;
        }
    }
}
