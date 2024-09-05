using System;

public interface IScoreController<TKey, TValue>
{

    public TValue GetScore(TKey key);
    public void RegisterScoreChangeEvent(Action<TKey, TValue> action);
    public void UnRegisterScoreChangeEvent(Action<TKey, TValue> action);

}
