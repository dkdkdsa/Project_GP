using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxBrokenFeedback : EffectFeedback
{
    public override event Action OnStartFeedbackEvent;
    public override event Action OnFinishFeedbackEvent;

    public override bool StartFeedback()
    {
        OnStartFeedbackEvent?.Invoke();
        bool result = DoStartFeedback();

        return result;
    }


    public override bool FinishFeedback()
    {
        OnFinishFeedbackEvent?.Invoke();
        bool result = DoFinishFeedback();

        return result;
    }

    public override bool DoStartFeedback()
    {
        return true;
    }

    public override bool DoFinishFeedback()
    {
        return true;
    }

}
