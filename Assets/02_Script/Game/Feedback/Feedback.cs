using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class Feedback : ExpansionMonoBehaviour, IFeedbackHandler
{
    public virtual void Awake()
    {

    }

    /// <summary>
    /// 피드백을 생성하는 함수
    /// </summary>
    /// <returns>피드백이 성공적으로 실행 됐는지</returns>
    public abstract bool StartFeedback();

    /// <summary>
    /// 피드백을 종료하는 함수
    /// </summary>
    /// <returns>피드백이 성공적으로 종료 됐는지</returns>
    public abstract bool FinishFeedback();

    /// <summary>
    /// 실제로 피드백을 생성하는 함수
    /// </summary>
    /// <returns></returns>
    public abstract bool DoStartFeedback();

    /// <summary>
    /// 실제로 피드백을 종료하는 함수
    /// </summary>
    /// <returns></returns>
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
