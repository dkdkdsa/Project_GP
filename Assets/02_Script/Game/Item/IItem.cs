public interface IItem<T> : IItem
{

    public void GetItem(T targetHandler);

}

public interface IItem { }