using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ExpansionMonoBehaviour, ILocalInject
{

    private IStatContainer _statContainer;

    public void LocalInject(ComponentList list)
    {

        _statContainer = list.Find<IStatContainer>();

    }

}