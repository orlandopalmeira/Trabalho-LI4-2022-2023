using eFeiras.Data;
using eFeiras.Utils;

namespace eFeiras.Business.Categorias
{
    public class CategoriasFacade : ICategoriasFacade
    {
        private Map<int, Categoria> categorias;
        public CategoriasFacade()
        {
            this.categorias = CategoriaDAO.getInstance();
        }

        public Categoria getCategoria(int categoriaID)
        {
            return this.categorias.get(categoriaID);
        }
    }
}
