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

        return base.StartFeedback();
    }

    public override bool FinishFeedback()
    {
        OnFinishFeedbackEvent?.Invoke();

        return base.FinishFeedback();
    }

}
