using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class Feedback : ExpansionMonoBehaviour, IFeedbackHandler
{
    public abstract event Action OnStartFeedbackEvent;
    public abstract event Action OnFinishFeedbackEvent;

    public virtual void Awake()
    {

    }

    public abstract bool StartFeedback(); //피드백 생성
    public abstract bool FinishFeedback(); //피드백 종료
    public abstract bool DoStartFeedback();
    public abstract bool DoFinishFeedback();

    protected virtual void OnDestroy()
    {
        FinishFeedback();
    }

    protected virtual void OnDisable()
    {
        FinishFeedback();
    }

}
