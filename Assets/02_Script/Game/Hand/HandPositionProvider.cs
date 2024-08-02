using UnityEngine;

public class HandPositionProvider : ExpansionMonoBehaviour, IHandTarget
{

    [SerializeField] private Transform _leftHandPos;
    [SerializeField] private Transform _rightHandPos;

    public HandData GetTarget()
    {

        return new HandData
        {

            leftHandPos = _leftHandPos.position,
            rightHandPos = _rightHandPos.position

        };

    }

}