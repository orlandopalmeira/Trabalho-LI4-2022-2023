using eFeiras.Data;
using eFeiras.Utils;

namespace eFeiras.Business.SubCategorias
{
    public class SubCategoriasFacade : ISubCategoriasFacade
    {
        private Map<int, SubCategoria> subcategorias;

        public SubCategoriasFacade()
        {
            this.subcategorias = SubCategoriaDAO.getInstance();
        }

        
    }
}
