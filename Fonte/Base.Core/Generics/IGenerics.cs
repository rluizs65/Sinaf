namespace Base.Core.Generics
{
    public interface IGenerics
    {
        TClass Get<TClass>(string name) where TClass : class;
    }
}
