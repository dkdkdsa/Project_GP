using System.Collections.Generic;

public interface IStatContainer
{

    public Dictionary<int, Stat> StatContainer { get; set; }

    #region Get
    public Stat GetStat(int key)
    {

        if (StatContainer.TryGetValue(key, out Stat result))
        {

            return result;

        }

        return null;

    }

    public Stat GetStat(string key) => GetStat(key.GetHash());

    public float GetStatValue(int key, float defaultValue = default)
    {

        var stat = GetStat(key);

        if (stat != null)
        {

            return stat.Value;

        }

        return defaultValue;

    }

    public float GetStatValue(string key, float defaultValue = default) => GetStatValue(key.GetHash(), defaultValue);

    #endregion

    #region Add

    public void AddStat(int key, Stat stat)
    {

        StatContainer.Add(key, stat);

    }

    public void AddStat(string key, Stat stat) => AddStat(key.GetHash(), stat);

    #endregion

}
