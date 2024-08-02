using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : ExpansionMonoBehaviour, IHandObject
{

    [SerializeField] private Transform _leftHand;
    [SerializeField] private Transform _rightHand;

    public HandData GetHandData()
    {

        return new HandData
        {

            leftHandPos = _leftHand.position,
            rightHandPos = _rightHand.position,

        };

    }

    public void SetHandData(HandData? handData)
    {

        if (handData != null)
        {

            _leftHand.gameObject.SetActive(true);
            _rightHand.gameObject.SetActive(true);

            _leftHand.position = handData.Value.leftHandPos;
            _rightHand.position = handData.Value.rightHandPos;

        }
        else
        {

            _leftHand.gameObject.SetActive(false);
            _rightHand.gameObject.SetActive(false);

        }

    }

}
