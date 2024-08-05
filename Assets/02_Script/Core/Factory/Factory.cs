public static class Factory
{

    public static IFactory<T> GetFactory<T>()
    {

        return FactoryContainer.Instance.GetFactory<T>();

    }

}
