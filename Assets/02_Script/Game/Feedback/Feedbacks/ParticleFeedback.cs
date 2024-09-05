using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFeedback : Feedback
{

    [SerializeField] private GameObject _playParticle;

    public override bool DoFinishFeedback()
    {

        return true;

    }

    public override bool DoStartFeedback()
    {
        Instantiate(_playParticle, transform.position, Quaternion.identity);
        return true;
    }

    public override bool FinishFeedback() => DoFinishFeedback();

    public override bool StartFeedback() => DoStartFeedback();


}
