namespace eFeiras.Business.Feiras
{
    public interface IFeirasFacade
    {
        public bool existsName(string name);
        public ICollection<Feira> feirasEmCurso();
    }
}
