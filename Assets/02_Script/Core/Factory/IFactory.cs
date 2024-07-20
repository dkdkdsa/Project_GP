public interface IFactory<T> : IPauseable
{

    public T CreateInstance();

}
