using System.Collections.Generic;
using UnityEngine;

public class LocalInstaller : MonoBehaviour
{

    private void Awake()
    {
        
        var compoList = new ComponentList(GetComponentsInChildren<IComponent>());

        foreach(var inj in GetComponentsInChildren<ILocalInject>())
        {

            inj.LocalInject(compoList);

        }

    }

  
}
