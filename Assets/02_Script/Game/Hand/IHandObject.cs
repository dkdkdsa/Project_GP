using UnityEngine;

public struct HandData
{

    public Vector3 leftHandPos;
    public Vector3 rightHandPos;

}

public interface IHandObject
{

    public HandData GetHandData();
    public void SetHandData(HandData? handData);

}