using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHp
{

    public float GetHp();
    public float GetMaxHp();
    public void SetHp(float hp);
    public void AddHp(float hp);
    public void SubtractHp(float hp);

}
