using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatDataSO : ScriptableObject
{

    [field:SerializeField] public List<StatObject> Stats { get; set; }

    [System.Serializable]
    public class StatObject
    {

        public string key;
        public Stat stat;

    }

}
