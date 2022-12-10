using eFeiras.Utils;
using System.Runtime.CompilerServices;

namespace eFeiras.Business
{
    public class Compra
    {
        private int id;
        private float montante;
        private DateTime data;
        private int comprador_id;
        // Depois escolhemos o que for mais conveniente
        private List<Pair<Produto,int>> produtos1; // Pair<Produto,quantidade_produto>
        private List<Pair<int,int>> produtos2; // Pair<id_produto,quantidade_produto>

        public Compra(int id, DateTime data, int compradorID)
        {
            this.id = id;
            this.montante = 0;
            this.data = data;
            this.comprador_id = compradorID;
            this.produtos1 = new List<Pair<Produto, int>>();
            this.produtos2 = new List<Pair<int, int>>();
        }
        /// <summary>
        /// Calcula o montante desta compra de acordo com os produto que tem.
        /// </summary>
        public void calcMontante1()
        {
            this.montante = 0;
            foreach(Pair<Produto,int> p in this.produtos1){
                this.montante += p.getX().getPreco() * p.getY();
            }
        }

        public int getID() 
        {
            return this.id;
        }
        
        
    }
}
