using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandController
{

    public Transform[] Hands { get; set; }
    public void SetUpHandPos(Transform[] trms);


}
