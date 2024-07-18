using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionMonoBehaviour : MonoBehaviour
{
    
    public T Cast<T>()
    {

        return Support.Cast<T>(this);

    }

}
