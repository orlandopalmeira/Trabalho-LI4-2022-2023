using System.Runtime.CompilerServices;

namespace eFeiras.Business
{
    public class Banca
    {
        private int feira_id;
        private int vendedor_id;
        private string titulo;

        public Banca(int feira_id, int vendedor_id, string titulo)
        {
            this.feira_id = feira_id;
            this.vendedor_id= vendedor_id;
            this.titulo = titulo;
        }
    }
}
